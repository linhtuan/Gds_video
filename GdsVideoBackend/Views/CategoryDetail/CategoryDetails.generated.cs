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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/CategoryDetail/CategoryDetails.cshtml")]
    public partial class _Views_CategoryDetail_CategoryDetails_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_CategoryDetail_CategoryDetails_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Views\CategoryDetail\CategoryDetails.cshtml"
  
    ViewBag.Title = "CategoryDetails";
    Layout = "~/Views/Shared/_Layout.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n");

DefineSection("style", () => {

WriteLiteral("\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 122), Tuple.Create("\"", 157)
, Tuple.Create(Tuple.Create("", 129), Tuple.Create<System.Object, System.Int32>(Href("~/Content/Style/dropzone.css")
, 129), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n");

});

WriteLiteral("\r\n");

DefineSection("left_menu", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 12 "..\..\Views\CategoryDetail\CategoryDetails.cshtml"
Write(Html.Partial("~/Views/PartialViews/_LeftMenuPartial.cshtml"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

WriteLiteral("\r\n<div");

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

WriteLiteral(" value=\"50\"");

WriteLiteral(">50</option>\r\n                                    <option");

WriteLiteral(" value=\"100\"");

WriteLiteral(">100</option>\r\n                                </select> records per page\r\n      " +
"                      </label>\r\n                        </div>\r\n                " +
"        <div");

WriteLiteral(" class=\"col-sm-3\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" data-toggle=\"modal\"");

WriteLiteral(" id=\"show-detail-box\"");

WriteLiteral(" onclick=\"bindingCategoryDetailFrom(this, \'add\')\"");

WriteLiteral(" class=\"btn btn-success btn-sm\"");

WriteLiteral(" href=\"#add-new-category-detail\"");

WriteLiteral(">Thêm bài học</a>\r\n                        </div>\r\n                    </div>\r\n  " +
"                  <div");

WriteLiteral(" class=\"dataTables_filter\"");

WriteLiteral(">\r\n                        <label>Search:<input");

WriteLiteral(" type=\"search\"");

WriteLiteral(" class=\"form-control input-sm\"");

WriteLiteral(" placeholder=\"\"");

WriteLiteral("></label>\r\n                    </div>\r\n                    <div");

WriteLiteral(" id=\"category_detail_Div\"");

WriteLiteral(">\r\n\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"paging_simple_numbers\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"col-lg-12\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"col-lg-4\"");

WriteLiteral("></div>\r\n                            <div");

WriteLiteral(" class=\"col-lg-4 paging-row hide\"");

WriteLiteral(">\r\n                                <a");

WriteLiteral(" class=\"btn btn-default btn-sm prev\"");

WriteLiteral(" href=\"#\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-angle-left\"");

WriteLiteral("></i> Previous</a>\r\n                                <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"input-mini\"");

WriteLiteral(">&nbsp;of&nbsp;<a");

WriteLiteral(" class=\"total-row\"");

WriteLiteral(">0</a>\r\n                                <a");

WriteLiteral(" class=\"btn btn-default btn-sm next\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(">Next <i");

WriteLiteral(" class=\"fa fa-angle-right\"");

WriteLiteral("></i></a>\r\n                            </div>\r\n                            <div");

WriteLiteral(" class=\"col-lg-4\"");

WriteLiteral("></div>\r\n                        </div>\r\n                    </div>\r\n            " +
"    </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div");

WriteLiteral(" id=\"add-new-category-detail\"");

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

WriteLiteral(" id=\"category-detail-form\"");

WriteLiteral(" class=\"row\"");

WriteLiteral(" role=\"form\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"form-group col-sm-12\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\r\n                                    <label>Tên chủ đề</label> <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" placeholder=\"Tên chủ đề\"");

WriteLiteral(" class=\"category-detail-name form-control\"");

WriteLiteral(">\r\n                                </div>\r\n                                <div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\r\n                                    <label>Chi tiết chủ đề</label> <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" placeholder=\"Chi tiết chủ đề\"");

WriteLiteral(" class=\"category-detail-content form-control\"");

WriteLiteral(">\r\n                                </div>\r\n                            </div>\r\n  " +
"                          <div");

WriteLiteral(" class=\"form-group col-sm-12\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"file-upload-container dropzone needsclick dz-clickable\"");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\"dz-message needsclick\"");

WriteLiteral(">\r\n                                        Drop files here or click to upload.<br" +
">\r\n                                        <span");

WriteLiteral(" class=\"note needsclick\"");

WriteLiteral(">(This is just a demo dropzone. Selected files are <strong>not</strong> actually " +
"uploaded.)</span>\r\n                                    </div>\r\n                 " +
"               </div>\r\n                            </div>\r\n                     " +
"       <div");

WriteLiteral(" class=\"form-group col-sm-12\"");

WriteLiteral(">\r\n                                <a");

WriteLiteral(" id=\"save\"");

WriteLiteral(" class=\"btn btn-sm btn-primary pull-right m-t-n-xs\"");

WriteLiteral("><strong>Save</strong></a>\r\n                            </div>\r\n                 " +
"           <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"category-detail-id\"");

WriteLiteral(" value=\"0\"");

WriteLiteral(" />\r\n                        </form>\r\n                    </div>\r\n               " +
" </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");

            
            #line 93 "..\..\Views\CategoryDetail\CategoryDetails.cshtml"
Write(Html.Partial("~/Views/CategoryDetail/PatialView/_PhysicalFileTemplate.cshtml"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 94 "..\..\Views\CategoryDetail\CategoryDetails.cshtml"
Write(Html.Partial("~/Views/CategoryDetail/PatialView/_CategoryDetailsTemplate.cshtml"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 4749), Tuple.Create("\"", 4779)
, Tuple.Create(Tuple.Create("", 4755), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/jquery.tmpl.js")
, 4755), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 4803), Tuple.Create("\"", 4840)
, Tuple.Create(Tuple.Create("", 4809), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/gds.paging.control.js")
, 4809), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 4864), Tuple.Create("\"", 4901)
, Tuple.Create(Tuple.Create("", 4870), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/gds.categoryDetail.js")
, 4870), false)
);

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteAttribute("src", Tuple.Create(" src=\"", 4948), Tuple.Create("\"", 4975)
, Tuple.Create(Tuple.Create("", 4954), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/dropzone.js")
, 4954), false)
);

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
        var setupDropzone = function setupDropzone() {
            if ($('.file-upload-container').length === 0) {
                return;
            }
            Dropzone.autoDiscover = false;
            var myDropzone = new Dropzone("".file-upload-container"", {
                previewTemplate: document.querySelector('#preview-template').innerHTML,
                url: '");

            
            #line 109 "..\..\Views\CategoryDetail\CategoryDetails.cshtml"
                 Write(Url.Action("UploadFile", "CategoryDetail"));

            
            #line default
            #line hidden
WriteLiteral("\',\r\n                method: \"POST\",\r\n                autoProcessQueue: true,\r\n   " +
"             clickable: [\'.file-upload-container\'],\r\n                parallelUpl" +
"oads: 1,\r\n                maxFilesize: 100, // in mb\r\n                thumbnailW" +
"idth: 150,\r\n                thumbnailHeight: 150,\r\n                thumbnail: fu" +
"nction(file, dataUrl) {\r\n                    if (file.previewElement) {\r\n       " +
"                 file.previewElement.classList.remove(\"dz-file-preview\");\r\n     " +
"                   var images = file.previewElement.querySelectorAll(\"[data-dz-t" +
"humbnail]\");\r\n                        for (var i = 0; i < images.length; i++) {\r" +
"\n                            var thumbnailElement = images[i];\r\n                " +
"            thumbnailElement.alt = file.name;\r\n                            thumb" +
"nailElement.src = dataUrl;\r\n                        }\r\n                        s" +
"etTimeout(function() { file.previewElement.classList.add(\"dz-image-preview\"); }," +
" 1);\r\n                    }\r\n                },\r\n                queuecomplete: " +
"function() {\r\n                    $(\'#add-new-category-detail\').modal(\'hide\');\r\n" +
"                    bindingCategoryDetails();\r\n                },\r\n             " +
"   sending: function(file, xhr, formData) {\r\n                    formData.append" +
"(\'categoryTypeId\', parseInt(gds.getQueryVariable(\'categoryTypeId\')));\r\n         " +
"           formData.append(\'categoryDetailId\', parseInt($(\"#category-detail-form" +
" #category-detail-id\").val()));\r\n                }\r\n            });\r\n\r\n        }" +
";\r\n        setupDropzone();\r\n    </script>\r\n    ");

});

        }
    }
}
#pragma warning restore 1591