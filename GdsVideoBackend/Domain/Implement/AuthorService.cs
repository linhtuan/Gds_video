using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using Gds.ServiceModel.BackEndModel;
using Gds.ServiceModel.ControlObject;
using MvcCornerstone.Data;
using MvcCornerstone.Generic.Paging;
using MvcCornerstone.Services;

namespace GdsVideoBackend.Domain.Implement
{
    public class AuthorService : GenericService<Author, DbContextBase>, IAuthorService
    {
        public AuthorService(IEntityRepository<Author> repository) : base(repository)
        {
        }

        public PagingResultModel<Author> GetAuthors(int pageIndex, int pageSize)
        {
            var query = Repository.Table<DbContextBase>().OrderBy(x => x.AuthorId);
            var totalCount = query.Count();
            var dataResult = query.ToPagedQueryable(pageIndex, pageSize, totalCount);
            foreach (var item in dataResult)
            {
                item.ThumbnailImage = !string.IsNullOrEmpty(item.AuthorImage)
                    ? Convert.ToBase64String(File.ReadAllBytes(item.AuthorImage))
                    : string.Empty;
                item.MimeTypeImage = !string.IsNullOrEmpty(item.AuthorImage)
                    ? Regex.Replace(Path.GetExtension(item.AuthorImage), @"\W", "")
                    : string.Empty;
            }

            var resultPaging = new PagingResultModel<Author>
            {
                Result = dataResult.ToList(),
                PageIndex = dataResult.PageIndex,
                PageSize = dataResult.PageSize,
                ItemCount = dataResult.ItemCount,
                PageCount = dataResult.PageCount
            };
            return resultPaging;
        }

        public Author InsertAuthor(Author model)
        {
            Repository.Insert<DbContextBase>(model);
            Repository.Commit<DbContextBase>();
            return model;
        }

        public bool UpdateAuthor(Author model)
        {
            Repository.UpdateMany<DbContextBase>(x => x.AuthorId == model.AuthorId, x => new Author
            {
                AuthorDetail = model.AuthorDetail,
                AuthorImage = model.AuthorImage,
                AuthorName = model.AuthorName
            });
            Repository.Commit<DbContextBase>();
            return true;
        }
    }
}