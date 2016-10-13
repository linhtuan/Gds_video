using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using Gds.ServiceModel.ControlObject;
using Gds.VideoFrontend.Models;
using MvcCornerstone.Services;

namespace Gds.VideoFrontend.Domain
{
    public interface IContactService : IGenericService<PaymentLog, DbContextBase>
    {
        bool ContactPaymentCategory(int contactId, string categoryRouter);

        PagingResultModel<ContactPaymentLogViewModel> GetPaymentLogByContactId(int contactId, int pageIndex, int pageSize);
    }
}