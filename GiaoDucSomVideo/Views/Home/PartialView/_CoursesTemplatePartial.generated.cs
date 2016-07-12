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
    using GiaoDucSomVideo;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Home/PartialView/_CoursesTemplatePartial.cshtml")]
    public partial class _Views_Home_PartialView__CoursesTemplatePartial_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Home_PartialView__CoursesTemplatePartial_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n<script");

WriteLiteral(" id=\"coursesTemplate\"");

WriteLiteral(" type=\"text/x-jquery-tmpl\"");

WriteLiteral(@">
    <div class=""course_element hide"" id=""wrap_${CategoryId}_courses"">
        {{each CategoryTypes}}
        {{if $index == 0}}
        <div class=""col-md-8 col-sm-6 col-xs-12 course-item fadeInDown rectangle wow"">
            <div class=""img_wrap"">
                <img class=""img-responsive"" style=""width: 100%"" src=""data:image/${$value.MimeTypeImage};base64,${$value.ThumbnailImage}"">
                <a class=""shadow"" href=""${$value.CategoryTypeUrl}"" title=""${$value.CategoryTypeName}""></a>
            </div>
            <div class=""info"">
                <h3>
                    <a href=""${$value.CategoryTypeUrl}"" title=""${$value.CategoryTypeName}"">${$value.CategoryTypeName}</a>
                </h3>
            </div>
        </div>
        {{/if}}
        {{if $index != 0}}
        <div class=""col-md-4 col-sm-6 col-xs-12 course-item fadeInDown wow"">
            <div class=""img_wrap"">
                <img class=""img-responsive"" style=""width: 100%"" src=""data:image/${$value.MimeTypeImage};base64,${$value.ThumbnailImage}"">
                <a class=""shadow"" href=""${$value.CategoryTypeUrl}"" title=""${$value.CategoryTypeName}""></a>
            </div>
            <div class=""info"">
                <h3>
                    <a href=""${$value.CategoryTypeUrl}"" title=""${$value.CategoryTypeName}"">${$value.CategoryTypeName}</a>
                </h3>
            </div>
        </div>
        {{/if}}
        {{/each}}
    </div>
</script>");

        }
    }
}
#pragma warning restore 1591
