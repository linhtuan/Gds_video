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

            
            #line 6 "..\..\Views\Shared\_Layout.cshtml"
      Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral(" - My ASP.NET Application</title>\r\n");

WriteLiteral("    ");

            
            #line 7 "..\..\Views\Shared\_Layout.cshtml"
Write(Styles.Render("~/Content/css"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    ");

WriteLiteral("\r\n\r\n</head>\r\n<body");

WriteLiteral(" class=\"courses_page _hasRecRequest _detail_page\"");

WriteLiteral(">\r\n    <header>\r\n        <div");

WriteLiteral(" class=\"header-inner rel\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"container-fluid\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"header-col header-col-left\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"hd-categories pull-left\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"btn-group cats-dropdown\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" aria-expanded=\"false\"");

WriteLiteral(" aria-haspopup=\"true\"");

WriteLiteral(" class=\"dropdown-toggle active-nav-2 active-nav-with-text\"");

WriteLiteral(" data-dropdown-container=\".slider-sidebar-wrapper.slider-sidebar-mobile\"");

WriteLiteral(" data-fixed=\"false\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(">\r\n                                <i");

WriteLiteral(" class=\"fa fa-bars\"");

WriteLiteral("></i>\r\n                                <span");

WriteLiteral(" class=\"active-nav-text\"");

WriteLiteral(">Danh sách chủ đề</span>\r\n                            </div>\r\n");

WriteLiteral("                            ");

            
            #line 22 "..\..\Views\Shared\_Layout.cshtml"
                       Write(Html.Partial("_MenuTopPage"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                   " +
" <div");

WriteLiteral(" class=\"hd-search pull-left\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"search-box\"");

WriteLiteral(">\r\n                            <form");

WriteLiteral(" action=\"https://edumall.vn/search\"");

WriteLiteral(" class=\"search-form\"");

WriteLiteral(" method=\"GET\"");

WriteLiteral(">\r\n                                <input");

WriteLiteral(" autofocus=\"\"");

WriteLiteral(" class=\"course-search\"");

WriteLiteral(" name=\"q\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(">\r\n                                <button");

WriteLiteral(" type=\"submit\"");

WriteLiteral(">\r\n                                    <i");

WriteLiteral(" class=\"fa fa-search\"");

WriteLiteral("></i>\r\n                                </button>\r\n                            </f" +
"orm>\r\n                        </div>\r\n\r\n                        <div");

WriteLiteral(" class=\"btn-group search-dropdown\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" aria-expanded=\"false\"");

WriteLiteral(" aria-haspopup=\"true\"");

WriteLiteral(" class=\"dropdown-toggle\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(">\r\n                                <i");

WriteLiteral(" class=\"fa fa-search\"");

WriteLiteral("></i>\r\n                            </div>\r\n                            <div");

WriteLiteral(" class=\"dropdown-menu\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"search-box\"");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\"search-box\"");

WriteLiteral(">\r\n                                        <form");

WriteLiteral(" action=\"https://edumall.vn/search\"");

WriteLiteral(" class=\"search-form\"");

WriteLiteral(" method=\"GET\"");

WriteLiteral(">\r\n                                            <input");

WriteLiteral(" autofocus=\"\"");

WriteLiteral(" class=\"course-search\"");

WriteLiteral(" name=\"q\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(">\r\n                                            <button");

WriteLiteral(" type=\"submit\"");

WriteLiteral(">\r\n                                                <i");

WriteLiteral(" class=\"fa fa-search\"");

WriteLiteral(@"></i>
                                            </button>
                                        </form>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div");

WriteLiteral(" class=\"header-col header-col-mid\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"hd-brand\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"logo\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" class=\"logo-medium\"");

WriteLiteral(" href=\"https://edumall.vn/courses\"");

WriteLiteral("><img");

WriteLiteral(" src=\"./Dạy con tự lập_files/logo-48d3ab68d6df4a0495936bf032699492618137912766d9a" +
"0e40b9dbc3d9f56f5.svg\"");

WriteLiteral(" alt=\"Logo 48d3ab68d6df4a0495936bf032699492618137912766d9a0e40b9dbc3d9f56f5\"");

WriteLiteral("></a>\r\n                            <a");

WriteLiteral(" class=\"logo-small\"");

WriteLiteral(" href=\"https://edumall.vn/courses\"");

WriteLiteral("><img");

WriteLiteral(" src=\"./Dạy con tự lập_files/logo-small-07817b98821d437f07ae018f758e6c8fdfda5a3bd" +
"6908ae5810acb2838804e5f.svg\"");

WriteLiteral(" alt=\"Logo small 07817b98821d437f07ae018f758e6c8fdfda5a3bd6908ae5810acb2838804e5f" +
"\"");

WriteLiteral("></a>\r\n                        </div>\r\n                    </div>\r\n              " +
"  </div>\r\n");

WriteLiteral("                ");

            
            #line 63 "..\..\Views\Shared\_Layout.cshtml"
           Write(Html.Partial("_LoginPartial"));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </header>\r\n");

WriteLiteral("    ");

            
            #line 67 "..\..\Views\Shared\_Layout.cshtml"
Write(RenderBody());

            
            #line default
            #line hidden
WriteLiteral("\r\n    <footer");

WriteLiteral(" class=\"footer-wrap\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"foo-top clearfix\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"pull-left signature\"");

WriteLiteral(">\r\n                        <a");

WriteLiteral(" href=\"http://online.gov.vn/HomePage/WebsiteDisplay.aspx?DocId=22565\"");

WriteLiteral(">\r\n                            <img");

WriteLiteral(" alt=\"\"");

WriteLiteral(" src=\"http://online.gov.vn/seals/BQT27R4kAS7t4HnfbMcDEA==.jpgx\"");

WriteLiteral(" title=\"\"");

WriteLiteral(">\r\n                        </a>\r\n                    </div>\r\n                    " +
"<div");

WriteLiteral(" class=\"pull-right social\"");

WriteLiteral(">\r\n                        <a");

WriteLiteral(" class=\"facebook\"");

WriteLiteral(" href=\"https://www.facebook.com/Edumall.vn\"");

WriteLiteral(" target=\"_blank\"");

WriteLiteral(">\r\n                            <img");

WriteLiteral(" src=\"//static.edumall.vn/assets/stencil/icon/facebook-443909c01eeab7cece5f632063" +
"6aa31cee355643d8394db2fbd186f4ae6f8147.png\"");

WriteLiteral(" alt=\"Facebook 443909c01eeab7cece5f6320636aa31cee355643d8394db2fbd186f4ae6f8147\"");

WriteLiteral(">\r\n                        </a>\r\n                        <a");

WriteLiteral(" class=\"youtube\"");

WriteLiteral(" href=\"https://www.youtube.com/channel/UC33MQ240VzqlTHNJ5vMcZhQ\"");

WriteLiteral(" target=\"_blank\"");

WriteLiteral(">\r\n                            <img");

WriteLiteral(" src=\"//static.edumall.vn/assets/stencil/icon/youtube-71fe620d1b39fe40608f1044d84" +
"cc3e2100a35959341bf81056756d5bb0ab2e8.png\"");

WriteLiteral(" alt=\"Youtube 71fe620d1b39fe40608f1044d84cc3e2100a35959341bf81056756d5bb0ab2e8\"");

WriteLiteral(">\r\n                        </a>\r\n                    </div>\r\n                </di" +
"v>\r\n                <div");

WriteLiteral(" class=\"foo-content clearfix\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"col col-md-5 col-sm-6 info\"");

WriteLiteral(@">
                        <h4>TOPICA Edumall</h4>
                        <p>CÔNG TY CỔ PHẦN GIÁO DỤC TOPICA ENGLISH</p>
                        <p>MST: 0106291976 do Sở Kế hoạch và Đầu tư Tp.Hà Nội</p>
                        <p>cấp ngày 27 tháng 08 năm 2013</p>
                        <p>Đại diện: Ông Dương Hữu Quang</p>
                        <p>Trụ sở chính: Tầng 3 số 75 Phương Mai, Đống Đa, Hà Nội.</p>
                        <p>© 2016 Edumall. All rights reserved</p>
                    </div>
                    <div");

WriteLiteral(" class=\"col col-md-2 topica\"");

WriteLiteral(">\r\n                        <h4>Về TOPICA</h4>\r\n                        <ul>\r\n    " +
"                        <li>\r\n                                <p>\r\n             " +
"                       <a");

WriteLiteral(" href=\"https://topica.edu.vn/gioi-thieu.html\"");

WriteLiteral(" target=\"_blank\"");

WriteLiteral(">Giới thiệu TOPICA</a>\r\n                                </p>\r\n                   " +
"         </li>\r\n                            <li>\r\n                              " +
"  <p>\r\n                                    <a");

WriteLiteral(" href=\"https://topica.edu.vn/category/hoat-dong-noi-bat/\"");

WriteLiteral(" target=\"_blank\"");

WriteLiteral(">Hoạt động nổi bật</a>\r\n                                </p>\r\n                   " +
"         </li>\r\n                            <li>\r\n                              " +
"  <p>\r\n                                    <a");

WriteLiteral(" href=\"https://topica.edu.vn/lich-su.html\"");

WriteLiteral(" target=\"_blank\"");

WriteLiteral(">Lịch sử phát triển</a>\r\n                                </p>\r\n                  " +
"          </li>\r\n                            <li>\r\n                             " +
"   <p>\r\n                                    <a");

WriteLiteral(" href=\"https://topica.edu.vn/category/cong-nghe/\"");

WriteLiteral(" target=\"_blank\"");

WriteLiteral(">Công nghệ</a>\r\n                                </p>\r\n                           " +
" </li>\r\n                        </ul>\r\n                    </div>\r\n             " +
"       <div");

WriteLiteral(" class=\"col col-md-2 about-us\"");

WriteLiteral(">\r\n                        <h4>Về Edumall</h4>\r\n                        <ul>\r\n   " +
"                         <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                                <li>\r\n                                    <p>\r" +
"\n                                        <a");

WriteLiteral(" href=\"/about\"");

WriteLiteral(">Giới thiệu</a>\r\n                                    </p>\r\n                      " +
"          </li>\r\n                                <li>\r\n                         " +
"           <p>\r\n                                        <a");

WriteLiteral(" href=\"/faq\"");

WriteLiteral(">Câu hỏi thường gặp</a>\r\n                                    </p>\r\n              " +
"                  </li>\r\n                                <li>\r\n                 " +
"                   <p>\r\n                                        <a");

WriteLiteral(" href=\"/terms\"");

WriteLiteral(">Điều khoản sử dụng</a>\r\n                                    </p>\r\n              " +
"                  </li>\r\n                                <li>\r\n                 " +
"                   <p>\r\n                                        <a");

WriteLiteral(" href=\"/policy\"");

WriteLiteral(">Quy chế hoạt động</a>\r\n                                    </p>\r\n               " +
"                 </li>\r\n                                <li>\r\n                  " +
"                  <p>\r\n                                        <a");

WriteLiteral(" href=\"/security_policy\"");

WriteLiteral(">Chính sách bảo mật</a>\r\n                                    </p>\r\n              " +
"                  </li>\r\n                                <li>\r\n                 " +
"                   <p>\r\n                                        <a");

WriteLiteral(" href=\"/dispute_solution\"");

WriteLiteral(">Cơ chế giải quyết tranh chấp</a>\r\n                                    </p>\r\n    " +
"                            </li>\r\n                                <li>\r\n       " +
"                             <p>\r\n                                        <a");

WriteLiteral(" href=\"/faq#faq_no_9\"");

WriteLiteral(">Chính sách hoàn học phí</a>\r\n                                    </p>\r\n         " +
"                       </li>\r\n                            </div>\r\n              " +
"          </ul>\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"col col-md-3 col-sm-6 contact\"");

WriteLiteral(">\r\n                        <h4>Liên hệ</h4>\r\n                        <p");

WriteLiteral(" class=\"hotline\"");

WriteLiteral(">\r\n                            <i");

WriteLiteral(" class=\"fa fa-phone\"");

WriteLiteral("></i>\r\n                            1800.6816 (Trong giờ hành chính)\r\n            " +
"            </p>\r\n                        <p");

WriteLiteral(" class=\"mail\"");

WriteLiteral(">\r\n                            <i");

WriteLiteral(" class=\"fa fa-envelope\"");

WriteLiteral(@"></i>
                            cskh@edumall.vn
                        </p>
                        <p>HN - 75 Phương Mai, Đống Đa, HN</p>
                        <p>HCM - 58/10 Thành Thái, P.12, Q.10, HCM</p>
                    </div>
                </div>
            </div>
        </div>
    </footer>
");

WriteLiteral("    ");

            
            #line 180 "..\..\Views\Shared\_Layout.cshtml"
Write(Scripts.Render("~/bundles/base-lib-js"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 181 "..\..\Views\Shared\_Layout.cshtml"
Write(RenderSection("scripts", required: false));

            
            #line default
            #line hidden
WriteLiteral("\r\n</body>\r\n</html>\r\n");

        }
    }
}
#pragma warning restore 1591
