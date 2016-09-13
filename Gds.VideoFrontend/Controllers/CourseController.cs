using System;
using System.Linq;
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
        [Route("course/{cateType?}")]
        public ActionResult Index(string cateType)
        {
            var model = _courseService.GetCourseDetail(cateType);
            model.CourseRouter = cateType;
            return View(model);
        }

        [Route("course/{cateType?}/learning")]
        public ActionResult Learning(string cateType)
        {
            //check user da mua goi chua

            var model = _courseService.GetLearning(cateType);
            return View(model);
        }

        [Route("course/{cateType?}/lecture/{index?}")]
        public ActionResult Lecture(string cateType, int index)
        {
            //check user da mua goi chua
            var model = _courseService.GetLecture(cateType, index);
            if (string.IsNullOrEmpty(model.CourseId)) return null;

            return View(model);
        }

        #region GET

        [Route("course/getcomment/learning")]
        public JsonResult GetCommentLearning(string cateId)
        {
            return Json(null);
        }

        [Route("course/getcomment/lecture")]
        public JsonResult GetCommentlecture(string categoryTypeId)
        {
            return Json(null);
        }

        #endregion

        #region Post

        [HttpPost]
        [Route("course/lectures/info")]
        public JsonResult GetLectures(bool hasUrl, string cateId, string urlRouter)
        {
            //check user da mua goi chua
            var categoryTypeId = Convert.ToInt32(CryptographyHelper.Decrypt(cateId));
            var result = _courseService.GetLectures(categoryTypeId, hasUrl, urlRouter);
            return result.Any()
                ? Json(new { isSuccess = true, data = result })
                : Json(new { isSuccess = false });
        }

        [HttpPost]
        [Route("course/suggest/info")]
        public JsonResult GetSuggestCourse(string cateId)
        {
            var categoryTypeId = Convert.ToInt32(CryptographyHelper.Decrypt(cateId));

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
        public JsonResult AddCommentForLearning(string cateId, string comment)
        {
            return null;
        }

        [HttpPost]
        [Route("course/addcomment/lecture")]
        public JsonResult AddCommentForLecture(string cateTypeId, int cateId, string comment)
        {
            return null;
        }

        #endregion
    }
}