using System.Linq;
using System.Web.Mvc;
using Gds.ServiceModel.BackEndModel;
using Gds.ServiceModel.ControlObject;
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
            return View();
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
        public JsonResult Insert(CategoryTypeViewModel item)
        {
            var result = _categoryTypeService.InsertCategoryType(item);
            return result ? Json(new { isSuccess = true }) : Json(new { isSuccess = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, ValidateInput(false)]
        public JsonResult Update(CategoryTypeViewModel item)
        {
            var result = _categoryTypeService.UpdateCategoryType(item);
            return result ? Json(new { isSuccess = true }) : Json(new { isSuccess = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int categoryTypeId, string type)
        {
            var result = _categoryTypeService.DeleteCategoryType(categoryTypeId);
            return result ? Json(new { isSuccess = true, type = type }) : Json(new { isSuccess = false }, JsonRequestBehavior.AllowGet);
        }
	}
}