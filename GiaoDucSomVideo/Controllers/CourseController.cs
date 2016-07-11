using System.Web.Helpers;
using System.Web.Mvc;

namespace GiaoDucSomVideo.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetSuggestCourse()
        {
            return Json(null);
        }

        public JsonResult GetDetailCourses()
        {
            return Json(null);
        }

        public JsonResult GetAuthorDetail()
        {
            return Json(null);
        }

        public JsonResult GetCommentUser()
        {
            return Json(null);
        }
    }
}