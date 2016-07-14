﻿using System.Collections.Generic;
using System.Web.Http;
using Gds.Setting;
using GiaoDucSomVideo.Domain;

namespace GiaoDucSomVideo.Areas.Api.Controllers
{
    public class UpdateCategoryController : ApiController
    {
        private readonly ICategoryService _categoryService;

        public UpdateCategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Route("api/updatecategory/updatedategory")]
        [HttpGet]
        public IHttpActionResult UpdateCategory()
        {
            var leftMenu = _categoryService.GetLeftMenu();
            SessionManager.SetSessionObject(SessionObjectEnum.Categorys, leftMenu);
            return Ok(true);
        }
    }
}
