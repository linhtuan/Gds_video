using System.Collections.Generic;
using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using Gds.VideoFrontend.Models;
using MvcCornerstone.Services;

namespace Gds.VideoFrontend.Domain
{
    public interface ICourseService : IGenericService<CategoryTypes, DbContextBase>
    {
        List<CoursesViewModel> GetSuggestCourses(int categoryTypeId);

        CourseDetailViewModel GetCourseDetail(string courseRouter);

        Author GetAuthor(int authorId);
    }
}
