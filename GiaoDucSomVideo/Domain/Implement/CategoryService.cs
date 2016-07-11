using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using GiaoDucSomVideo.Models;
using MvcCornerstone.Data;
using MvcCornerstone.Services;

namespace GiaoDucSomVideo.Domain.Implement
{
    public class CategoryService: GenericService<Categorys, DbContextBase>, ICategoryService
    {
        private readonly IEntityRepository<CategoryTypes> _categoryTypeRepository;

        public CategoryService(IEntityRepository<Categorys> repository, 
            IEntityRepository<CategoryTypes> categoryTypeRepository) : base(repository)
        {
            _categoryTypeRepository = categoryTypeRepository;
        }

        public List<CategoryHomeViewModel> GetCategoryHomePage()
        {
            var category = Repository.DoQuery<DbContextBase>(x => x.Status == 1).ToList();
            var categoryIds = category.Select(x=>x.CategoryId);
            var query = _categoryTypeRepository.DoQuery<DbContextBase>(x => categoryIds.Contains(x.CategoryId) && x.CategoryTypeParentId == 0)
                .GroupBy(x => x.CategoryId)
                .SelectMany(x => x.OrderBy(y => y.CreatedDate).Take(4)).ToList()
                .Select(x=> new CategoryTypeHomeViewModel
                {
                    CategoryId = x.CategoryId,
                    CategoryTypeId = x.CategoryTypeId,
                    CategoryTypeName = x.CategoryTypeName,
                    CategoryTypeUrl = string.Empty,
                    ThumbnailImage = Convert.ToBase64String(File.ReadAllBytes(x.ThumbnailImage)),
                    MimeTypeImage = Regex.Replace(Path.GetExtension(x.ThumbnailImage), @"\W", "")
                }).ToList();

            var result = category.Where(x => query.Select(y => y.CategoryId).Contains(x.CategoryId)).Select(x => new CategoryHomeViewModel
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                CategoryTypes = query.Where(y => y.CategoryId == x.CategoryId).ToList()
            }).ToList();

            return result;
        }
    }
}