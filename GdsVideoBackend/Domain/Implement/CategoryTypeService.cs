using System;
using System.Collections.Generic;
using System.Linq;
using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using Gds.ServiceModel.BackEndModel;
using Gds.ServiceModel.ControlObject;
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

        protected override IOrderedQueryable<CategoryTypes> ApplyDefaultSort(IQueryable<CategoryTypes> queryable)
        {
            throw new NotImplementedException();
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
    }
}