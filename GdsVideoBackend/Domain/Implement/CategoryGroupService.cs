﻿using System;
using System.Collections.Generic;
using System.Linq;
using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using GdsVideoBackend.Models;
using MvcCornerstone.Data;
using MvcCornerstone.Services;

namespace GdsVideoBackend.Domain.Implement
{
    public class CategoryGroupService : GenericService<CategoryTypeGroup, DbContextBase>, ICategoryGroupService
    {
        private readonly IEntityRepository<CategoryDetails> _detailRepository;
        private readonly IEntityRepository<PhysicalFiles> _physicalFileRepository;

        public CategoryGroupService(IEntityRepository<CategoryTypeGroup> repository, 
            IEntityRepository<CategoryDetails> detailRepository, 
            IEntityRepository<PhysicalFiles> physicalFileRepository)
            : base(repository)
        {
            _detailRepository = detailRepository;
            _physicalFileRepository = physicalFileRepository;
        }

        public List<CategoryGroupViewModel> GetCategoryGroups(int categoryTypeId)
        {
            var query = Repository.DoQuery<DbContextBase>(x => x.CategoryTypeId == categoryTypeId)
                .Join(_detailRepository.Table<DbContextBase>(), x => x.CategoryTypeGroupId, y => y.CategoryTypeGroupId,
                    (groups, details) => new {groups, details}).ToList();

            var physicalFileIds = query.Select(x => x.details.PhysicalFileId).ToList();
            var physicalFiles = _physicalFileRepository.DoQuery<DbContextBase>(x => physicalFileIds.Contains(x.PhysicalFileId)).Select(x => new
            {
                x.PhysicalFileId,
                x.FileName,
            });

            var result = query.GroupBy(x => new {x.groups.CategoryTypeGroupId, x.groups.CategoryTypeGroupName})
                .Select(x => new CategoryGroupViewModel
                {
                    CategoryGroupId = x.Key.CategoryTypeGroupId,
                    CategoryGroupName = x.Key.CategoryTypeGroupName,
                    CategoryDetails = x.Select(item =>
                    {
                        var fileInfo = physicalFiles.FirstOrDefault(y => y.PhysicalFileId == item.details.PhysicalFileId);
                        return new CategoryDetailModel
                        {
                            CategoryDetailId = item.details.CategoryDetailId,
                            CategoryTypeId = item.details.CategoryTypeId,
                            CategoryDetailName = item.details.CategoryDetailName,
                            UpdatedDate = item.details.UpdatedDate.HasValue
                                ? item.details.UpdatedDate.Value.ToString("dd-MM-yyyy HH:mm")
                                : DateTime.UtcNow.ToString("dd-MM-yyyy HH:mm"),
                            FileName = fileInfo != null ? fileInfo.FileName : string.Empty,
                            PhysicalFile = new PhysicalFileModel
                            {
                                PhysicalFileId = item.details.PhysicalFileId,
                                FileName = fileInfo != null ? fileInfo.FileName : string.Empty,
                            },
                            LectureIndex = item.details.LectureIndex
                        };
                    }).ToList()
                }).ToList();

            return result;
        }

        public int Insert(CategoryTypeGroup model)
        {
            try
            {
                var detail = new CategoryTypeGroup
                {
                    CategoryTypeId = model.CategoryTypeId,
                    CategoryTypeGroupName = model.CategoryTypeGroupName,
                    Index = model.Index,
                    CreatedDate = DateTime.UtcNow,
                };
                Repository.Insert<DbContextBase>(detail);
                Repository.Commit<DbContextBase>();
                return detail.CategoryTypeGroupId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int Update(CategoryTypeGroup model)
        {
            try
            {
                Repository.UpdateMany<DbContextBase>(x => x.CategoryTypeGroupId == model.CategoryTypeGroupId, x => new CategoryTypeGroup
                {
                    CategoryTypeGroupName = model.CategoryTypeGroupName,
                    Index = model.Index,
                    CreatedDate = DateTime.UtcNow,
                });
                return model.CategoryTypeGroupId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public bool Delete(int cateGroupId)
        {
            throw new System.NotImplementedException();
        }
    }
}