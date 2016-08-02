using System;
using System.Linq;
using System.Web.Mvc;
using Gds.Setting.Cryptography;
using Gds.Frontend.Domain;

namespace Gds.Frontend.Controllers
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
            model.CourseRouter = categorytype;
            return View(model);
        }

        [Route("course/{categorytype?}/learning")]
        public ActionResult Learning(string categorytype)
        {
            //check user da mua goi chua

            var model = _courseService.GetLearning(categorytype);
            return View(model);
        }

        [Route("course/{categorytype?}/lecture/{index?}")]
        public ActionResult Lecture(string categorytype, int index)
        {
            //check user da mua goi chua
            var model = _courseService.GetLecture(categorytype, index);
            if (string.IsNullOrEmpty(model.CourseId)) return null;

            return View(model);
        }


        #region GET

        [Route("course/getcomment/learning")]
        public JsonResult GetCommentLearning(string courseId)
        {
            return Json(null);
        }

        [Route("course/getcomment/lecture")]
        public JsonResult GetCommentlecture(string learningId)
        {
            return Json(null);
        }

        #endregion

        #region Post

        [HttpPost]
        [Route("course/lectures/info")]
        public JsonResult GetLectures(bool hasUrl, string courseId, string urlRouter)
        {
            //check user da mua goi chua
            var categoryTypeId = Convert.ToInt32(CryptographyHelper.Decrypt(courseId));
            var result = _courseService.GetLectures(categoryTypeId, hasUrl, urlRouter);
            return result.Any()
                ? Json(new { isSuccess = true, data = result })
                : Json(new { isSuccess = false });
        }

        [HttpPost]
        [Route("course/suggest/info")]
        public JsonResult GetSuggestCourse(string courseId)
        {
            var categoryTypeId = Convert.ToInt32(CryptographyHelper.Decrypt(courseId));

            var result = _courseService.GetSuggestCourses(categoryTypeId);
            return result.Any()
                ? Json(new { isSuccess = true, data = result })
                : Json(new { isSuccess = false });
        }

        [HttpPost]
        [Route("course/getauthor/info")]
        public JsonResult GetAuthorDetail(string authorId)
        {
            var categoryTypeId = Convert.ToInt32(CryptographyHelper.Decrypt(authorId));
            var result = _courseService.GetAuthor(categoryTypeId);
            return result != null
                ? Json(new { isSuccess = true, data = result })
                : Json(new { isSuccess = false });
        }

        [HttpPost]
        [Route("course/addcomment/learning")]
        public JsonResult AddCommentForLearning(string courseId, string comment)
        {
            return null;
        }

        [HttpPost]
        [Route("course/addcomment/lecture")]
        public JsonResult AddCommentForLecture(string lectureId, int courseId, string comment)
        {
            return null;
        }

        #endregion
    }
}