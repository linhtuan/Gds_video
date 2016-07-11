using System.Collections.Generic;
using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using Gds.ServiceModel.BackEndModel;
using Gds.ServiceModel.ControlObject;
using GdsVideoBackend.Models;
using MvcCornerstone.Services;

namespace GdsVideoBackend.Domain
{
    public interface ICategoryTypeService : IGenericService<CategoryTypes, DbContextBase>
    {
        PagingResultModel<CategoryTypesModel> GetParentCategoryTypes(int categoryId, int pageIndex, int pageSize);

        PagingResultModel<CategoryTypesModel> GetCategoryTypesByCategoryId(int categoryId, int pageIndex, int pageSize);

        bool InsertCategoryType(CategoryTypeViewModel model, string fileName, out int categoryTypeId);

        bool UpdateCategoryType(CategoryTypeViewModel model);

        bool DeleteCategoryType(int categoryTypeId);

        List<CategoryTypePrice> GetPrices();

        Dictionary<int, string> GetParentCategoryType();
    }
}
