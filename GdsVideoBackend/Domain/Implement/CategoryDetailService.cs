using System.Linq;
using System.Linq.Expressions;
using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using Gds.ServiceModel.BackEndModel;
using Gds.ServiceModel.ControlObject;
using MvcCornerstone.Data;
using MvcCornerstone.Generic.Paging;
using MvcCornerstone.Services;
using System;

namespace GdsVideoBackend.Domain.Implement
{
    public class CategoryDetailService : GenericService<CategoryDetails, DbContextBase>, ICategoryDetailService
    {
        private readonly IEntityRepository<PhysicalFiles> _physicalFileRepository;
        private readonly IEntityRepository<CategoryTypes> _categoryTypeRepository; 

        public CategoryDetailService(IEntityRepository<CategoryDetails> repository, 
            IEntityRepository<PhysicalFiles> physicalFileRepository, 
            IEntityRepository<CategoryTypes> categoryTypeRepository) : base(repository)
        {
            _physicalFileRepository = physicalFileRepository;
            _categoryTypeRepository = categoryTypeRepository;
        }

        PagingResultModel<CategoryDetailModel> ICategoryDetailService.GetCategoryDetails(int? categoryTypeId, int pageIndex, int pageSize)
        {
            try
            {
                Expression<Func<CategoryDetails, bool>> predicate;
                if (categoryTypeId != null)
                {
                    predicate = x => x.CategoryTypeId == categoryTypeId && x.Status == 1;
                }
                else
                {
                    predicate = x => x.Status == 1;
                }

                var query = Repository.DoQuery<DbContextBase>(predicate).OrderByDescending(x => x.CreatedDate);
                var totalCount = query.Count();
                var dataResult = query.ToPagedQueryable(pageIndex, pageSize, totalCount);

                var physicalFileIds = dataResult.Select(x => x.PhysicalFileId).ToList();
                var physicalFiles = _physicalFileRepository.DoQuery<DbContextBase>(x => physicalFileIds.Contains(x.PhysicalFileId)).Select(x => new
                    {
                        x.PhysicalFileId,
                        x.FileName,
                    });

                var results = dataResult.Select(item =>
                {
                    var fileInfo = physicalFiles.FirstOrDefault(x => x.PhysicalFileId == item.PhysicalFileId);
                    return new CategoryDetailModel
                    {
                        CategoryDetailId = item.CategoryDetailId,
                        CategoryTypeId = item.CategoryTypeId,
                        CategoryDetailName = item.CategoryDetailName,
                        Content = item.Content,
                        UpdatedDate = item.UpdatedDate.Value.ToString("dd-MM-yyyy HH:mm"),
                        FileName = fileInfo != null ? fileInfo.FileName : string.Empty,
                        PhysicalFile = new PhysicalFileModel
                        {
                            PhysicalFileId = item.PhysicalFileId,
                            FileName = fileInfo != null ? fileInfo.FileName : string.Empty,
                        }
                    };
                }).ToList();

                var resultPaging = new PagingResultModel<CategoryDetailModel>
                {
                    Result = results,
                    PageIndex = dataResult.PageIndex,
                    PageSize = dataResult.PageSize,
                    ItemCount = dataResult.ItemCount,
                    PageCount = dataResult.PageCount
                };

                return resultPaging;
            }
            catch (Exception)
            {
                return new PagingResultModel<CategoryDetailModel>();
            }
        }

        public bool Insert(CategoryDetailModel model)
        {
            try
            {
                var detail = new CategoryDetails
                {
                    CategoryTypeId = model.CategoryTypeId,
                    CategoryDetailName = model.CategoryDetailName,
                    Content = model.Content,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Status = 1
                };
                Repository.Insert<DbContextBase>(detail);
                Repository.Commit<DbContextBase>();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(CategoryDetailModel model)
        {
            try
            {
                Repository.UpdateMany<DbContextBase>(x => x.CategoryDetailId == model.CategoryDetailId, x => new CategoryDetails
                {
                    CategoryDetailName = model.CategoryDetailName,
                    Content = model.Content,
                    UpdatedDate = DateTime.UtcNow
                });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int categoryDetailId)
        {
            try
            {
                Repository.UpdateMany<DbContextBase>(x => x.CategoryDetailId == categoryDetailId, x => new CategoryDetails
                {
                    Status = 0
                });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int GetCategoryId(int categoryTypeId)
        {
            var query = _categoryTypeRepository.DoQuery<DbContextBase>(x => x.CategoryTypeId == categoryTypeId).FirstOrDefault();
            return query != null ? query.CategoryId : 0;
        }

        public bool UpdateFileInfo(PhysicalFiles model, int categoryDetailId)
        {
            try
            {
                var detail = Repository.GetById<DbContextBase>(categoryDetailId);
                _physicalFileRepository.DeleteMany<DbContextBase>(x => x.PhysicalFileId == detail.PhysicalFileId);
                _physicalFileRepository.Insert<DbContextBase>(model);
                _physicalFileRepository.Commit<DbContextBase>();
                detail.PhysicalFileId = model.PhysicalFileId;
                Repository.Update<DbContextBase>(detail);
                _physicalFileRepository.Commit<DbContextBase>();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}