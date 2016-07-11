using System.Linq;
using System.Web.Mvc;
using GiaoDucSomVideo.Domain;
using GiaoDucSomVideo.Infrastructure;

namespace GiaoDucSomVideo.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public HomeController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCategorys()
        {
            var result = _categoryService.GetCategoryHomePage();
            return result.Any()
                ? Json(new {isSuccess = true, data = result}, JsonRequestBehavior.AllowGet)
                : Json(new {isSuccess = false}, JsonRequestBehavior.AllowGet);
        }
    }
}