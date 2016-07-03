using System;
using System.Collections.Generic;
using System.Linq;
using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using Gds.ServiceModel.BackEndModel;
using MvcCornerstone.Data;
using MvcCornerstone.Services;

namespace GdsVideoBackend.Domain.Implement
{
    public class CategorysService : GenericService<Categorys, DbContextBase>, ICategorysService
    {
        public CategorysService(IEntityRepository<Categorys> repository) : base(repository)
        {
        }

        public List<Categorys> GetCategory()
        {
            var result = Repository.DoQuery<DbContextBase>(x => x.Status == 1).ToList();
            return result;
        }

        public bool AddCategory(CategoryModel model)
        {
            try
            {
                var category = new Categorys
                {
                    CategoryName = model.CategoryName,
                    CategoryDetail = model.CategoryDetail,
                    CreatedDate = DateTime.UtcNow,
                    Status = 1
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
                var category = new Categorys
                {
                    CategoryId = model.CategoryId,
                    CategoryName = model.CategoryName,
                    CategoryDetail = model.CategoryDetail,
                    CreatedDate = DateTime.UtcNow,
                    Status = 1
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