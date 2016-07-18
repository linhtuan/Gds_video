using System;
using System.Web.Mvc;
using Gds.Setting.Cryptography;
using Gds.VideoFrontend.Domain;

namespace Gds.VideoFrontend.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: Course
        [Route("course/{categorytype?}")]
        public ActionResult Index(string categorytype)
        {
            var model = _courseService.GetCourseDetail(categorytype);
            return View(model);
        }

        [Route("course/{categorytype?}/learning")]
        public ActionResult Learning(string categorytype)
        {
            var model = _courseService.GetCourseDetail(categorytype);
            return View(model);
        }

        [Route("course/{categorytype?}/lecture")]
        public ActionResult Lecture(string categorytype)
        {
            var model = _courseService.GetCourseDetail(categorytype);
            return View(model);
        }

        public JsonResult GetSuggestCourse(string courseId)
        {
            var categoryTypeId = Convert.ToInt32(CryptographyHelper.Decrypt(courseId));
            return Json(null);
        }

        public JsonResult GetMoreInfoCourse(string courseId)
        {
            var categoryTypeId = Convert.ToInt32(CryptographyHelper.Decrypt(courseId));
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