using System.Collections.Generic;
using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using Gds.ServiceModel.ControlObject;
using GiaoDucSomVideo.Models;
using MvcCornerstone.Services;

namespace GiaoDucSomVideo.Domain
{
    public interface ICategoryService : IGenericService<Categorys, DbContextBase>
    {
        List<CategoryHomeViewModel> GetCategoryHomePage();

        List<CategoryLeftMenuViewModel> GetLeftMenu();

        PagingResultModel<CoursesViewModel> GetCourses(string categoryName, int pageIndex, int pageSize);

        List<CoursesViewModel> GetCoursesHot(string categoryName, out string title);
    }
}
