using System;
using System.Collections.Generic;
using System.Linq;
using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using Gds.ServiceModel.BackEndModel;
using Gds.ServiceModel.ControlObject;
using GdsVideoBackend.Models;
using MvcCornerstone.Data;
using MvcCornerstone.Generic.Paging;
using MvcCornerstone.Services;

namespace GdsVideoBackend.Domain.Implement
{
    public class CategoryTypeService : GenericService<CategoryTypes, DbContextBase>, ICategoryTypeService
    {
        private readonly IEntityRepository<CategoryTypePrice> _priceRepository;

        public CategoryTypeService(IEntityRepository<CategoryTypes> repository, 
            IEntityRepository<CategoryTypePrice> priceRepository) : base(repository)
        {
            _priceRepository = priceRepository;
        }

        public PagingResultModel<CategoryTypesModel> GetParentCategoryTypes(int categoryId, int pageIndex, int pageSize)
        {
            try
            {
                var query = Repository.DoQuery<DbContextBase>(x => x.CategoryId == categoryId && x.CategoryTypeParentId == 0)
                     .Join(_priceRepository.Table<DbContextBase>(), x => x.CategoryTypePriceId, y => y.CategoryTypePriceId,
                        (cat, price) => new { cat, price.Price, price.SalePrice, price.SaleTime }).OrderByDescending(x => x.cat.CreatedDate);
                var totalCount = query.Count();
                var dataResult = query.ToPagedQueryable(pageIndex, pageSize, totalCount);
                var results = new List<CategoryTypesModel>();

                foreach (var item in dataResult)
                {
                    results.Add(new CategoryTypesModel
                    {
                        CategoryId = item.cat.CategoryTypeId,
                        ParentId = item.cat.CategoryTypeId,
                        ParentName = item.cat.CategoryTypeName,
                        ChildrenId = item.cat.CategoryTypeParentId,
                        ChildrenName = item.cat.CategoryTypeName,
                        Content = item.cat.Content,
                        DateTime = item.cat.CreatedDate.HasValue ? item.cat.CreatedDate.Value.ToString("dd/MM/yyyy") : string.Empty,
                        Price = item.Price.Value
                    });
                }
                var resultPaging = new PagingResultModel<CategoryTypesModel>
                {
                    Result = results,
                    PageIndex = dataResult.PageIndex,
                    PageSize = dataResult.PageSize,
                    ItemCount = dataResult.ItemCount,
                    PageCount = dataResult.PageCount
                };

                return resultPaging;
            }
            catch (Exception ex)
            {
                return new PagingResultModel<CategoryTypesModel>();
            }
        }

        public PagingResultModel<CategoryTypesModel> GetCategoryTypesByCategoryId(int categoryId, int pageIndex, int pageSize)
        {
            try
            {
                var query = Repository.DoQuery<DbContextBase>(x => x.CategoryId == categoryId && x.CategoryTypeParentId != 0)
                                  .OrderByDescending(x => x.CreatedDate)
                                  .ThenBy(x => x.CategoryTypeParentId);
                var totalCount = query.Count();
                var dataResult = query.ToPagedQueryable(pageIndex, pageSize, totalCount);
                var parentIds = dataResult.Select(x => x.CategoryTypeParentId).Distinct().ToList();

                var parentQuery = Repository.DoQuery<DbContextBase>(x => parentIds.Contains(x.CategoryTypeId))
                    .Join(_priceRepository.Table<DbContextBase>(), x => x.CategoryTypePriceId, y => y.CategoryTypePriceId,
                        (x, y) => new { x.CategoryTypeId, x.CategoryTypeName, y.Price, y.SalePrice, y.SaleTime }).ToList();

                var results = new List<CategoryTypesModel>();

                foreach (var item in dataResult)
                {
                    var thisParent = parentQuery.FirstOrDefault(y => y.CategoryTypeId == item.CategoryTypeParentId);
                    if (thisParent == null) continue;
                    results.Add(new CategoryTypesModel
                    {
                        CategoryId = thisParent.CategoryTypeId,
                        ParentId = thisParent.CategoryTypeId,
                        ParentName = thisParent.CategoryTypeName,
                        ChildrenId = item.CategoryTypeParentId,
                        ChildrenName = item.CategoryTypeName,
                        Content = item.Content,
                        DateTime = item.CreatedDate.HasValue ? item.CreatedDate.Value.ToString("dd/MM/yyyy") : string.Empty,
                        Price = thisParent.Price.Value
                    });
                }
                var resultPaging = new PagingResultModel<CategoryTypesModel>
                {
                    Result = results,
                    PageIndex = dataResult.PageIndex,
                    PageSize = dataResult.PageSize,
                    ItemCount = dataResult.ItemCount,
                    PageCount = dataResult.PageCount
                };

                return resultPaging;
            }
            catch (Exception ex)
            {
                return new PagingResultModel<CategoryTypesModel>();
            }
        }

        public bool InsertCategoryType(CategoryTypeViewModel model)
        {
            try
            {
                var categoryType = new CategoryTypes
                {
                    CategoryId = model.CategoryId,
                    CategoryTypeName = model.CategoryTypeName,
                    Content = model.Content,
                    CreatedDate = DateTime.UtcNow
                };
                if (model.ParentId != 0)
                {
                    categoryType.CategoryTypeParentId = model.ParentId;
                }
                else
                {
                    categoryType.CategoryTypePriceId = model.CategoryTypePriceId;
                }
                Repository.Insert<DbContextBase>(categoryType);
                Repository.Commit<DbContextBase>();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateCategoryType(CategoryTypesModel model)
        {
            try
            {
                var categoryType = new CategoryTypes
                {
                    CategoryTypeId = model.ChildrenId,
                    CategoryTypeParentId = model.ParentId,
                    CategoryId = model.CategoryId,
                    CategoryTypeName = model.ChildrenName,
                    ContentType = null,
                    Content = model.Content,
                    CreatedDate = DateTime.UtcNow,
                    CategoryTypePriceId = model.PriceId
                };
                Repository.Update<DbContextBase>(categoryType);
                Repository.Commit<DbContextBase>();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCategoryType(int categoryTypeId)
        {
            try
            {
                Repository.DeleteMany<DbContextBase>(x => x.CategoryTypeId == categoryTypeId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<CategoryTypePrice> GetPrices()
        {
            return _priceRepository.Table<DbContextBase>().ToList();
        }

        public Dictionary<int, string> GetParentCategoryType()
        {
            return Repository.DoQuery<DbContextBase>(x => x.CategoryTypeParentId == 0 && x.Status == 1)
                .Select(x => new {x.CategoryTypeId, x.CategoryTypeName})
                .ToList()
                .ToDictionary(x => x.CategoryTypeId, x => x.CategoryTypeName);
        }
    }
}