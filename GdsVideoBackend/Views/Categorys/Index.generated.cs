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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Categorys/Index.cshtml")]
    public partial class _Views_Categorys_Index_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Categorys_Index_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 2 "..\..\Views\Categorys\Index.cshtml"
  
    ViewBag.Title = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n");

DefineSection("left_menu", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 8 "..\..\Views\Categorys\Index.cshtml"
Write(Html.Partial("~/Views/PartialViews/_LeftMenuPartial.cshtml"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

WriteLiteral("<div");

WriteLiteral(" class=\"col-lg-12\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"ibox float-e-margins\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"ibox-content\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"table-responsive\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"dataTables_wrapper form-inline\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"clear\"");

WriteLiteral("></div>\r\n                    <div");

WriteLiteral(" class=\"dataTables_length\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"col-sm-3\"");

WriteLiteral(">\r\n                            <label>\r\n                                <select");

WriteLiteral(" class=\"form-control input-sm\"");

WriteLiteral(">\r\n                                    <option");

WriteLiteral(" value=\"10\"");

WriteLiteral(">10</option>\r\n                                    <option");

WriteLiteral(" value=\"25\"");

WriteLiteral(">25</option>\r\n                                    <option");

WriteLiteral(" value=\"50\"");

WriteLiteral(">50</option>\r\n                                    <option");

WriteLiteral(" value=\"100\"");

WriteLiteral(">100</option>\r\n                                </select> records per page\r\n      " +
"                      </label>\r\n                        </div>\r\n                " +
"        <div");

WriteLiteral(" class=\"col-sm-3\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" data-toggle=\"modal\"");

WriteLiteral(" class=\"btn btn-success btn-sm\"");

WriteLiteral(" href=\"#add-new-category\"");

WriteLiteral(">Thêm chủ đề</a>\r\n                        </div>\r\n                    </div>\r\n   " +
"                 <div");

WriteLiteral(" class=\"dataTables_filter\"");

WriteLiteral(">\r\n                        <label>Search:<input");

WriteLiteral(" type=\"search\"");

WriteLiteral(" class=\"form-control input-sm\"");

WriteLiteral(" placeholder=\"\"");

WriteLiteral("></label>\r\n                    </div>\r\n                    <div");

WriteLiteral(" id=\"categoryTypeParent_Div\"");

WriteLiteral(">\r\n\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"paging_simple_numbers\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"col-lg-12\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"col-lg-4\"");

WriteLiteral("></div>\r\n                            <div");

WriteLiteral(" class=\"col-lg-4 paging-row paging-row-parent\"");

WriteLiteral(">\r\n                                <a");

WriteLiteral(" class=\"btn btn-default btn-sm\"");

WriteLiteral(" href=\"#\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-angle-left\"");

WriteLiteral("></i></a>\r\n                                <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"input-mini\"");

WriteLiteral(">&nbsp;of&nbsp;<a>42</a>\r\n                                <a");

WriteLiteral(" class=\"btn btn-default btn-sm\"");

WriteLiteral(" href=\"#\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-angle-right\"");

WriteLiteral("></i></a>\r\n                            </div>\r\n                            <div");

WriteLiteral(" class=\"col-lg-4\"");

WriteLiteral("></div>\r\n                        </div>\r\n                    </div>\r\n            " +
"    </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n<div");

WriteLiteral(" id=\"add-new-category\"");

WriteLiteral(" class=\"modal fade\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(" style=\"display: none;\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"modal-dialog\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"modal-content\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"modal-body\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"col-sm-12\"");

WriteLiteral(">\r\n                        <h3");

WriteLiteral(" class=\"m-t-none m-b\"");

WriteLiteral(">Thêm Chủ đề</h3>\r\n                        <form");

WriteLiteral(" id=\"category-form row\"");

WriteLiteral(" role=\"form\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"form-group col-sm-12\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\r\n                                    <label>Tên chủ đề</label> <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" placeholder=\"Tên chủ đề\"");

WriteLiteral(" class=\"category-name form-control\"");

WriteLiteral(">\r\n                                </div>\r\n                                <div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\r\n                                    <label>Chi tiết chủ đề</label> <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" placeholder=\"Chi tiết chủ đề\"");

WriteLiteral(" class=\"category-detail form-control\"");

WriteLiteral(">\r\n                                </div>\r\n                            </div>\r\n  " +
"                          <div");

WriteLiteral(" class=\"form-group col-sm-12\"");

WriteLiteral(">\r\n                                <a");

WriteLiteral(" id=\"save-children\"");

WriteLiteral(" class=\"btn btn-sm btn-primary pull-right m-t-n-xs\"");

WriteLiteral("><strong>Save</strong></a>\r\n                            </div>\r\n                 " +
"       </form>\r\n                    </div>\r\n                </div>\r\n            " +
"</div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 3770), Tuple.Create("\"", 3807)
, Tuple.Create(Tuple.Create("", 3776), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/gds.paging.control.js")
, 3776), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 3831), Tuple.Create("\"", 3862)
, Tuple.Create(Tuple.Create("", 3837), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/gds.category.js")
, 3837), false)
);

WriteLiteral("></script>\r\n");

});

        }
    }
}
#pragma warning restore 1591
