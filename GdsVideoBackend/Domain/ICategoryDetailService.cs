using System;
using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using Gds.ServiceModel.BackEndModel;
using Gds.ServiceModel.ControlObject;
using MvcCornerstone.Services;

namespace GdsVideoBackend.Domain
{
    public interface ICategoryDetailService : IGenericService<CategoryDetails, DbContextBase>
    {
        PagingResultModel<CategoryDetailModel> GetCategoryDetails(int? categoryTypeId, int pageIndex, int pageSize);

        int Insert(CategoryDetailModel model);

        int Update(CategoryDetailModel model);

        bool Delete(int categoryDetailId);

        int GetCategoryId(int categoryTypeId);

        bool UpdateFileInfo(PhysicalFiles model, int? categoryDetailId);
    }
}