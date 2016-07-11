using System.Collections.Generic;
using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using GiaoDucSomVideo.Models;
using MvcCornerstone.Services;

namespace GiaoDucSomVideo.Domain
{
    public interface ICategoryService : IGenericService<Categorys, DbContextBase>
    {
        List<CategoryHomeViewModel> GetCategoryHomePage();
    }
}
