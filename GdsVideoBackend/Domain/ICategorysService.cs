using System.Collections.Generic;
using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using MvcCornerstone.Services;

namespace GdsVideoBackend.Domain
{
    public interface ICategorysService : IGenericService<Categorys, DbContextBase>
    {
        List<Categorys> GetCategory();
    }
}