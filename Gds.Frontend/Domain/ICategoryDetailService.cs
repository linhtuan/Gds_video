using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using MvcCornerstone.Services;

namespace Gds.Frontend.Domain
{
    public interface ICategoryDetailService : IGenericService<CategoryDetails, DbContextBase>
    {
        string GetVideos(int physicalFileId);
    }
}