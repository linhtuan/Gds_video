using System;
using System.Linq;
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
        private readonly IEntityRepository<CategoryTypes> _categoryTypeRepository;

        public ContactService(IEntityRepository<PaymentLog> repository,
            IEntityRepository<CategoryTypes> categoryTypeRepository)
            : base(repository)
        {
            _categoryTypeRepository = categoryTypeRepository;
        }

        public bool ContactPaymentCategory(int contactId, string categoryRouter)
        {
            var cate = _categoryTypeRepository.DoQuery<DbContextBase>(x => x.UrlRouter == categoryRouter).FirstOrDefault();
            if (cate == null) return false;
            var query = Repository.DoQuery<DbContextBase>(x => x.UserId == contactId && cate.CategoryTypeId == x.CategoryTypeId).FirstOrDefault();
            return query != null;
        }

        public PagingResultModel<ContactPaymentLogViewModel> GetPaymentLogByContactId(int contactId, int pageIndex, int pageSize)
        {

            throw new System.NotImplementedException();
        }

        public int TotalCourseByContact(int contactId)
        {
            var query = Repository.DoQuery<DbContextBase>(x => x.UserId == contactId).Count();
            return query;
        }
    }
}