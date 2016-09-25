﻿using System.Collections.Generic;
using Gds.BusinessObject.DbContext;
using Gds.BusinessObject.TableModel;
using GdsVideoBackend.Models;
using MvcCornerstone.Services;

namespace GdsVideoBackend.Domain
{
    public interface ICategoryGroupService : IGenericService<CategoryTypeGroup, DbContextBase>
    {
        List<CategoryGroupViewModel> GetCategoryGroups(int categoryTypeId);

        int Insert(CategoryTypeGroup model);

        int Update(CategoryTypeGroup model);

        bool Delete(int cateGroupId);
    }
}