using System;
using System.Linq;
using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using MvcCornerstone.Data;
using MvcCornerstone.Services;

namespace Gds.VideoFrontend.Domain.Implement
{
    public class RatingService : GenericService<CategoryRating, DbContextBase>, IRatingService
    {
        public RatingService(IEntityRepository<CategoryRating> repository) : base(repository)
        {
        }

        public double GetRatingLevel(int categoryTypeId)
        {
            var query = Repository.DoQuery<DbContextBase>(x => x.CategoryTypeId == categoryTypeId)
                                  .Select(x => x.Level).Average();
            return query >= 4 ? query : 4;
        }

        public int SetRatingLevel(int level, int categoryTypeId)
        {
            throw new NotImplementedException();
        }
    }
}