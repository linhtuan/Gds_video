using System.Linq;
using System.Web.Mvc;
using Gds.VideoFrontend.Domain;
using Gds.VideoFrontend.Infrastructure;
using Gds.VideoFrontend.Models;

namespace Gds.VideoFrontend.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: Category
        [Route("category/{categorytype?}")]
        public ActionResult Index(string categorytype)
        {
            string title;
            var courseHot = _categoryService.GetCoursesHot(categorytype, out title);
            var model = new CategoryViewModel
            {
                Title = title,
                LeftMenu = GetLeftMenu(),
                CoursesHot = courseHot,
                CategoryRouter = categorytype
            };
            return View(model);
        }

        [Route("category/course")]
        public ActionResult Courses()
        {
            return View();
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