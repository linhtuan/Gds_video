using System;
using System.Linq;
using System.Web.Mvc;
using Gds.Setting.Cryptography;
using Gds.VideoFrontend.Domain;
using Gds.VideoFrontend.Infrastructure;
using Gds.Setting.Enum;
using Gds.Setting;

namespace Gds.VideoFrontend.Controllers
{
    public class CourseController : BaseController
    {
        private readonly ICourseService _courseService;
        private readonly IContactService _contactService;

        public CourseController(
            ICourseService courseService,
            IContactService contactService)
        {
            _courseService = courseService;
            _contactService = contactService;
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
            var contactId = ContactId;
            if (!contactId.HasValue)
                return RedirectToAction("Index", "Home");

            if (_contactService.ContactPaymentCategory(contactId.Value, cateType))
                return RedirectToAction("Index", "Home");

            var model = _courseService.GetLearning(cateType);
            return View(model);
        }

        [Route("course/{cateType?}/lecture/{index?}")]
        public ActionResult Lecture(string cateType, int index)
        {
            var contactId = ContactId;
            if (!contactId.HasValue)
                return RedirectToAction("Index", "Home");

            if (_contactService.ContactPaymentCategory(contactId.Value, cateType))
                return RedirectToAction("Index", "Home");

            var model = _courseService.GetLecture(cateType, index);
            if (string.IsNullOrEmpty(model.CourseId)) return null;

            return View(model);
        }

        #region GET

        [Route("course/getcomment/learning")]
        public JsonResult GetCommentLearning(string categoryTypeId, int index)
        {
            var cateTypeId = Convert.ToInt32(CryptographyHelper.Decrypt(categoryTypeId));
            var result = _courseService.GetComments(cateTypeId, (int)CommentTypeEnum.CategoryType, index);
            return Json(null);
        }

        [Route("course/getcomment/lecture")]
        public JsonResult GetCommentlecture(string categoryDetailId, int index)
        {
            var cateTypeId = Convert.ToInt32(CryptographyHelper.Decrypt(categoryDetailId));
            var result = _courseService.GetComments(cateTypeId, (int)CommentTypeEnum.CategoryType, index);
            return Json(null);
        }

        #endregion

        #region Post

        [HttpPost]
        [Route("course/lectures/info")]
        public JsonResult GetLectures(bool hasUrl, string categoryTypeId, string urlRouter)
        {
            var cateTypeId = Convert.ToInt32(CryptographyHelper.Decrypt(categoryTypeId));
            var result = _courseService.GetLectures(cateTypeId, hasUrl, urlRouter);
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
        public JsonResult AddCommentForLearning(string categoryTypeId, string comment)
        {
            var contactId = ContactId;
            if (!contactId.HasValue)
                return Json(new { isSuccess = false });
            var cateTypeId = Convert.ToInt32(CryptographyHelper.Decrypt(categoryTypeId));
            var contactName = (string)SessionManager.GetSessionObject(SessionObjectEnum.ContactFullName);
            var result = _courseService.AddComment(cateTypeId, contactId.Value, contactName, comment, (int)CommentTypeEnum.CategoryType);
            return Json(new { isSuccess = true, data = result });
        }

        [HttpPost]
        [Route("course/addcomment/lecture")]
        public JsonResult AddCommentForLecture(string categoryDetailId, string comment)
        {
            var contactId = ContactId;
            if (!contactId.HasValue)
                return Json(new { isSuccess = false });
            var cateDetailId = Convert.ToInt32(CryptographyHelper.Decrypt(categoryDetailId));
            var contactName = (string)SessionManager.GetSessionObject(SessionObjectEnum.ContactFullName);
            var result = _courseService.AddComment(cateDetailId, contactId.Value, contactName, comment, (int)CommentTypeEnum.CategoryType);
            return Json(new { isSuccess = true, data = result });
        }

        #endregion
    }
}