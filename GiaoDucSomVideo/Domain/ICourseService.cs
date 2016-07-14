using System.Collections.Generic;
using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using GiaoDucSomVideo.Models;
using MvcCornerstone.Services;

namespace GiaoDucSomVideo.Domain
{
    public interface ICourseService : IGenericService<CategoryTypes, DbContextBase>
    {
        List<CoursesViewModel> GetSuggestCourses(int categoryTypeId);

        CourseDetailViewModel GetCourseDetail(string courseRouter);
    }
}
