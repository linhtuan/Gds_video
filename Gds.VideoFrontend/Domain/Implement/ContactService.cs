using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using MvcCornerstone.Data;
using MvcCornerstone.Services;

namespace Gds.VideoFrontend.Domain.Implement
{
    public class ContactService : GenericService<PaymentLog, DbContextBase>, IContactService
    {

        public ContactService(IEntityRepository<PaymentLog> repository)
            : base(repository)
        {
        }
    }
}