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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/CategoryType/PatialView/_CategoryTypeParentDialog.cshtml")]
    public partial class _Views_CategoryType_PatialView__CategoryTypeParentDialog_cshtml : System.Web.Mvc.WebViewPage<GdsVideoBackend.Models.CategoryTypeFromViewModel>
    {
        public _Views_CategoryType_PatialView__CategoryTypeParentDialog_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" id=\"add-new-category-type-parent\"");

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

WriteLiteral(">Sign in</h3>\r\n                        <form");

WriteLiteral(" id=\"category-type-parent-form\"");

WriteLiteral(" role=\"form\"");

WriteAttribute("action", Tuple.Create(" action=\"", 483), Tuple.Create("\"", 529)
            
            #line 10 "..\..\Views\CategoryType\PatialView\_CategoryTypeParentDialog.cshtml"
  , Tuple.Create(Tuple.Create("", 492), Tuple.Create<System.Object, System.Int32>(Url.Action("Insert", "CategoryType")
            
            #line default
            #line hidden
, 492), false)
);

WriteLiteral(" enctype=\"multipart/form-data\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"form-group row\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\r\n                                    <label>Tên gói</label> <input");

WriteLiteral(" name=\"CategoryTypeName\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" placeholder=\"Tên gói\"");

WriteLiteral(" class=\"category-type-name form-control\"");

WriteLiteral(">\r\n                                </div>\r\n                                <div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\r\n                                    <label>Giá tiền</label>\r\n                 " +
"                   <select");

WriteLiteral(" class=\"form-control m-b price\"");

WriteLiteral(" name=\"Price\"");

WriteLiteral(">\r\n");

            
            #line 18 "..\..\Views\CategoryType\PatialView\_CategoryTypeParentDialog.cshtml"
                                        
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\CategoryType\PatialView\_CategoryTypeParentDialog.cshtml"
                                         foreach (var item in Model.PriceSetting)
                                        {

            
            #line default
            #line hidden
WriteLiteral("                                            <option");

WriteAttribute("value", Tuple.Create(" value=\"", 1267), Tuple.Create("\"", 1283)
            
            #line 20 "..\..\Views\CategoryType\PatialView\_CategoryTypeParentDialog.cshtml"
, Tuple.Create(Tuple.Create("", 1275), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 1275), false)
);

WriteLiteral(" ");

            
            #line 20 "..\..\Views\CategoryType\PatialView\_CategoryTypeParentDialog.cshtml"
                                                                 Write(Model.PriceSetting.First() == item ? "selected='selected'" : "");

            
            #line default
            #line hidden
WriteLiteral(">");

            
            #line 20 "..\..\Views\CategoryType\PatialView\_CategoryTypeParentDialog.cshtml"
                                                                                                                                   Write(item.Price);

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n");

            
            #line 21 "..\..\Views\CategoryType\PatialView\_CategoryTypeParentDialog.cshtml"
                                        }

            
            #line default
            #line hidden
WriteLiteral("                                    </select>\r\n                                </" +
"div>\r\n                                <div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\r\n                                    <label>Giá tiền</label>\r\n                 " +
"                   <select");

WriteLiteral(" class=\"form-control m-b age-order\"");

WriteLiteral(" name=\"AgeOrder\"");

WriteLiteral(">\r\n");

            
            #line 27 "..\..\Views\CategoryType\PatialView\_CategoryTypeParentDialog.cshtml"
                                        
            
            #line default
            #line hidden
            
            #line 27 "..\..\Views\CategoryType\PatialView\_CategoryTypeParentDialog.cshtml"
                                         foreach (var item in Model.AgeOrderSetting)
                                        {

            
            #line default
            #line hidden
WriteLiteral("                                            <option");

WriteAttribute("value", Tuple.Create(" value=\"", 1898), Tuple.Create("\"", 1914)
            
            #line 29 "..\..\Views\CategoryType\PatialView\_CategoryTypeParentDialog.cshtml"
, Tuple.Create(Tuple.Create("", 1906), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 1906), false)
);

WriteLiteral(" ");

            
            #line 29 "..\..\Views\CategoryType\PatialView\_CategoryTypeParentDialog.cshtml"
                                                                 Write(Model.AgeOrderSetting.First() == item ? "selected='selected'" : "");

            
            #line default
            #line hidden
WriteLiteral(">");

            
            #line 29 "..\..\Views\CategoryType\PatialView\_CategoryTypeParentDialog.cshtml"
                                                                                                                                      Write(item.Name);

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n");

            
            #line 30 "..\..\Views\CategoryType\PatialView\_CategoryTypeParentDialog.cshtml"
                                        }

            
            #line default
            #line hidden
WriteLiteral("                                    </select>\r\n                                </" +
"div>\r\n                                <div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\r\n                                    <label>Thứ tự gói</label>\r\n               " +
"                     <select");

WriteLiteral(" class=\"form-control m-b categorytype-order\"");

WriteLiteral(" name=\"CategoryTypeOrder\"");

WriteLiteral(">\r\n                                        <option");

WriteLiteral(" value=\"0\"");

WriteLiteral(">-- Mắc định --</option>\r\n                                        <option");

WriteLiteral(" value=\"100\"");

WriteLiteral(">Thấp</option>\r\n                                        <option");

WriteLiteral(" value=\"200\"");

WriteLiteral(">Trung bình</option>\r\n                                        <option");

WriteLiteral(" value=\"300\"");

WriteLiteral(">Cao</option>\r\n                                    </select>\r\n                   " +
"             </div>\r\n                                <div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\r\n                                    <label>Tên tác giả</label>\r\n              " +
"                      <select");

WriteLiteral(" class=\"form-control m-b author\"");

WriteLiteral(" name=\"Author\"");

WriteLiteral(">\r\n                                        <option");

WriteLiteral(" value=\"0\"");

WriteLiteral(">-- Chọn tác giả --</option>\r\n");

            
            #line 46 "..\..\Views\CategoryType\PatialView\_CategoryTypeParentDialog.cshtml"
                                        
            
            #line default
            #line hidden
            
            #line 46 "..\..\Views\CategoryType\PatialView\_CategoryTypeParentDialog.cshtml"
                                         foreach (var item in Model.AuthorSettings)
                                        {

            
            #line default
            #line hidden
WriteLiteral("                                            <option");

WriteAttribute("value", Tuple.Create(" value=\"", 3249), Tuple.Create("\"", 3265)
            
            #line 48 "..\..\Views\CategoryType\PatialView\_CategoryTypeParentDialog.cshtml"
, Tuple.Create(Tuple.Create("", 3257), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 3257), false)
);

WriteLiteral(">");

            
            #line 48 "..\..\Views\CategoryType\PatialView\_CategoryTypeParentDialog.cshtml"
                                                                Write(item.Name);

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n");

            
            #line 49 "..\..\Views\CategoryType\PatialView\_CategoryTypeParentDialog.cshtml"
                                        }

            
            #line default
            #line hidden
WriteLiteral("                                    </select>\r\n\r\n                                " +
"</div>\r\n                                <div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\r\n                                </div>\r\n                            </div>\r\n  " +
"                          <div");

WriteLiteral(" class=\"form-group row\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\"col-sm-8\"");

WriteLiteral("><label>Ảnh đại diện</label></div>\r\n                                    <div");

WriteLiteral(" class=\"col-sm-4\"");

WriteLiteral("><button");

WriteLiteral(" id=\"replace-photo\"");

WriteLiteral(" class=\"btn btn-success btn-sm\"");

WriteLiteral(">Thêm ảnh</button></div>\r\n                                    <input");

WriteLiteral(" type=\"file\"");

WriteLiteral(" id=\"replace-photo-tag\"");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(" name=\"FileThumbnail\"");

WriteLiteral(" accept=\"images/*\"");

WriteLiteral(">\r\n                                </div>\r\n                                <div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\r\n                                    <img");

WriteLiteral(" id=\"image-photo\"");

WriteLiteral(" src=\"\"");

WriteLiteral(" width=\"300\"");

WriteLiteral(" height=\"200\"");

WriteLiteral(" />\r\n                                </div>\r\n                            </div>\r\n" +
"                            <div");

WriteLiteral(" class=\"wrapper wrapper-content row\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"col-lg-12\"");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\"ibox float-e-margins\"");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\"ibox-title\"");

WriteLiteral(">\r\n                                            <h5>Nội dung</h5>\r\n               " +
"                             <button");

WriteLiteral(" id=\"edit\"");

WriteLiteral(" class=\"btn btn-primary btn-xs m-l-sm\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(">Edit</button>\r\n                                            <button");

WriteLiteral(" id=\"save\"");

WriteLiteral(" class=\"btn btn-primary  btn-xs\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(">Save</button>\r\n                                        </div>\r\n                 " +
"                       <div");

WriteLiteral(" class=\"ibox-content no-padding\"");

WriteLiteral(">\r\n                                            <div");

WriteLiteral(" class=\"wrapper p-md cateogry-type-content\"");

WriteLiteral(@">

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div>
                                <a");

WriteLiteral(" id=\"save-parent\"");

WriteLiteral(" class=\"btn btn-sm btn-primary pull-right m-t-n-xs\"");

WriteLiteral("><strong>Save</strong></a>\r\n                            </div>\r\n                 " +
"           <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"CategoryTypeId\"");

WriteLiteral(" class=\"category-type-id\"");

WriteLiteral(" value=\"0\"");

WriteLiteral(" />\r\n                            <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"CategoryId\"");

WriteLiteral(" class=\"category-id\"");

WriteLiteral(" value=\"0\"");

WriteLiteral(" />\r\n                            <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"Content\"");

WriteLiteral(" class=\"content\"");

WriteLiteral(" value=\"\"");

WriteLiteral(" />\r\n                        </form>\r\n                    </div>\r\n               " +
" </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
