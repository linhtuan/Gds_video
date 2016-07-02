using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Gds.ServiceModel.BackEndModel;
using Gds.ServiceModel.ControlObject;
using GdsVideoBackend.Domain;
using GdsVideoBackend.Models;
using Newtonsoft.Json;

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
        [Route("categorytype")]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetPrices()
        {
            var result = _categoryTypeService.GetPrices().Select(x => new
            {
                Id = x.CategoryTypePriceId,
                x.Price
            });
            return Json(new {isSuccess = false, data = result});
        }

        public JsonResult GetParentCategoryType()
        {
            var result = _categoryTypeService.GetParentCategoryType().Select(x => new
            {
                Id = x.Key,
                Name = x.Value
            });
            return Json(new { isSuccess = false, data = result });
        }

        [Route("categorytype/getparents")]
        public JsonResult GetParentCategoryTypes(int categoryId, int pageIndex, int pageSize)
        {
            var result = _categoryTypeService.GetParentCategoryTypes(categoryId, pageIndex, pageSize);
            return result.Result.Any() ? Json(new { isSuccess = true, data = result }, JsonRequestBehavior.AllowGet)
                : Json(new { isSuccess = false, data = new PagingResultModel<CategoryTypesModel>() }, JsonRequestBehavior.AllowGet);
        }

        [Route("categorytype/getchildren")]
        public JsonResult GetCategoryTypes(int categoryId, int pageIndex, int pageSize)
        {
            var result = _categoryTypeService.GetCategoryTypesByCategoryId(categoryId, pageIndex, pageSize);
            return result.Result.Any() ? Json(new {isSuccess = true, data = result}, JsonRequestBehavior.AllowGet)
                : Json(new {isSuccess = false, data = new PagingResultModel<CategoryTypesModel>()}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, ValidateInput(false)]
        public JsonResult Insert(CategoryTypeViewModel item)
        {
            var result = _categoryTypeService.InsertCategoryType(item);
            return result ? Json(new { isSuccess = true }) : Json(new { isSuccess = false });
        }

        [HttpPost, ValidateInput(false)]
        public JsonResult Update()
        {
            var model = new CategoryTypesModel();
            var result = _categoryTypeService.UpdateCategoryType(model);
            return result ? Json(new { isSuccess = true }) : Json(new { isSuccess = false });
        }

        [HttpPost]
        public JsonResult Delete()
        {
            var result = _categoryTypeService.DeleteCategoryType(0);
            return result ? Json(new { isSuccess = true }) : Json(new { isSuccess = false });
        }
	}
}