using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using Gds.ServiceModel.BackEndModel;
using Gds.ServiceModel.ControlObject;
using Gds.Setting;
using Gds.Setting.Enum;
using GdsVideoBackend.Models;
using MvcCornerstone.Data;
using MvcCornerstone.Extension;
using MvcCornerstone.Generic.Paging;
using MvcCornerstone.Services;

namespace GdsVideoBackend.Domain.Implement
{
    public class CategoryTypeService : GenericService<CategoryTypes, DbContextBase>, ICategoryTypeService
    {
        private readonly IEntityRepository<CategoryTypePrice> _priceRepository;

        private readonly IEntityRepository<AgeOrder> _ageOrderRepository;

        private readonly IEntityRepository<Author> _authorRepository;

        public CategoryTypeService(IEntityRepository<CategoryTypes> repository, 
            IEntityRepository<CategoryTypePrice> priceRepository, 
            IEntityRepository<AgeOrder> ageOrderRepository, 
            IEntityRepository<Author> authorRepository) : base(repository)
        {
            _priceRepository = priceRepository;
            _ageOrderRepository = ageOrderRepository;
            _authorRepository = authorRepository;
        }

        public PagingResultModel<CategoryTypesModel> GetParentCategoryTypes(int categoryId, int pageIndex, int pageSize)
        {
            try
            {
                var query = Repository.DoQuery<DbContextBase>(x => x.CategoryId == categoryId && x.CategoryTypeParentId == 0)
                     .Join(_priceRepository.Table<DbContextBase>(), x => x.CategoryTypePriceId, y => y.CategoryTypePriceId,
                        (cat, price) => new { cat, price.CategoryTypePriceId, price.Price, price.SalePrice, price.SaleTime }).OrderByDescending(x => x.cat.CreatedDate);
                var totalCount = query.Count();
                var dataResult = query.ToPagedQueryable(pageIndex, pageSize, totalCount);
                var ageOrderIds = query.Select(x => x.cat.AgeOrderId).Distinct().ToList();
                var authorIds = query.Select(x => x.cat.AuthorId).Distinct().ToList();
                var ageOrder = _ageOrderRepository.DoQuery<DbContextBase>(x => ageOrderIds.Contains(x.AgeOrderId)).ToList();
                var authors = _authorRepository.DoQuery<DbContextBase>(x => authorIds.Contains(x.AuthorId)).ToList();
                var results = dataResult.Select(item => new CategoryTypesModel
                {
                    CategoryId = item.cat.CategoryId,
                    ChildrenId = item.cat.CategoryTypeId,
                    ChildrenName = item.cat.CategoryTypeName,
                    Content = item.cat.Content,
                    DateTime = item.cat.CreatedDate.HasValue ? item.cat.CreatedDate.Value.ToString("dd/MM/yyyy") : string.Empty,
                    Price = item.Price.Value,
                    PriceId = item.CategoryTypePriceId,
                    ThumbnailImage = !string.IsNullOrEmpty(item.cat.ThumbnailImage)
                        ? Convert.ToBase64String(File.ReadAllBytes(item.cat.ThumbnailImage))
                        : string.Empty,
                    MimeTypeImage = !string.IsNullOrEmpty(item.cat.ThumbnailImage)
                        ? Regex.Replace(Path.GetExtension(item.cat.ThumbnailImage), @"\W", "")
                        : string.Empty,
                    AgeOrderId = item.cat.AgeOrderId,
                    AgeOrderName = item.cat.AgeOrderId.HasValue
                        ? ageOrder.First(x => x.AgeOrderId == item.cat.AgeOrderId).AgeOrderName
                        : string.Empty,
                    CategoryTpyeOrder = item.cat.GlobalSortOrder.HasValue ? item.cat.GlobalSortOrder.Value : 0,
                    AuthorId = item.cat.AuthorId.HasValue ? item.cat.AuthorId.Value : 0,
                    AuthorName = item.cat.AuthorId.HasValue
                        ? authors.First(x => x.AuthorId == item.cat.AuthorId.Value).AuthorName
                        : string.Empty
                }).ToList();

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
                        ParentId = item.CategoryTypeParentId,
                        ParentName = thisParent.CategoryTypeName,
                        ChildrenId = item.CategoryTypeId,
                        ChildrenName = item.CategoryTypeName,
                        Content = item.Content,
                        DateTime = item.CreatedDate.HasValue ? item.CreatedDate.Value.ToString("dd/MM/yyyy") : string.Empty,
                        Price = thisParent.Price.Value,
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

        public bool InsertCategoryType(CategoryTypeViewModel model, string fileName, out int categoryTypeId)
        {
            try
            {
                var urlRouter = model.CategoryTypeName.RemoveDiacritics();
                urlRouter = Regex.Replace(urlRouter, @"\W", "-").ToLower();
                var categoryType = new CategoryTypes
                {
                    CategoryId = model.CategoryId,
                    CategoryTypeName = model.CategoryTypeName,
                    Content = model.Content,
                    CreatedDate = DateTime.UtcNow,
                    Status = 1,
                    UrlRouter = urlRouter,
                    AgeOrderId = model.AgeOrderId,
                    GlobalSortOrder = model.CategoryTypeOrderId == 0
                        ? (int) CategoryTypeOrderEnum.Normal
                        : model.CategoryTypeOrderId,
                    AuthorId = model.AuthorId
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
                if (categoryType.CategoryTypeParentId == 0)
                {
                    var uploadFilesDir = string.Format(@"{0}\thumbnailImage\{1}\{2}", AppConfig.UploadFolder, model.CategoryId, categoryType.CategoryTypeId);
                    Repository.UpdateMany<DbContextBase>(x => x.CategoryTypeId == categoryType.CategoryTypeId, x => new CategoryTypes
                    {
                        ThumbnailImage = string.Format("{0}\\{1}", uploadFilesDir, fileName)
                    });
                }
                categoryTypeId = categoryType.CategoryTypeId;
                return true;
            }
            catch (Exception ex)
            {
                categoryTypeId = 0;
                return false;
            }
        }

        public bool UpdateCategoryType(CategoryTypeViewModel model)
        {
            try
            {
                var urlRouter = model.CategoryTypeName.RemoveDiacritics();
                urlRouter = Regex.Replace(urlRouter, @"\W", "-").ToLower();
                Repository.UpdateMany<DbContextBase>(x => x.CategoryTypeId == model.CategoryTypeId, x => new CategoryTypes
                {
                    CategoryTypeParentId = model.ParentId,
                    CategoryId = model.CategoryId,
                    CategoryTypeName = model.CategoryTypeName,
                    Content = model.Content,
                    CreatedDate = DateTime.UtcNow,
                    CategoryTypePriceId = model.CategoryTypePriceId == 0 || model.CategoryTypePriceId == null
                        ? null
                        : model.CategoryTypePriceId,
                    Status = 1,
                    ThumbnailImage = model.FileThumbnail,
                    UrlRouter = urlRouter,
                    AgeOrderId = model.AgeOrderId,
                    GlobalSortOrder = model.CategoryTypeOrderId == 0
                        ? (int) CategoryTypeOrderEnum.Normal
                        : model.CategoryTypeOrderId,
                    AuthorId = model.AuthorId
                });
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
                Repository.UpdateMany<DbContextBase>(x => x.CategoryTypeId == categoryTypeId, x => new CategoryTypes {Status = 0});
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
            var query = Repository.DoQuery<DbContextBase>(x => x.CategoryTypeParentId == 0 && x.Status == 1)
                .Select(x => new {x.CategoryTypeId, x.CategoryTypeName})
                .ToList();
            return query.ToDictionary(x => x.CategoryTypeId, x => x.CategoryTypeName);
        }

        public List<AgeOrder> GetAgeOrders()
        {
            var query = _ageOrderRepository.Table<DbContextBase>().ToList();
            return query;
        }

        public List<Author> GetAuthors()
        {
            var query = _authorRepository.Table<DbContextBase>().Select(x => new
            {
                x.AuthorId,
                x.AuthorName,
            }).ToList();
            var result = query.Select(x => new Author
            {
                AuthorId = x.AuthorId,
                AuthorName = x.AuthorName
            }).ToList();
            return result;
        }
    }
}