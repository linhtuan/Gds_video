using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gds.ServiceModel.BackEndModel;
using Gds.ServiceModel.ControlObject;
using Gds.Setting;
using GdsVideoBackend.Domain;
using GdsVideoBackend.Models;

namespace GdsVideoBackend.Controllers
{
    public class CategoryTypeController : Controller
    {
        private readonly ICategoryTypeService _categoryTypeService;

        public CategoryTypeController(ICategoryTypeService categoryTypeService)
        {
            _categoryTypeService = categoryTypeService;
        }

        //
        // GET: /CategoryType/
        public ActionResult Index(int categoryId)
        {
            var prices = _categoryTypeService.GetPrices().Select(x => new PriceSetting
            {
                Id = x.CategoryTypePriceId,
                Price = x.Price
            }).ToList();

            var ageOrder = _categoryTypeService.GetAgeOrders().Select(x => new AgeOrderSetting
            {
                Id = x.AgeOrderId,
                Name = x.AgeOrderName
            }).ToList();

            var authors = _categoryTypeService.GetAuthors().Select(x => new AuthorSetting
            {
                Id = x.AuthorId,
                Name = x.AuthorName,
            });
            var model = new CategoryTypeFromViewModel
            {
                PriceSetting = new List<PriceSetting>(),
                AgeOrderSetting = new List<AgeOrderSetting>(),
                AuthorSettings = new List<AuthorSetting>()
            };
            model.PriceSetting.AddRange(prices);
            model.AgeOrderSetting.AddRange(ageOrder);
            model.AuthorSettings.AddRange(authors);
            return View(model);
        }

        public JsonResult GetPrices()
        {
            var result = _categoryTypeService.GetPrices().Select(x => new
            {
                Id = x.CategoryTypePriceId,
                x.Price
            });
            return Json(new { isSuccess = false, data = result }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetParentCategoryType()
        {
            var result = _categoryTypeService.GetParentCategoryType().Select(x => new
            {
                Id = x.Key,
                Name = x.Value
            });
            return Json(new { isSuccess = false, data = result }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetParent(int categoryId, int pageIndex, int pageSize)
        {
            var result = _categoryTypeService.GetParentCategoryTypes(categoryId, pageIndex, pageSize);
            return result.Result.Any() ? Json(new { isSuccess = true, data = result }, JsonRequestBehavior.AllowGet)
                : Json(new { isSuccess = false, data = new PagingResultModel<CategoryTypesModel>() }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetChildren(int categoryId, int pageIndex, int pageSize)
        {
            var result = _categoryTypeService.GetCategoryTypesByCategoryId(categoryId, pageIndex, pageSize);
            return result.Result.Any() ? Json(new {isSuccess = true, data = result}, JsonRequestBehavior.AllowGet)
                : Json(new {isSuccess = false, data = new PagingResultModel<CategoryTypesModel>()}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, ValidateInput(false)]
        public JsonResult Insert()
        {
            var item = GetValueInFrom(Request);
            
            int categoryTypeId;
            var fileName = string.Empty;
            if (Request.Files.AllKeys.Any() && Request.Files[0] != null)
            {
                fileName = Request.Files[0].FileName;
            }
            var result = _categoryTypeService.InsertCategoryType(item, fileName, out categoryTypeId);
            item.CategoryTypeId = categoryTypeId;
            UploadThumbnailImage(item, Request);
            return result ? Json(new { isSuccess = true }) : Json(new { isSuccess = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, ValidateInput(false)]
        public JsonResult Update()
        {
            var item = GetValueInFrom(Request);
            item = UploadThumbnailImage(item, Request);
            var result = _categoryTypeService.UpdateCategoryType(item);
            return result ? Json(new { isSuccess = true }) : Json(new { isSuccess = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, ValidateInput(false)]
        public JsonResult UpdateChildren(CategoryTypeViewModel item)
        {
            var result = _categoryTypeService.UpdateCategoryType(item);
            return result ? Json(new { isSuccess = true }) : Json(new { isSuccess = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, ValidateInput(false)]
        public JsonResult InsertChildren(CategoryTypeViewModel item)
        {
            var categoryType = 0;
            var result = _categoryTypeService.InsertCategoryType(item, string.Empty, out categoryType);
            return result ? Json(new { isSuccess = true }) : Json(new { isSuccess = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int categoryTypeId, string type)
        {
            var result = _categoryTypeService.DeleteCategoryType(categoryTypeId);
            return result ? Json(new { isSuccess = true, type = type }) : Json(new { isSuccess = false }, JsonRequestBehavior.AllowGet);
        }

        private CategoryTypeViewModel GetValueInFrom(HttpRequestBase request)
        {
            var item = new CategoryTypeViewModel
            {
                CategoryId = Convert.ToInt32(request["CategoryId"]),
                CategoryTypeId = Convert.ToInt32(request["CategoryTypeId"]),
                CategoryTypeName = request["CategoryTypeName"],
                Content = request["Content"],
                CategoryTypePriceId = Convert.ToInt32(request["Price"]),
                AgeOrderId = Convert.ToInt32(request["AgeOrder"]),
                CategoryTypeOrderId = Convert.ToInt32(request["CategoryTypeOrder"]),
                AuthorId = Convert.ToInt32(request["Author"])
            };
            return item;
        }

        private CategoryTypeViewModel UploadThumbnailImage(CategoryTypeViewModel model, HttpRequestBase request)
        {
            if (!request.Files.AllKeys.Any() || request.Files[0] == null) return model;

            var fileThumbnail = request.Files[0];
            var fileName = string.Empty;
            var uploadFilesDir = string.Format(@"{0}\thumbnailImage\{1}\{2}", AppConfig.UploadFolder, model.CategoryId, model.CategoryTypeId);
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

            model.FileThumbnail = string.Format("{0}\\{1}", uploadFilesDir, !string.IsNullOrEmpty(fileThumbnail.FileName) ? fileThumbnail.FileName : fileName);
            return model;
        }
	}
}