using System;
using System.Linq;
using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using Gds.VideoFrontend.Domain;
using MvcCornerstone.Data;
using MvcCornerstone.Services;

namespace Gds.VideoFrontend.BusinessService.Implement
{
    public class RatingService : GenericService<CategoryRating, DbContextBase>, IRatingService
    {
        public RatingService(IEntityRepository<CategoryRating> repository) : base(repository)
        {
        }

        public double GetRatingLevel(int categoryTypeId)
        {
            var query = Repository.DoQuery<DbContextBase>(x => x.CategoryTypeId == categoryTypeId)
                                  .Select(x => x.Level);
            return query.Any() ? query.Average() : 4;
        }

        public int SetRatingLevel(int level, int categoryTypeId)
        {
            throw new NotImplementedException();
        }
    }
}