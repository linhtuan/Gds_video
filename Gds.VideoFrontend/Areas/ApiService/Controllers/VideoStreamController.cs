using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Web.Http;
using Gds.Setting.Cryptography;
using Gds.VideoFrontend.Domain;

namespace Gds.VideoFrontend.Areas.ApiService.Controllers
{
    public class VideoStreamController : ApiController
    {
        private readonly ICategoryDetailService _categoryDetailService;

        #region Fields

        // This will be used in copying input stream to output stream.
        public const int ReadStreamBufferSize = 1024 * 1024;
        // We have a read-only dictionary for mapping file extensions and MIME names. 
        public static IReadOnlyDictionary<string, string> MimeNames;
        // We will discuss this later.
        public static IReadOnlyCollection<char> InvalidFileNameChars;
        // Where are your videos located at? Change the value to any folder you want.

        #endregion

        public VideoStreamController(ICategoryDetailService categoryDetailService)
        {
            _categoryDetailService = categoryDetailService;

            var mimeNames = new Dictionary<string, string>
            {
                {".mp3", "audio/mpeg"},
                {".mp4", "video/mp4"},
                {".ogg", "application/ogg"},
                {".ogv", "video/ogg"},
                {".oga", "audio/ogg"},
                {".wav", "audio/x-wav"},
                {".webm", "video/webm"}
            };
            MimeNames = new ReadOnlyDictionary<string, string>(mimeNames);
            InvalidFileNameChars = Array.AsReadOnly(Path.GetInvalidFileNameChars());
        }

        [HttpGet]
        [Route("api/videostream/fromvideo")]
        public HttpResponseMessage FromVideo(string physicalFile)
        {
            int physicalFileId;
            if (!int.TryParse(CryptographyHelper.Decrypt(physicalFile), out physicalFileId)) return null;

            var fileName = _categoryDetailService.GetVideos(physicalFileId);
            if (fileName == null) return null;
            var fileInfo = new FileInfo(Path.Combine(fileName));

            if (!fileInfo.Exists)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var totalLength = fileInfo.Length;

            var rangeHeader = Request.Headers.Range;
            var response = new HttpResponseMessage();

            response.Headers.AcceptRanges.Add("bytes");

            // The request will be treated as normal request if there is no Range header.
            if (rangeHeader == null || !rangeHeader.Ranges.Any())
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Content = new PushStreamContent((outputStream, httpContent, transpContext)
                =>
                {
                    using (outputStream) // Copy the file to output stream straightforward. 
                    using (Stream inputStream = fileInfo.OpenRead())
                    {
                        try
                        {
                            inputStream.CopyTo(outputStream, ReadStreamBufferSize);
                        }
                        catch (Exception error)
                        {
                            Debug.WriteLine(error);
                        }
                    }
                }, GetMimeNameFromExt(fileInfo.Extension));

                response.Content.Headers.ContentLength = totalLength;
                return response;
            }

            long start = 0, end = 0;

            // 1. If the unit is not 'bytes'.
            // 2. If there are multiple ranges in header value.
            // 3. If start or end position is greater than file length.
            if (rangeHeader.Unit != "bytes" || rangeHeader.Ranges.Count > 1 ||
                !TryReadRangeItem(rangeHeader.Ranges.First(), totalLength, out start, out end))
            {
                response.StatusCode = HttpStatusCode.RequestedRangeNotSatisfiable;
                response.Content = new StreamContent(Stream.Null);  // No content for this status.
                response.Content.Headers.ContentRange = new ContentRangeHeaderValue(totalLength);
                response.Content.Headers.ContentType = GetMimeNameFromExt(fileInfo.Extension);

                return response;
            }

            var contentRange = new ContentRangeHeaderValue(start, end, totalLength);

            // We are now ready to produce partial content.
            response.StatusCode = HttpStatusCode.PartialContent;
            response.Content = new PushStreamContent((outputStream, httpContent, transpContext)
            =>
            {
                using (outputStream) // Copy the file to output stream in indicated range.
                using (Stream inputStream = fileInfo.OpenRead())
                    CreatePartialContent(inputStream, outputStream, start, end);

            }, GetMimeNameFromExt(fileInfo.Extension));

            response.Content.Headers.ContentLength = end - start + 1;
            response.Content.Headers.ContentRange = contentRange;

            return response;
        }

        #region Others

        private static bool AnyInvalidFileNameChars(string fileName)
        {
            return InvalidFileNameChars.Intersect(fileName).Any();
        }

        private static MediaTypeHeaderValue GetMimeNameFromExt(string ext)
        {
            string value;
            return MimeNames.TryGetValue(ext.ToLowerInvariant(), out value)
                ? new MediaTypeHeaderValue(value)
                : new MediaTypeHeaderValue(MediaTypeNames.Application.Octet);
        }

        private static bool TryReadRangeItem(RangeItemHeaderValue range, long contentLength,
            out long start, out long end)
        {
            if (range.From != null)
            {
                start = range.From.Value;
                if (range.To != null)
                    end = range.To.Value;
                else
                    end = contentLength - 1;
            }
            else
            {
                end = contentLength - 1;
                if (range.To != null)
                    start = contentLength - range.To.Value;
                else
                    start = 0;
            }
            return (start < contentLength && end < contentLength);
        }

        private static void CreatePartialContent(Stream inputStream, Stream outputStream,
            long start, long end)
        {
            var remainingBytes = end - start + 1;
            long position;
            var buffer = new byte[ReadStreamBufferSize];

            inputStream.Position = start;
            do
            {
                try
                {
                    var count = remainingBytes > ReadStreamBufferSize 
                        ? inputStream.Read(buffer, 0, ReadStreamBufferSize) 
                        : inputStream.Read(buffer, 0, (int)remainingBytes);
                    outputStream.Write(buffer, 0, count);
                }
                catch (Exception error)
                {
                    break;
                }
                position = inputStream.Position;
                remainingBytes = end - position + 1;
            } while (position <= end);
        }

        #endregion
    }
}
