using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Gds.BusinessObject.TableModel;
using Gds.ServiceModel.BackEndModel;
using Gds.Setting;
using GdsVideoBackend.Domain;

namespace GdsVideoBackend.Controllers
{
    public class CategoryDetailController : Controller
    {
        private readonly ICategoryDetailService _categoryDetailService;

        public CategoryDetailController(ICategoryDetailService categoryDetailService)
        {
            _categoryDetailService = categoryDetailService;
        }

        //
        // GET: /CategoryDetail/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryDetails(int categoryTypeId)
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetCategoryDetails(int pageIndex, int pageSize, int categoryTypeId)
        {
            var datas = _categoryDetailService.GetCategoryDetails(categoryTypeId, pageIndex, pageSize);
            return datas.Result.Any()
                ? Json(new {isSuccess = true, data = datas})
                : Json(new {isSuccess = false});
        }

        [HttpPost]
        public ActionResult UploadFile()
        {
            var categoryTypeId = Request["categoryTypeId"];
            var categoryDetailId = Request["categoryDetailId"];

            var categoryId = _categoryDetailService.GetCategoryId(Convert.ToInt32(categoryTypeId));
            
            var httpPostedFile = Request.Files[0];
            if (httpPostedFile == null) return Content("Uploaded Error");
            var uploadFilesDir = string.Format(@"{0}\{1}\{2}\{3}", AppConfig.UploadFolder, categoryId, categoryTypeId, categoryDetailId);
            if (!Directory.Exists(uploadFilesDir))
            {
                Directory.CreateDirectory(uploadFilesDir);
            }
            else
            {
                var folder = new DirectoryInfo(uploadFilesDir);
                foreach (var file in folder.GetFiles())
                {
                    file.Delete();
                }
            }
            var fileSavePath = Path.Combine(uploadFilesDir, httpPostedFile.FileName);

            httpPostedFile.SaveAs(fileSavePath);

            var fileModel = new PhysicalFiles
            {
                FileName = httpPostedFile.FileName,
                FileLength = httpPostedFile.ContentLength,
                FileServerNamePath = uploadFilesDir,
                CreatedDate = DateTime.UtcNow
            };

            _categoryDetailService.UpdateFileInfo(fileModel, Convert.ToInt32(categoryDetailId));
            return Content("Uploaded Successfully");
        }

        [HttpPost]
        public JsonResult Insert(CategoryDetailModel model)
        {
            var result = _categoryDetailService.Insert(model);
            return result ? Json(new { isSuccess = true }) : Json(new { isSuccess = false });
        }

        [HttpPost]
        public JsonResult Update(CategoryDetailModel model)
        {
            var result = _categoryDetailService.Update(model);
            return result ? Json(new { isSuccess = true }) : Json(new { isSuccess = false });
        }

        [HttpPost]
        public JsonResult Delete(int categoryId)
        {
            var result = _categoryDetailService.Delete(categoryId);
            return result ? Json(new { isSuccess = true }) : Json(new { isSuccess = false });
        }
	}
}