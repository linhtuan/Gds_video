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
using Gds.Setting.Cryptography;
using Gds.Setting.Helper;
using Gds.VideoFrontend.BusinessService;
using Gds.VideoFrontend.Models;
using MvcCornerstone.Data;
using MvcCornerstone.Services;

namespace Gds.VideoFrontend.Domain.Implement
{
    public class CourseService : GenericService<CategoryTypes, DbContextBase>, ICourseService
    {
        private readonly IEntityRepository<Categorys> _catRepository;
        private readonly IEntityRepository<CategoryTypePrice> _catPriceRepository;
        private readonly IEntityRepository<Author> _authorRepository;
        private readonly IEntityRepository<CategoryDetails> _categoryDetailRepository;
        private readonly IEntityRepository<PhysicalFiles> _physicalRepository;

        #region Service

        private readonly IRatingService _ratingService;

        #endregion

        public CourseService(IEntityRepository<CategoryTypes> repository, 
            IEntityRepository<Categorys> catRepository, 
            IEntityRepository<CategoryTypePrice> catPriceRepository, 
            IEntityRepository<Author> authorRepository, 
            IRatingService ratingService, 
            IEntityRepository<CategoryDetails> categoryDetailRepository, 
            IEntityRepository<PhysicalFiles> physicalRepository) : base(repository)
        {
            _catRepository = catRepository;
            _catPriceRepository = catPriceRepository;
            _authorRepository = authorRepository;
            _ratingService = ratingService;
            _categoryDetailRepository = categoryDetailRepository;
            _physicalRepository = physicalRepository;
        }

        public CategoryTypes GetCategoryType(string courseRouter)
        {
            return Repository.DoQuery<DbContextBase>(x => x.UrlRouter == courseRouter
                                                          && x.Status == 1
                                                          && x.CategoryTypeParentId == 0).FirstOrDefault();
        }

        public List<CoursesViewModel> GetSuggestCourses(int categoryTypeId)
        {
            var url = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var categoryId = Repository.DoQuery<DbContextBase>(x => x.CategoryTypeId == categoryTypeId
                                                                    && x.Status == 1)
                .Select(x => x.CategoryId);

            var query = Repository.DoQuery<DbContextBase>(x => categoryId.Contains(x.CategoryId)
                                                               && x.Status == 1
                                                               && x.CategoryTypeParentId == 0
                                                               && x.CategoryTypeId != categoryTypeId)
                .Join(_catPriceRepository.Table<DbContextBase>(), x => x.CategoryTypePriceId, y => y.CategoryTypePriceId,
                    (cat, y) => new {cat, y.Price}).OrderByDescending(x => x.cat.CreatedDate).Take(5).ToList();

            var levels = _ratingService.GetRatingLevels(query.Select(x => x.cat.CategoryTypeId).ToList());

            var result = query.Select(x => new CoursesViewModel
            {
                Type = 0,
                CourseName = x.cat.CategoryTypeName,
                ThumbnailImage = !string.IsNullOrEmpty(x.cat.ThumbnailImage)
                    ? Convert.ToBase64String(File.ReadAllBytes(x.cat.ThumbnailImage))
                    : string.Empty,
                MimeTypeImage = !string.IsNullOrEmpty(x.cat.ThumbnailImage)
                    ? Regex.Replace(Path.GetExtension(x.cat.ThumbnailImage), @"\W", "")
                    : string.Empty,
                UrlCourse = string.Format("{0}/{1}", url.Action("index", "course"), x.cat.UrlRouter),
                Price = x.Price.Value.ToString("#,###", CultureInfo.GetCultureInfo("vi-VN").NumberFormat),
                RatingLevel = levels[x.cat.CategoryTypeId].BindingRating()
            }).ToList();
            return result;
        }

        public CourseDetailViewModel GetCourseDetail(string courseRouter)
        {
            var query = Repository.DoQuery<DbContextBase>(x => x.UrlRouter == courseRouter
                                                               && x.Status == 1
                                                               && x.CategoryTypeParentId == 0)
                .Join(_catRepository.Table<DbContextBase>(),
                    x => x.CategoryId, y => y.CategoryId, (cateType, cate) => new
                    {
                        cateType,
                        cate.CategoryName
                    })
                .Join(_catPriceRepository.Table<DbContextBase>(),
                    x => x.cateType.CategoryTypePriceId, y => y.CategoryTypePriceId, (cateType, price) => new
                    {
                        cat = cateType.cateType,
                        cateType.CategoryName,
                        price.Price,
                    })
                .FirstOrDefault();
            if (query == null) return new CourseDetailViewModel();
            var level = _ratingService.GetRatingLevel(query.cat.CategoryTypeId);

            var lecture = Repository.DoQuery<DbContextBase>(x => x.CategoryTypeParentId == query.cat.CategoryTypeId)
                .Join(_categoryDetailRepository.Table<DbContextBase>(), x => x.CategoryTypeId, y => y.CategoryTypeId,
                    (cateType, cateDetail) => new
                    {
                        cateDetail
                    })
                .Join(_physicalRepository.Table<DbContextBase>(), x => x.cateDetail.PhysicalFileId, y => y.PhysicalFileId,
                    (cateDetail, physical) => new
                    {
                        physical
                    })
                .Select(x => x.physical.FileTime);

            var result = new CourseDetailViewModel
            {
                CategoryName = query.CategoryName,
                CourseId = CryptographyHelper.Encrypt(query.cat.CategoryTypeId.ToString()),
                CourseName = query.CategoryName,
                CourseSubTitle = string.Empty,
                ThumbnailImage = !string.IsNullOrEmpty(query.cat.ThumbnailImage)
                    ? Convert.ToBase64String(File.ReadAllBytes(query.cat.ThumbnailImage))
                    : string.Empty,
                MimeTypeImage = !string.IsNullOrEmpty(query.cat.ThumbnailImage)
                    ? Regex.Replace(Path.GetExtension(query.cat.ThumbnailImage), @"\W", "")
                    : string.Empty,
                Price = query.Price.Value.ToString("#,###", CultureInfo.GetCultureInfo("vi-VN").NumberFormat),
                Content = query.cat.Content,
                RatingLevel = level,
                AuthorId = CryptographyHelper.Encrypt(query.cat.AuthorId.ToString()),
                NumberLecture = lecture.Count(),
                TotalTimeLear = lecture.Sum().ConvertTime()
            };

            return result;
        }

        public Author GetAuthor(int authorId)
        {
            var query = _authorRepository.DoQuery<DbContextBase>(x => x.AuthorId == authorId).FirstOrDefault();
            if (query == null) return new Author();
            query.AuthorId = 0;
            query.ThumbnailImage = !string.IsNullOrEmpty(query.AuthorImage)
                    ? Convert.ToBase64String(File.ReadAllBytes(query.AuthorImage))
                    : string.Empty;
            query.MimeTypeImage = !string.IsNullOrEmpty(query.AuthorImage)
                ? Regex.Replace(Path.GetExtension(query.AuthorImage), @"\W", "")
                : string.Empty;
            return query;
        }

        public CategoryDetails GetCategoryDetails(string courseRouter, int index)
        {
            var queryParent = Repository.DoQuery<DbContextBase>(x => x.UrlRouter == courseRouter
                                                               && x.Status == 1
                                                               && x.CategoryTypeParentId == 0).FirstOrDefault();
            //if (queryParent)
            //{
                
            //}
            //var queryChildrend = Repository.DoQuery<>()
            throw new NotImplementedException();
        }

        public List<LectureGroupViewModel> GetLectures(int categoryTypeId, bool hasUrl, string urlRouter)
        {
            var url = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var query = Repository.DoQuery<DbContextBase>(x => x.CategoryTypeParentId == categoryTypeId && x.Status == 1)
                .Join(_categoryDetailRepository.Table<DbContextBase>(), x => x.CategoryTypeId, y => y.CategoryTypeId,
                    (cateType, cateDetail) => new
                    {
                        cateType.ChildrenIndex,
                        cateType.CategoryTypeName,
                        cateDetail.CategoryDetailName,
                        cateDetail.PhysicalFileId,
                        cateDetail.LectureIndex,
                    })
                .Join(_physicalRepository.Table<DbContextBase>(), x => x.PhysicalFileId, y => y.PhysicalFileId,
                    (cateDetail, physical) => new
                    {
                        detail = cateDetail,
                        physical.FileTime
                    })
                .OrderBy(x => x.detail.ChildrenIndex).ThenBy(x => x.detail.LectureIndex)
                .ToList()
                .GroupBy(x => new
                {
                    x.detail.CategoryTypeName,
                    x.detail.ChildrenIndex
                });
            var result = new List<LectureGroupViewModel>();

            foreach (var itemGroup in query)
            {
                var model = new LectureGroupViewModel
                {
                    LectureGroupName = itemGroup.Key.CategoryTypeName,
                    LectureGroupIndex = itemGroup.Key.ChildrenIndex.Value,
                    Lectures = new List<LectureContainerViewModel>()
                };
                foreach (var item in itemGroup)
                {
                    model.Lectures.Add(new LectureContainerViewModel
                    {
                        LectureNumberIndex = item.detail.LectureIndex,
                        LectureName = item.detail.CategoryDetailName,
                        LectureTime = item.FileTime.ConvertTime(),
                        LectureUrl = hasUrl
                            ? url.Action("Lecture", "Course", new {categorytype = urlRouter, index = item.detail.LectureIndex})
                            : string.Empty,
                    });
                }
                result.Add(model);
            }
            return result;
        }

        public LearningViewModel GetLearning(string courseRouter)
        {
            var url = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var query = Repository.DoQuery<DbContextBase>(x => x.UrlRouter == courseRouter
                                                               && x.CategoryTypeParentId == 0
                                                               && x.Status == 1).FirstOrDefault();
            if (query == null) return new LearningViewModel();

            var lectureFirst = Repository.DoQuery<DbContextBase>(x => x.CategoryTypeParentId == query.CategoryTypeId
                                                                      && x.ChildrenIndex == 1
                                                                      && x.Status == 1)
                .Join(_categoryDetailRepository.Table<DbContextBase>(), x => x.CategoryTypeId, y => y.CategoryTypeId,
                    (cat, detail) => new
                    {
                        detail.LectureIndex,
                        detail.CategoryDetailName,
                        detail.PhysicalFileId,
                    })
                    .Join(_physicalRepository.Table<DbContextBase>(), x => x.PhysicalFileId, y => y.PhysicalFileId,
                    (detail, physical) => new
                    {
                        detail.LectureIndex,
                        detail.CategoryDetailName,
                        detail.PhysicalFileId,
                        physical.FileTime
                    }).FirstOrDefault();

            if (lectureFirst == null) return new LearningViewModel();
            var level = _ratingService.GetRatingLevel(query.CategoryTypeId);
            var model = new LearningViewModel
            {
                CourseId = CryptographyHelper.Encrypt(query.CategoryTypeId.ToString()),
                CourseName = query.CategoryTypeName,
                RatingLevel = level,
                LectureFirstIndex = lectureFirst.LectureIndex,
                LectureFirstName = lectureFirst.CategoryDetailName,
                LectureFirstTime = lectureFirst.FileTime.ConvertTimeOneVideo(),
                LectureFirstUrl = url.Action("Lecture", "Course", new { categorytype = courseRouter, index = lectureFirst.LectureIndex }),
                CourseRouter = courseRouter
            };
            return model;
        }

        public LectureViewModel GetLecture(string courseRouter, int index)
        {
            var categoryType = Repository.DoQuery<DbContextBase>(x => x.UrlRouter == courseRouter
                                                               && x.CategoryTypeParentId == 0
                                                               && x.Status == 1).FirstOrDefault();
            if (categoryType == null) return new LectureViewModel();

            var query = Repository.DoQuery<DbContextBase>(x => x.CategoryTypeParentId == categoryType.CategoryTypeId)
                .Join(_categoryDetailRepository.Table<DbContextBase>(), x => x.CategoryTypeId, y => y.CategoryTypeId,
                    (cate, detail) => new
                    {
                        detail.CategoryDetailId,
                        detail.LectureIndex,
                        detail.PhysicalFileId
                    }).FirstOrDefault(x => x.LectureIndex == index);

            if (query == null) return new LectureViewModel();

            var model = new LectureViewModel
            {
                CourseId = CryptographyHelper.Encrypt(categoryType.CategoryTypeId.ToString()),
                CourseRouter = courseRouter,
                LectureId = CryptographyHelper.Encrypt(query.CategoryDetailId.ToString()),
                PhysicalFileId = CryptographyHelper.Encrypt(query.PhysicalFileId.ToString())
            };
            return model;
        }
    }
}