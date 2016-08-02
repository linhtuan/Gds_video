using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using Gds.ServiceModel.ControlObject;
using Gds.VideoFrontend.Models;
using MvcCornerstone.Data;
using MvcCornerstone.Generic.Paging;
using MvcCornerstone.Services;

namespace Gds.VideoFrontend.Domain.Implement
{
    public class CategoryService: GenericService<Categorys, DbContextBase>, ICategoryService
    {
        private readonly IEntityRepository<CategoryTypes> _catTypeRepository;
        private readonly IEntityRepository<CategoryTypePrice> _catPriceRepository; 

        public CategoryService(IEntityRepository<Categorys> repository, 
            IEntityRepository<CategoryTypes> categoryTypeRepository, 
            IEntityRepository<CategoryTypePrice> catPriceRepository) : base(repository)
        {
            _catTypeRepository = categoryTypeRepository;
            _catPriceRepository = catPriceRepository;
        }

        public List<CategoryHomeViewModel> GetCategoryHomePage()
        {
            var category = Repository.DoQuery<DbContextBase>(x => x.Status == 1).ToList();
            var categoryIds = category.Select(x => x.CategoryId);
            var url = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var query = _catTypeRepository.DoQuery<DbContextBase>(x => categoryIds.Contains(x.CategoryId)
                                                                       && x.CategoryTypeParentId == 0
                                                                       && x.CategoryTypePriceId != null
                                                                       && x.Status == 1)
                .GroupBy(x => x.CategoryId)
                .SelectMany(x => x.OrderBy(y => y.CreatedDate).Take(4)).ToList()
                .Select(x => new CategoryTypeHomeViewModel
                {
                    CategoryId = x.CategoryId,
                    CategoryTypeId = x.CategoryTypeId,
                    CategoryTypeName = x.CategoryTypeName,
                    CategoryTypeUrl = string.Format("{0}/{1}", url.Action("index", "course"), x.UrlRouter),
                    ThumbnailImage = !string.IsNullOrEmpty(x.ThumbnailImage)
                        ? Convert.ToBase64String(File.ReadAllBytes(x.ThumbnailImage))
                        : string.Empty,
                    MimeTypeImage = !string.IsNullOrEmpty(x.ThumbnailImage)
                        ? Regex.Replace(Path.GetExtension(x.ThumbnailImage), @"\W", "")
                        : string.Empty
                }).ToList();

            var result = category.Where(x => query.Select(y => y.CategoryId).Contains(x.CategoryId)).Select(x => new CategoryHomeViewModel
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                CategoryTypes = query.Where(y => y.CategoryId == x.CategoryId).ToList()
            }).ToList();

            return result;
        }

        public List<CategoryLeftMenuViewModel> GetLeftMenu()
        {
            var query = Repository.DoQuery<DbContextBase>(x => x.Status == 1).ToList();
            var url = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var result = query.Select(x => new CategoryLeftMenuViewModel
            {
                CategoryName = x.CategoryName,
                UrlCategory = string.Format("{0}/{1}", url.Action("index", "category"), x.UrlRouter)
            }).ToList();

            return result;
        }

        public PagingResultModel<CoursesViewModel> GetCourses(string categoryName, int pageIndex, int pageSize)
        {
            var url = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var category = Repository.DoQuery<DbContextBase>(x => x.Status == 1 && x.UrlRouter == categoryName).ToList();
            var categoryIds = category.Select(x=>x.CategoryId);
            var query = _catTypeRepository.DoQuery<DbContextBase>(x => categoryIds.Contains(x.CategoryId)
                                                                       && x.CategoryTypeParentId == 0
                                                                       && x.CategoryTypePriceId != null
                                                                       && x.Status == 1)
                .Join(_catPriceRepository.Table<DbContextBase>(), x => x.CategoryTypePriceId, y => y.CategoryTypePriceId,
                    (cat, y) => new {cat, y.Price}).OrderByDescending(x => x.cat.CreatedDate);
            var totalCount = query.Count();
            var dataResult = query.ToPagedQueryable(pageIndex, pageSize, totalCount);
            var results = dataResult.Select(item => new CoursesViewModel
            {
                CourseName = item.cat.CategoryTypeName,
                Type = 1,
                ThumbnailImage =
                    !string.IsNullOrEmpty(item.cat.ThumbnailImage)
                        ? Convert.ToBase64String(File.ReadAllBytes(item.cat.ThumbnailImage))
                        : string.Empty,
                MimeTypeImage =
                    !string.IsNullOrEmpty(item.cat.ThumbnailImage)
                        ? Regex.Replace(Path.GetExtension(item.cat.ThumbnailImage), @"\W", "")
                        : string.Empty,
                UrlCourse = string.Format("{0}/{1}", url.Action("index", "course"), item.cat.UrlRouter),
                Price = item.Price.Value.ToString("#,###", CultureInfo.GetCultureInfo("vi-VN").NumberFormat)
            }).ToList();
            var resultPaging = new PagingResultModel<CoursesViewModel>
            {
                Result = results,
                PageIndex = dataResult.PageIndex,
                PageSize = dataResult.PageSize,
                ItemCount = dataResult.ItemCount,
                PageCount = dataResult.PageCount
            };
            return resultPaging;
        }

        public List<CoursesViewModel> GetCoursesHot(string categoryName, out string title)
        {
            var url = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var category = Repository.DoQuery<DbContextBase>(x => x.Status == 1 && x.UrlRouter == categoryName).ToList();
            if (!category.Any())
            {
                title = string.Empty;
                return new List<CoursesViewModel>();
            }
            var categoryIds = category.Select(x => x.CategoryId);
            var query = _catTypeRepository.DoQuery<DbContextBase>(x => categoryIds.Contains(x.CategoryId)
                                                                       && x.CategoryTypeParentId == 0
                                                                       && x.CategoryTypePriceId != null
                                                                       && x.Status == 1)
                .Join(_catPriceRepository.Table<DbContextBase>(), x => x.CategoryTypePriceId, y => y.CategoryTypePriceId,
                    (cat, y) => new { cat, y.Price }).OrderByDescending(x => x.cat.CreatedDate).Take(4).ToList();
            var results = query.Select(item => new CoursesViewModel
            {
                CourseName = item.cat.CategoryTypeName,
                Type = 1,
                ThumbnailImage =
                    !string.IsNullOrEmpty(item.cat.ThumbnailImage)
                        ? Convert.ToBase64String(File.ReadAllBytes(item.cat.ThumbnailImage))
                        : string.Empty,
                MimeTypeImage =
                    !string.IsNullOrEmpty(item.cat.ThumbnailImage)
                        ? Regex.Replace(Path.GetExtension(item.cat.ThumbnailImage), @"\W", "")
                        : string.Empty,
                UrlCourse = string.Format("{0}/{1}", url.Action("index", "course"), item.cat.UrlRouter),
                Price = item.Price.Value.ToString("#,###", CultureInfo.GetCultureInfo("vi-VN").NumberFormat)
            }).ToList();
            title = category.First().CategoryName;
            return results;
        }
    }
}