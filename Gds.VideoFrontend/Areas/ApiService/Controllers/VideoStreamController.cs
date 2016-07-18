using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using Gds.VideoFrontend.Areas.ApiService.Domain;
using Gds.VideoFrontend.Domain;

namespace Gds.VideoFrontend.Areas.ApiService.Controllers
{
    public class VideoStreamController : ApiController
    {
        private readonly ICategoryDetailService _categoryDetailService;

        public VideoStreamController(ICategoryDetailService categoryDetailService)
        {
            _categoryDetailService = categoryDetailService;
        }

        [Route("api/videostream/fromvideo")]
        [HttpGet]
        public HttpResponseMessage FromVideo(int physicalFile)
        {
            //int physicalFileId;
            //if (!int.TryParse(CryptographyHelper.Decrypt(physicalFile), out physicalFileId)) return null;

            var videoName = _categoryDetailService.GetVideos(physicalFile);
            if (string.IsNullOrEmpty(videoName)) return null;
            var video = new VideoStream(videoName);
            Func<Stream, HttpContent, TransportContext, Task> func = video.WriteToStream;
            var response = Request.CreateResponse();
            response.Content = new PushStreamContent(func, new MediaTypeHeaderValue("video/mp4"));
            return response;
        }
    }
}
