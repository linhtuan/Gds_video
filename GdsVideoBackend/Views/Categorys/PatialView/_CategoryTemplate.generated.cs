﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using GdsVideoBackend;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Categorys/PatialView/_CategoryTemplate.cshtml")]
    public partial class _Views_Categorys_PatialView__CategoryTemplate_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Categorys_PatialView__CategoryTemplate_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<script");

WriteLiteral(" id=\"categoryTemplate\"");

WriteLiteral(" type=\"text/x-jquery-tmpl\"");

WriteLiteral(">\r\n    <table class=\"table table-striped table-bordered table-hover dataTable dtr" +
"-inline\" id=\"categoryTemplate_Table\" role=\"grid\" aria-describedby=\"DataTables_Ta" +
"ble_0_info\">\r\n        <thead>\r\n            <tr role=\"row\">\r\n                <th " +
"class=\"sorting_asc\" tabindex=\"0\" aria-controls=\"categoryTemplate_Table\" rowspan=" +
"\"1\" colspan=\"1\" aria-sort=\"ascending\" style=\"width: 189px;\">Tên mục</th>\r\n      " +
"          <th class=\"sorting_asc\" tabindex=\"0\" aria-controls=\"categoryTemplate_T" +
"able\" rowspan=\"1\" colspan=\"1\" aria-sort=\"ascending\" style=\"width: 189px;\">nội du" +
"ng</th>\r\n                <th class=\"sorting\" tabindex=\"0\" aria-controls=\"categor" +
"yTemplate_Table\" rowspan=\"1\" colspan=\"1\" style=\"width: 162px;\">Ngày tạo</th>\r\n  " +
"              <th tabindex=\"0\" aria-controls=\"categoryTemplate_Table\" rowspan=\"1" +
"\" colspan=\"1\" style=\"width: 115px;\"></th>\r\n            </tr>\r\n        </thead>\r\n" +
"        <tbody>\r\n            {{each Result}}\r\n            <tr class=\"gradeA odd\"" +
" role=\"row\" id=\"${$value.CategoryId}\">\r\n                <td class=\"categorty\" da" +
"ta-id=\"${$value.CategoryId}\">${$value.CategoryName}</td>\r\n                <td cl" +
"ass=\"detail\">${$value.CategoryDetail}</td>\r\n                <td class=\"date\">${$" +
"value.DateTime}</td>\r\n                <td class=\"actions\">\r\n                    " +
"<a class=\"btn btn-sm btn-success btn-rounded\" href=\"categorytype?categoryId=${$v" +
"alue.CategoryId}\" target=\"_blank\">Category Types</a>\r\n                    <a cla" +
"ss=\"btn btn-sm btn-success btn-rounded\" onclick=\"bindingCategoryFrom(this)\" data" +
"-id=\"${$value.CategoryId}\" data-toggle=\"modal\" href=\"#add-new-category\">Edit</a>" +
"\r\n                    <a class=\"btn btn-sm btn-danger btn-rounded\" onclick=\"dele" +
"teCategoryDetail(this)\" data-id=\"${$value.CategoryId}\" href=\"#\">Delete</a>\r\n    " +
"            </td>\r\n            </tr>\r\n            {{/each}}\r\n        </tbody>\r\n " +
"   </table>\r\n</script>\r\n");

        }
    }
}
#pragma warning restore 1591
