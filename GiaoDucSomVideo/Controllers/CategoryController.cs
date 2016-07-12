using System.Linq;
using System.Web.Mvc;
using Gds.Setting;
using GiaoDucSomVideo.Domain;
using GiaoDucSomVideo.Infrastructure;

namespace GiaoDucSomVideo.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: Category
        [Route("category/{category?}")]
        public ActionResult Index(string category)
        {
            var leftMenu = _categoryService.GetLeftMenu();
            SessionManager.SetSessionObject(SessionObjectEnum.Categorys, leftMenu);
            var courses = _categoryService.GetCourses(category, 1, 5);
            if (!courses.Result.Any()) return null;
            var test =  SessionManager.GetSessionObject(SessionObjectEnum.Categorys);
            return View();
        }
    }
}