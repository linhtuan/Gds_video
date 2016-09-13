using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using Gds.ServiceModel.ControlObject;
using Gds.VideoFrontend.Models;
using MvcCornerstone.Services;

namespace Gds.VideoFrontend.Domain
{
    public interface IContactService : IGenericService<PaymentLog, DbContextBase>
    {
        PagingResultModel<ContactPaymentLogViewModel> GetPaymentLogByContactId(int contactId, int pageIndex, int pageSize);
    }
}