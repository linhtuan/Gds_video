using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using Gds.ServiceModel.BackEndModel;
using Gds.ServiceModel.ControlObject;
using MvcCornerstone.Services;

namespace GdsVideoBackend.Domain
{
    public interface ICategoryTypeService : IGenericService<CategoryTypes, DbContextBase>
    {
        PagingResultModel<CategoryTypesModel> GetCategoryTypesByCategoryId(int categoryId, int pageIndex, int pageSize);
    }
}
