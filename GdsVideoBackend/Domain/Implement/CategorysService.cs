using System;
using System.Collections.Generic;
using System.Linq;
using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using MvcCornerstone.Data;
using MvcCornerstone.Services;

namespace GdsVideoBackend.Domain.Implement
{
    public class CategorysService : GenericService<Categorys, DbContextBase>, ICategorysService
    {
        private readonly IEntityRepository<CategoryDetails> _categoryDetailRepository;

        public CategorysService(IEntityRepository<Categorys> repository, 
            IEntityRepository<CategoryDetails> categoryDetailRepository) : base(repository)
        {
            _categoryDetailRepository = categoryDetailRepository;
        }

        public List<Categorys> GetCategory()
        {
            var test = _categoryDetailRepository.Table<DbContextBase>().ToList();
            return Repository.Table<DbContextBase>().ToList();
        }
    }
}