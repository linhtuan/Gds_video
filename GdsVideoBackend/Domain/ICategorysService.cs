using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using Gds.ServiceModel.BackEndModel;
using Gds.ServiceModel.ControlObject;
using MvcCornerstone.Services;

namespace GdsVideoBackend.Domain
{
    public interface ICategorysService : IGenericService<Categorys, DbContextBase>
    {
        PagingResultModel<Categorys> GetCategory(int pageIndex, int pageSize);

        bool AddCategory(CategoryModel model);

        bool EditCategory(CategoryModel model);

        bool DeleteCategory(int categoryId);
    }
}