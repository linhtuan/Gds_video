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
    
    #line 1 "..\..\Views\Shared\_Layout.cshtml"
    using System.Web.Optimization;
    
    #line default
    #line hidden
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using GdsVideoBackend;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/_Layout.cshtml")]
    public partial class _Views_Shared__Layout_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Shared__Layout_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <meta");

WriteLiteral(" charset=\"utf-8\"");

WriteLiteral(" />\r\n    <meta");

WriteLiteral(" name=\"viewport\"");

WriteLiteral(" content=\"width=device-width, initial-scale=1.0\"");

WriteLiteral(">\r\n    <title>");

            
            #line 7 "..\..\Views\Shared\_Layout.cshtml"
      Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral(" - My ASP.NET Application</title>\r\n");

WriteLiteral("    ");

            
            #line 8 "..\..\Views\Shared\_Layout.cshtml"
Write(Styles.Render("~/Content/inspinia"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 9 "..\..\Views\Shared\_Layout.cshtml"
Write(RenderSection("style", required: false));

            
            #line default
            #line hidden
WriteLiteral("\r\n</head>\r\n<body");

WriteLiteral(" class=\"pace-done\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"pace  pace-inactive\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"pace-progress\"");

WriteLiteral(" data-progress-text=\"100%\"");

WriteLiteral(" data-progress=\"99\"");

WriteLiteral(" style=\"transform: translate3d(100%, 0px, 0px);\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"pace-progress-inner\"");

WriteLiteral("></div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"pace-activity\"");

WriteLiteral("></div>\r\n    </div>\r\n    <div");

WriteLiteral(" id=\"wrapper\"");

WriteLiteral(">\r\n        <nav");

WriteLiteral(" class=\"navbar-default navbar-static-side\"");

WriteLiteral(" role=\"navigation\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"sidebar-collapse\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 21 "..\..\Views\Shared\_Layout.cshtml"
           Write(RenderSection("left_menu", required: false));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </nav>\r\n        <div");

WriteLiteral(" id=\"page-wrapper\"");

WriteLiteral(" class=\"gray-bg dashbard-1\"");

WriteLiteral(" style=\"min-height: 544px;\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"row border-bottom\"");

WriteLiteral(">\r\n                <nav");

WriteLiteral(" class=\"navbar navbar-static-top\"");

WriteLiteral(" role=\"navigation\"");

WriteLiteral(" style=\"margin-bottom: 0\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"navbar-header\"");

WriteLiteral(">\r\n                        <a");

WriteLiteral(" class=\"navbar-minimalize minimalize-styl-2 btn btn-primary \"");

WriteLiteral(" href=\"#\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-bars\"");

WriteLiteral("></i> </a>\r\n                    </div>\r\n                    <ul");

WriteLiteral(" class=\"nav navbar-top-links navbar-right\"");

WriteLiteral(">\r\n                        <li>\r\n                            <a");

WriteLiteral(" href=\"login.html\"");

WriteLiteral(">\r\n                                <i");

WriteLiteral(" class=\"fa fa-sign-out\"");

WriteLiteral("></i> Log out\r\n                            </a>\r\n                        </li>\r\n " +
"                       <li>\r\n                            <a");

WriteLiteral(" class=\"right-sidebar-toggle\"");

WriteLiteral(">\r\n                                <i");

WriteLiteral(" class=\"fa fa-tasks\"");

WriteLiteral("></i>\r\n                            </a>\r\n                        </li>\r\n         " +
"           </ul>\r\n                </nav>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-lg-12\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"wrapper wrapper-content\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 48 "..\..\Views\Shared\_Layout.cshtml"
                       Write(RenderBody());

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                   " +
" <div");

WriteLiteral(" class=\"footer\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"footer\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"pull-right\"");

WriteLiteral(@">
                                10GB of <strong>250GB</strong> Free.
                            </div>
                            <div>
                                <strong>Copyright</strong> Example Company © 2014-2015
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

");

WriteLiteral("    ");

            
            #line 66 "..\..\Views\Shared\_Layout.cshtml"
Write(Scripts.Render("~/bundles/base-lib-js"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 67 "..\..\Views\Shared\_Layout.cshtml"
Write(Scripts.Render("~/bundles/inspinia"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 68 "..\..\Views\Shared\_Layout.cshtml"
Write(Scripts.Render("~/bundles/base-inspinia"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 69 "..\..\Views\Shared\_Layout.cshtml"
Write(RenderSection("scripts", required: false));

            
            #line default
            #line hidden
WriteLiteral("\r\n</body>\r\n</html>\r\n");

        }
    }
}
#pragma warning restore 1591