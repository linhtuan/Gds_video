using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using Gds.ServiceModel.ControlObject;
using MvcCornerstone.Services;

namespace GdsVideoBackend.Domain
{
    public interface IAuthorService : IGenericService<Author, DbContextBase>
    {
        PagingResultModel<Author> GetAuthors(int pageIndex, int pageSize);

        Author InsertAuthor(Author model);

        bool UpdateAuthor(Author model);
    }
}