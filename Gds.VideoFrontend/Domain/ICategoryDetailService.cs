using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using MvcCornerstone.Services;

namespace Gds.VideoFrontend.Domain
{
    public interface ICategoryDetailService : IGenericService<CategoryDetails, DbContextBase>
    {
        string GetVideos(int physicalFileId);
    }
}