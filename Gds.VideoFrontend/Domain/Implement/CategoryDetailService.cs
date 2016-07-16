using System.Linq;
using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using MvcCornerstone.Data;
using MvcCornerstone.Services;

namespace Gds.VideoFrontend.Domain.Implement
{
    public class CategoryDetailService : GenericService<CategoryDetails, DbContextBase>, ICategoryDetailService
    {
        private readonly IEntityRepository<PhysicalFiles> _physicalFileRepository;
        public CategoryDetailService(IEntityRepository<CategoryDetails> repository, 
            IEntityRepository<PhysicalFiles> physicalFileRepository) : base(repository)
        {
            _physicalFileRepository = physicalFileRepository;
        }

        public string GetVideos(int physicalFileId)
        {
            var query = _physicalFileRepository.DoQuery<DbContextBase>(x => x.PhysicalFileId == physicalFileId).FirstOrDefault();
            return query == null ? string.Empty : query.FileServerNamePath;
        }
    }
}