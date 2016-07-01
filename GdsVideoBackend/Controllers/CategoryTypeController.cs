using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Gds.ServiceModel.BackEndModel;
using Gds.ServiceModel.ControlObject;
using GdsVideoBackend.Domain;

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
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetCategoryTypes(int categoryId, int pageIndex, int pageSize)
        {
            var result = _categoryTypeService.GetCategoryTypesByCategoryId(categoryId, pageIndex, pageSize);
            return result.Result.Any() ? Json(new {isSuccess = true, data = result}, JsonRequestBehavior.AllowGet)
                : Json(new {isSuccess = false, data = new PagingResultModel<CategoryTypesModel>()}, JsonRequestBehavior.AllowGet);
        }
	}
}