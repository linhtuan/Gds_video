using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using Gds.ServiceModel.ControlObject;
using Gds.VideoFrontend.Models;
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

        public PagingResultModel<ContactPaymentLogViewModel> GetPaymentLogByContactId(int contactId, int pageIndex, int pageSize)
        {

            throw new System.NotImplementedException();
        }
    }
}