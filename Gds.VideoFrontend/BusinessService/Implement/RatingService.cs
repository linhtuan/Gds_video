using System;
using System.Collections.Generic;
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

        public Dictionary<int, double> GetRatingLevels(List<int> categoryTypeIds)
        {
            var query = Repository.DoQuery<DbContextBase>(x => categoryTypeIds.Contains(x.CategoryTypeId))
                                     .Select(x => new
                                     {
                                         x.CategoryTypeId,
                                         x.Level
                                     }).ToList();
            var dic = new Dictionary<int, double>();
            foreach (var item in categoryTypeIds)
            {
                var levelById = query.Where(x => x.CategoryTypeId == item).ToList();
                var level = levelById.Any() ? levelById.Average(x=>x.Level) : 4;
                dic.Add(item, level);
            }
            return dic;
        }

        public int SetRatingLevel(int level, int categoryTypeId)
        {
            throw new NotImplementedException();
        }
    }
}