using System;
using System.Linq;
using System.Text.RegularExpressions;
using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using Gds.ServiceModel.BackEndModel;
using Gds.ServiceModel.ControlObject;
using MvcCornerstone.Data;
using MvcCornerstone.Extension;
using MvcCornerstone.Generic.Paging;
using MvcCornerstone.Services;

namespace GdsVideoBackend.Domain.Implement
{
    public class CategorysService : GenericService<Categorys, DbContextBase>, ICategorysService
    {
        public CategorysService(IEntityRepository<Categorys> repository) : base(repository)
        {
        }

        public PagingResultModel<Categorys> GetCategory(int pageIndex, int pageSize)
        {
            var query = Repository.DoQuery<DbContextBase>(x => x.Status == 1).OrderByDescending(x => x.CreatedDate);
            var totalCount = query.Count();
            var dataResult = query.ToPagedQueryable(pageIndex, pageSize, totalCount);
            
            var resultPaging = new PagingResultModel<Categorys>
            {
                Result = dataResult,
                PageIndex = dataResult.PageIndex,
                PageSize = dataResult.PageSize,
                ItemCount = dataResult.ItemCount,
                PageCount = dataResult.PageCount
            };
            return resultPaging;
        }

        public bool AddCategory(CategoryModel model)
        {
            try
            {
                var urlRouter = model.CategoryName.RemoveDiacritics();
                urlRouter = Regex.Replace(urlRouter, @"\W", "-").ToLower();
                var category = new Categorys
                {
                    CategoryName = model.CategoryName,
                    CategoryDetail = model.CategoryDetail,
                    CreatedDate = DateTime.UtcNow,
                    Status = 1,
                    UrlRouter = urlRouter
                };
                Repository.Insert<DbContextBase>(category);
                Repository.Commit<DbContextBase>();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditCategory(CategoryModel model)
        {
            try
            {
                var urlRouter = model.CategoryName.RemoveDiacritics();
                urlRouter = Regex.Replace(urlRouter, @"\W", "-").ToLower();
                var category = new Categorys
                {
                    CategoryId = model.CategoryId,
                    CategoryName = model.CategoryName,
                    CategoryDetail = model.CategoryDetail,
                    CreatedDate = DateTime.UtcNow,
                    Status = 1,
                    UrlRouter = urlRouter
                };
                Repository.Update<DbContextBase>(category);
                Repository.Commit<DbContextBase>();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCategory(int categoryId)
        {
            try
            {
                Repository.UpdateMany<DbContextBase>(x => x.CategoryId == categoryId, x => new Categorys {Status = 0});
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}