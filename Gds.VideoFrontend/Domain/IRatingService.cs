using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using MvcCornerstone.Services;

namespace Gds.VideoFrontend.Domain
{
    public interface IRatingService : IGenericService<CategoryRating, DbContextBase>
    {
        double GetRatingLevel(int categoryTypeId);

        int SetRatingLevel(int level, int categoryTypeId);
    }
}
