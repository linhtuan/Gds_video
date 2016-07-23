using System;
using System.IO;
using System.Linq;
using System.Web;
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
        public ActionResult Index(int categoryTypeId)
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
        public ActionResult InsertUpateDetail()
        {
            var categoryTypeId = Request["CategoryTypeId"];
            var categoryDetailId = Request["CategoryDetailId"];
            var lectureIndex = Request["LectureIndex"];
            var categoryDetailName = Request["CategoryDetailName"];
            var model = new CategoryDetailModel
            {
                CategoryTypeId = Convert.ToInt32(categoryTypeId),
                CategoryDetailName = categoryDetailName,
                LectureIndex = Convert.ToInt32(lectureIndex)
            };
            int cateDetailId;
            if (!int.TryParse(categoryDetailId, out cateDetailId))
            {
                cateDetailId = Insert(model);
            }
            else
            {
                model.CategoryDetailId = cateDetailId;
                cateDetailId = Update(model);
            }
            //Upload File
            model.CategoryDetailId = cateDetailId;
            UploadFile(model, Request);
            
            return Content("Uploaded Successfully");
        }

        [HttpPost]
        public JsonResult Delete(int categoryId)
        {
            var result = _categoryDetailService.Delete(categoryId);
            return result ? Json(new { isSuccess = true }) : Json(new { isSuccess = false });
        }

        private int Insert(CategoryDetailModel model)
        {
            var result = _categoryDetailService.Insert(model);
            return result;
        }

        private int Update(CategoryDetailModel model)
        {
            var result = _categoryDetailService.Update(model);
            return result;
        }

        private bool UploadFile(CategoryDetailModel model, HttpRequestBase request)
        {
            // UpFile
            var httpPostedFile = request.Files[0];
            if (httpPostedFile == null) return false;
            var categoryId = _categoryDetailService.GetCategoryId(Convert.ToInt32(model.CategoryTypeId));
            var uploadFilesDir = string.Format(@"{0}\{1}\{2}\{3}", AppConfig.UploadFolder, categoryId, model.CategoryTypeId, model.CategoryDetailId);
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
            _categoryDetailService.UpdateFileInfo(fileModel, model.CategoryDetailId);
            return true;
        }
    }
}