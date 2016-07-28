using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gds.BusinessObject.TableModel;
using Gds.ServiceModel.ControlObject;
using Gds.Setting;
using GdsVideoBackend.Domain;

namespace GdsVideoBackend.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: Author
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetAuthors(int pageIndex, int pageSize)
        {
            var result = _authorService.GetAuthors(pageIndex, pageSize);
            return result.Result.Any() ? Json(new { isSuccess = true, data = result }, JsonRequestBehavior.AllowGet)
                : Json(new { isSuccess = false, data = new PagingResultModel<Author>() }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Insert()
        {
            var item = GetValueInFrom(Request);
            item = _authorService.InsertAuthor(item);
            item = UpdateImage(item, Request);
            var result =  _authorService.UpdateAuthor(item);
            return result ? Json(new { isSuccess = true }) : Json(new { isSuccess = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update()
        {
            var item = GetValueInFrom(Request);
            item = UpdateImage(item, Request);
            var result = _authorService.UpdateAuthor(item);
            return result ? Json(new { isSuccess = true }) : Json(new { isSuccess = false }, JsonRequestBehavior.AllowGet);
        }

        private Author UpdateImage(Author model, HttpRequestBase request)
        {
            if (!request.Files.AllKeys.Any() || request.Files[0] == null) return model;
            var fileThumbnail = request.Files[0];
            var fileName = string.Empty;
            var uploadFilesDir = string.Format(@"{0}\author\{1}", AppConfig.UploadFolder, model.AuthorId);
            if (!Directory.Exists(uploadFilesDir))
            {
                Directory.CreateDirectory(uploadFilesDir);
            }
            else
            {
                var folder = new DirectoryInfo(uploadFilesDir);
                foreach (var file in folder.GetFiles())
                {
                    if (string.IsNullOrEmpty(fileThumbnail.FileName))
                        fileName = file.Name;
                    else
                        file.Delete();
                }
            }
            var fileSavePath = Path.Combine(uploadFilesDir, !string.IsNullOrEmpty(fileThumbnail.FileName) ? fileThumbnail.FileName : fileName);
            if (!string.IsNullOrEmpty(fileThumbnail.FileName))
                fileThumbnail.SaveAs(fileSavePath);

            model.AuthorImage = string.Format("{0}\\{1}", uploadFilesDir, !string.IsNullOrEmpty(fileThumbnail.FileName) ? fileThumbnail.FileName : fileName);
            return model;
        }

        private Author GetValueInFrom(HttpRequestBase request)
        {
            var model = new Author
            {
                AuthorId = Convert.ToInt32(request["AuthorId"]),
                AuthorName = request["AuthorName"],
                AuthorDetail = request["AuthorDetail"],
            };

            return model;
        }
    }
}