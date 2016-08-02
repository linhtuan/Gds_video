using System.Linq;
using System.Web.Mvc;
using Gds.Frontend.Domain;
using Gds.Frontend.Infrastructure;
using Gds.Frontend.Models;

namespace Gds.Frontend.Controllers
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
            string title;
            var courseHot = _categoryService.GetCoursesHot(category, out title);
            var model = new CategoryViewModel
            {
                Title = title,
                LeftMenu = GetLeftMenu(),
                CoursesHot = courseHot,
                CategoryRouter = category
            };
            return View(model);
        }

        [HttpPost]
        [Route("category/getcourses")]
        public JsonResult GetCourses(int pageIndex, int pageSize, string category)
        {
            var courses = _categoryService.GetCourses(category, 1, 5);
            return courses.Result.Any()
                ? Json(new { isSuccess = true, data = courses })
                : Json(new { isSuccess = false });
        }
    }
}