using System.Linq;
using System.Web.Mvc;
using Gds.ServiceModel.BackEndModel;
using GdsVideoBackend.Domain;

namespace GdsVideoBackend.Controllers
{
    public class CategorysController : Controller
    {
        private readonly ICategorysService _categorysService;

        public CategorysController(ICategorysService categorysService)
        {
            _categorysService = categorysService;
        }

        //
        // GET: /Categorys/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetCategorys(int pageIndex, int pageSize)
        {
            var datas = _categorysService.GetCategory(pageIndex, pageSize);
            foreach (var item in datas.Result)
            {
                item.DateTime = item.CreatedDate.Value.ToString("dd-MM-yyyy HH:mm");
                item.RouterDetail = Url.Action("Index", "CategoryType", new { categoryId = item.CategoryId });
            }
            return datas.Result.Any()
                ? Json(new { isSuccess = true, data = datas })
                : Json(new {isSuccess = false});
        }

        [HttpPost]
        public JsonResult AddCategory(CategoryModel model)
        {
            var result = _categorysService.AddCategory(model);
            return result ? Json(new {isSuccess = true}) : Json(new {isSuccess = false});
        }

        [HttpPost]
        public JsonResult UpdateCategory(CategoryModel model)
        {
            var result = _categorysService.EditCategory(model);
            return result ? Json(new { isSuccess = true }) : Json(new { isSuccess = false });
        }

        [HttpPost]
        public JsonResult DeleteCategory(int categoryId)
        {
            var result = _categorysService.DeleteCategory(categoryId);
            return result ? Json(new { isSuccess = true }) : Json(new { isSuccess = false });
        }
	}
}