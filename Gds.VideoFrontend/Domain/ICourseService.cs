using System.Collections.Generic;
using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using Gds.VideoFrontend.Models;
using MvcCornerstone.Services;

namespace Gds.VideoFrontend.Domain
{
    public interface ICourseService : IGenericService<CategoryTypes, DbContextBase>
    {
        CategoryTypes GetCategoryType(string courseRouter);

        List<CoursesViewModel> GetSuggestCourses(int categoryTypeId);

        CourseDetailViewModel GetCourseDetail(string courseRouter);

        Author GetAuthor(int authorId);

        CategoryDetails GetCategoryDetails(string courseRouter, int index);

        List<LectureGroupViewModel> GetLectures(int categoryTypeId, bool hasUrl, string urlRouter);

        LearningViewModel GetLearning(string courseRouter);

        LectureViewModel GetLecture(string courseRouter, int index);
    }
}
