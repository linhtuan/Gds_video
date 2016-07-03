using System.Collections.Generic;
using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using Gds.ServiceModel.BackEndModel;
using MvcCornerstone.Services;

namespace GdsVideoBackend.Domain
{
    public interface ICategorysService : IGenericService<Categorys, DbContextBase>
    {
        List<Categorys> GetCategory();

        bool AddCategory(CategoryModel model);

        bool EditCategory(CategoryModel model);

        bool DeleteCategory(int categoryId);
    }
}