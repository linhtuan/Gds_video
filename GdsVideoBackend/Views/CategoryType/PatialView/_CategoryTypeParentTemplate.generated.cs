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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/CategoryType/PatialView/_CategoryTypeParentTemplate.cshtml")]
    public partial class _Views_CategoryType_PatialView__CategoryTypeParentTemplate_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_CategoryType_PatialView__CategoryTypeParentTemplate_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n<script");

WriteLiteral(" id=\"categoryTypeParentTemplate\"");

WriteLiteral(" type=\"text/x-jquery-tmpl\"");

WriteLiteral(">\r\n    <table class=\"table table-striped table-bordered table-hover dataTables-ex" +
"ample dataTable dtr-inline\" id=\"categoryTypeParent_Table\" role=\"grid\" aria-descr" +
"ibedby=\"DataTables_Table_0_info\">\r\n        <thead>\r\n            <tr role=\"row\">\r" +
"\n                <th class=\"sorting_asc\" tabindex=\"0\" aria-controls=\"categoryTyp" +
"eParent_Table\" rowspan=\"1\" colspan=\"1\" aria-sort=\"ascending\" style=\"width: 189px" +
";\">Tên gói</th>\r\n                <th class=\"sorting\" tabindex=\"0\" aria-controls=" +
"\"categoryTypeParent_Table\" rowspan=\"1\" colspan=\"1\" style=\"width: 253px;\">Nội dun" +
"g</th>\r\n                <th class=\"sorting\" tabindex=\"0\" aria-controls=\"category" +
"TypeParent_Table\" rowspan=\"1\" colspan=\"1\" style=\"width: 229px;\">Giá tiền</th>\r\n " +
"               <th class=\"sorting\" tabindex=\"0\" aria-controls=\"categoryTypeParen" +
"t_Table\" rowspan=\"1\" colspan=\"1\" style=\"width: 162px;\">Ngày tạo</th>\r\n          " +
"      <th tabindex=\"0\" aria-controls=\"categoryTypeParent_Table\" rowspan=\"1\" cols" +
"pan=\"1\" style=\"width: 115px;\"></th>\r\n            </tr>\r\n        </thead>\r\n      " +
"  <tbody>\r\n            {{each Result}}\r\n            <tr class=\"gradeA odd\" role=" +
"\"row\">\r\n                <td class=\"categorty-type-children\" data-childrenid=\"${$" +
"value.ChildrenId}\">${$value.ChildrenName}</td>\r\n                <td>${$value.Con" +
"tent}</td>\r\n                <td class=\"price\" data-priceid=\"${$value.PriceId}\">$" +
"{$value.Price}</td>\r\n                <td class=\"center\">${$value.DateTime}</td>\r" +
"\n                <td class=\"center\">\r\n                    <a class=\"btn btn-succ" +
"ess btn-rounded\" href=\"#\">Edit</a>\r\n                    <a class=\"btn btn-danger" +
" btn-rounded\" href=\"#\">Delete</a>\r\n                </td>\r\n            </tr>\r\n   " +
"         {{/each}}\r\n        </tbody>\r\n    </table>\r\n</script>\r\n");

        }
    }
}
#pragma warning restore 1591