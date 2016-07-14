using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using Gds.Setting.Cryptography;
using GiaoDucSomVideo.Models;
using MvcCornerstone.Data;
using MvcCornerstone.Services;

namespace GiaoDucSomVideo.Domain.Implement
{
    public class CourseService : GenericService<CategoryTypes, DbContextBase>, ICourseService
    {
        private readonly IEntityRepository<Categorys> _catRepository;
        private readonly IEntityRepository<CategoryTypePrice> _catPriceRepository; 

        public CourseService(IEntityRepository<CategoryTypes> repository, 
            IEntityRepository<Categorys> catRepository, 
            IEntityRepository<CategoryTypePrice> catPriceRepository) : base(repository)
        {
            _catRepository = catRepository;
            _catPriceRepository = catPriceRepository;
        }

        public List<CoursesViewModel> GetSuggestCourses(int categoryTypeId)
        {
            throw new System.NotImplementedException();
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
            };

            return result;
        }
    }
}