using System.IO;
using System.Web.Mvc;
using Gds.Setting;

namespace GdsVideoBackend.Controllers
{
    public class CategoryDetailController : Controller
    {
        //
        // GET: /CategoryDetail/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile()
        {
            var httpPostedFile = Request.Files[0];
            if (httpPostedFile == null) return Content("Uploaded Error");
            var uploadFilesDir = AppConfig.UploadFolder;
            if (!Directory.Exists(uploadFilesDir))
            {
                Directory.CreateDirectory(uploadFilesDir);
            }
            var fileSavePath = Path.Combine(uploadFilesDir, httpPostedFile.FileName);

            httpPostedFile.SaveAs(fileSavePath);

            return Content("Uploaded Successfully");
        }
	}
}