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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/_LayoutHome.cshtml")]
    public partial class _Views_Shared__LayoutHome_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Shared__LayoutHome_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<!DOCTYPE html>\r\n\r\n<html>\r\n<head>\r\n    <meta");

WriteLiteral(" name=\"viewport\"");

WriteLiteral(" content=\"width=device-width\"");

WriteLiteral(" />\r\n    <title>");

            
            #line 6 "..\..\Views\Shared\_LayoutHome.cshtml"
      Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral("</title>\r\n");

WriteLiteral("    ");

            
            #line 7 "..\..\Views\Shared\_LayoutHome.cshtml"
Write(Styles.Render("~/Content/css"));

            
            #line default
            #line hidden
WriteLiteral("\r\n</head>\r\n    <body");

WriteLiteral(" class=\"home_page\"");

WriteLiteral(">\r\n        <header");

WriteLiteral(" class=\"home-header\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\r\n                <a");

WriteLiteral(" class=\"branding col-md-4 col-sm-6 col-xs-6\"");

WriteLiteral(" href=\"https://edumall.vn/\"");

WriteLiteral(">\r\n                    <img");

WriteLiteral(" src=\"./Edumall_files/logo-f9d61291714815931bf28b0b1c7ef8c922c843936f4ca880d4557c" +
"e93a55223f.png\"");

WriteLiteral(" alt=\"Logo f9d61291714815931bf28b0b1c7ef8c922c843936f4ca880d4557ce93a55223f\"");

WriteLiteral(">\r\n                </a>\r\n                <div");

WriteLiteral(" class=\"right-box\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"col-md-5 quick-contact\"");

WriteLiteral(">\r\n                        <a>\r\n                            <i");

WriteLiteral(" class=\"fa fa-envelope\"");

WriteLiteral("></i>\r\n                            <strong>Email:</strong>\r\n                     " +
"       cskh@edumall.vn\r\n                        </a>\r\n                        <a" +
">\r\n                            <i");

WriteLiteral(" class=\"fa fa-phone\"");

WriteLiteral("></i>\r\n                            <strong>Tel:</strong>\r\n                       " +
"     1800.6816\r\n                        </a>\r\n                    </div>\r\n      " +
"              <div");

WriteLiteral(" class=\"col-md-3 col-sm-6 col-xs-6 actions act-hd\"");

WriteLiteral(">\r\n                        <a");

WriteLiteral(" data-target=\"#register-modal\"");

WriteLiteral(" data-toggle=\"modal\"");

WriteLiteral(" href=\"https://edumall.vn/#\"");

WriteLiteral(">Đăng ký</a>\r\n                        <a");

WriteLiteral(" class=\"btn-login\"");

WriteLiteral(" data-target=\"#login-modal\"");

WriteLiteral(" data-toggle=\"modal\"");

WriteLiteral(" href=\"https://edumall.vn/#\"");

WriteLiteral(" id=\"login_btn\"");

WriteLiteral(">Đăng nhập</a>\r\n                        <!-- Make it able to disable modal to use" +
" this modal in signin page -->\r\n                        <div");

WriteLiteral(" class=\"modal fade\"");

WriteLiteral(" id=\"register-modal\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"modal-dialog\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"modal-content\"");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\"modal-header\"");

WriteLiteral(">\r\n                                        <button");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(" class=\"close\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(">×</button>\r\n                                        <h3");

WriteLiteral(" class=\"modal-title\"");

WriteLiteral(">Đăng ký</h3>\r\n                                    </div>\r\n                      " +
"              <div");

WriteLiteral(" class=\"modal-body\"");

WriteLiteral(">\r\n                                        <form");

WriteLiteral(" action=\"https://edumall.vn/users\"");

WriteLiteral(" method=\"post\"");

WriteLiteral(">\r\n                                            <p");

WriteLiteral(" class=\"sub-title\"");

WriteLiteral(">Đăng ký bằng email</p>\r\n                                            <div");

WriteLiteral(" class=\"form-control-wrapper\"");

WriteLiteral(">\r\n                                                <input");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" id=\"name\"");

WriteLiteral(" name=\"user[name]\"");

WriteLiteral(" placeholder=\"Họ và tên\"");

WriteLiteral(" required=\"true\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" value=\"\"");

WriteLiteral(">\r\n                                            </div>\r\n                          " +
"                  <div");

WriteLiteral(" class=\"form-control-wrapper\"");

WriteLiteral(">\r\n                                                <input");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" id=\"email\"");

WriteLiteral(" name=\"user[email]\"");

WriteLiteral(" placeholder=\"Email\"");

WriteLiteral(" required=\"true\"");

WriteLiteral(" type=\"email\"");

WriteLiteral(" value=\"\"");

WriteLiteral(">\r\n                                            </div>\r\n                          " +
"                  <div");

WriteLiteral(" class=\"form-control-wrapper\"");

WriteLiteral(">\r\n                                                <input");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" id=\"password\"");

WriteLiteral(" name=\"user[password]\"");

WriteLiteral(" placeholder=\"Mật khẩu\"");

WriteLiteral(" required=\"true\"");

WriteLiteral(" type=\"password\"");

WriteLiteral(">\r\n                                            </div>\r\n                          " +
"                  <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"authenticity_token\"");

WriteLiteral(" id=\"authenticity_token\"");

WriteLiteral(" value=\"hVhCT6YwA4RoVZmx60+/g7vUv6O9qikfyPMy7GYzb2uD9wqu0ZtJG2eeBa8ZZAY2AksUUze/5" +
"B7dzxDMjoopBg==\"");

WriteLiteral(">\r\n                                            <div");

WriteLiteral(" class=\"form-control-wrapper\"");

WriteLiteral(">\r\n                                                <input");

WriteLiteral(" class=\"btn btn-login-submit\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Đăng ký\"");

WriteLiteral(">\r\n                                            </div>\r\n                          " +
"              </form>\r\n                                    </div>\r\n             " +
"                       <div");

WriteLiteral(" class=\"modal-footer\"");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\"forgot-password-link clearfix\"");

WriteLiteral(">\r\n                                            <a");

WriteLiteral(" class=\"btn btn-link show-social-link\"");

WriteLiteral(" href=\"https://edumall.vn/#\"");

WriteLiteral(">\r\n                                                Đăng ký với tài khoản mạng xã " +
"hội\r\n                                                <span>\r\n                   " +
"                                 <i");

WriteLiteral(" class=\"fa fa-angle-down\"");

WriteLiteral("></i>\r\n                                                </span>\r\n                 " +
"                           </a>\r\n                                            <di" +
"v");

WriteLiteral(" class=\"form-control-wrapper social-area\"");

WriteLiteral(">\r\n                                                <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                                                    <div");

WriteLiteral(" class=\"col-md-6\"");

WriteLiteral(">\r\n                                                        <a");

WriteLiteral(" class=\"btn-facebook\"");

WriteLiteral(" href=\"https://edumall.vn/users/auth/facebook\"");

WriteLiteral(">\r\n                                                            <i");

WriteLiteral(" class=\"left fa fa-facebook\"");

WriteLiteral("></i>\r\n                                                            <span");

WriteLiteral(" class=\"left\"");

WriteLiteral(">Facebook</span>\r\n                                                        </a>\r\n " +
"                                                   </div>\r\n                     " +
"                               <div");

WriteLiteral(" class=\"col-md-6\"");

WriteLiteral(">\r\n                                                        <a");

WriteLiteral(" class=\"btn-google\"");

WriteLiteral(" href=\"https://edumall.vn/users/auth/google_oauth2\"");

WriteLiteral(">\r\n                                                            <i");

WriteLiteral(" class=\"left fa fa-google-plus\"");

WriteLiteral("></i>\r\n                                                            <span");

WriteLiteral(" class=\"left\"");

WriteLiteral(@">Google+</span>
                                                        </a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <p");

WriteLiteral(" class=\"bottom-text\"");

WriteLiteral(">\r\n                                            Đã có tài khoản?\r\n                " +
"                            <a");

WriteLiteral(" class=\"btn-link\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(" data-target=\"#login-modal\"");

WriteLiteral(" data-toggle=\"modal\"");

WriteLiteral(" href=\"https://edumall.vn/#\"");

WriteLiteral(">Đăng nhập</a>\r\n                                        </p>\r\n                   " +
"                 </div>\r\n                                </div>\r\n               " +
"             </div>\r\n                        </div>\r\n\r\n                        <" +
"div");

WriteLiteral(" class=\"modal fade\"");

WriteLiteral(" id=\"fogot-password-dialog\"");

WriteLiteral(" tabindex=\"-1\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"modal-dialog\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"modal-content\"");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\"modal-header\"");

WriteLiteral(">\r\n                                        <button");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(" class=\"close\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(">×</button>\r\n                                        <h3");

WriteLiteral(" class=\"modal-title\"");

WriteLiteral(">Lấy lại mật khẩu</h3>\r\n                                    </div>\r\n             " +
"                       <div");

WriteLiteral(" class=\"modal-body\"");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\"forgot-password-content\"");

WriteLiteral(">\r\n                                            <div");

WriteLiteral(" class=\"form-control-wrapper\"");

WriteLiteral(">\r\n                                                <input");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" id=\"email-reset\"");

WriteLiteral(" name=\"email\"");

WriteLiteral(" placeholder=\"Email đăng nhập\"");

WriteLiteral(" required=\"true\"");

WriteLiteral(" type=\"email\"");

WriteLiteral(">\r\n                                            </div>\r\n                          " +
"                  <div");

WriteLiteral(" class=\"form-control-wrapper\"");

WriteLiteral(">\r\n                                                <a");

WriteLiteral(" class=\"btn reset-password-button\"");

WriteLiteral(">Đặt lại mật khẩu</a>\r\n                                            </div>\r\n      " +
"                                      <div");

WriteLiteral(" class=\"form-control-wrapper\"");

WriteLiteral(">\r\n                                                <span>Hoặc</span>\r\n           " +
"                                 </div>\r\n                                       " +
"     <div");

WriteLiteral(" class=\"form-control-wrapper\"");

WriteLiteral(">\r\n                                                <a");

WriteLiteral(" class=\"btn btn-link\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(" data-target=\"#login-modal\"");

WriteLiteral(" data-toggle=\"modal\"");

WriteLiteral(">Đăng nhập</a>\r\n                                            </div>\r\n             " +
"                           </div>\r\n                                        <div");

WriteLiteral(" class=\"forgot-password-content-success\"");

WriteLiteral(" style=\"display: none;\"");

WriteLiteral(">\r\n                                            <div");

WriteLiteral(" class=\"form-control-wrapper\"");

WriteLiteral(">\r\n                                                <h5");

WriteLiteral(" class=\"text-success\"");

WriteLiteral(@">Vui lòng kiểm tra email để đặt lại mật khẩu</h5>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <!-- Make it able to disable modal to use this modal in signin page -->
                        <div");

WriteLiteral(" class=\"modal fade\"");

WriteLiteral(" id=\"login-modal\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"modal-dialog\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"modal-content\"");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\"modal-header\"");

WriteLiteral(">\r\n                                        <button");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(" class=\"close\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(">×</button>\r\n                                        <h3");

WriteLiteral(" class=\"modal-title\"");

WriteLiteral(">Đăng nhập</h3>\r\n                                    </div>\r\n                    " +
"                <div");

WriteLiteral(" class=\"modal-body\"");

WriteLiteral(">\r\n                                        <form");

WriteLiteral(" action=\"https://edumall.vn/users/sign_in\"");

WriteLiteral(" method=\"post\"");

WriteLiteral(">\r\n                                            <p");

WriteLiteral(" class=\"sub-title\"");

WriteLiteral(">Đăng nhập bằng email</p>\r\n                                            <div");

WriteLiteral(" class=\"form-control-wrapper\"");

WriteLiteral(">\r\n                                                <input");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" id=\"email\"");

WriteLiteral(" name=\"user[email]\"");

WriteLiteral(" placeholder=\"Email\"");

WriteLiteral(" required=\"true\"");

WriteLiteral(" type=\"email\"");

WriteLiteral(" value=\"\"");

WriteLiteral(">\r\n                                            </div>\r\n                          " +
"                  <div");

WriteLiteral(" class=\"form-control-wrapper\"");

WriteLiteral(">\r\n                                                <input");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" id=\"password\"");

WriteLiteral(" name=\"user[password]\"");

WriteLiteral(" placeholder=\"Mật khẩu\"");

WriteLiteral(" required=\"true\"");

WriteLiteral(" type=\"password\"");

WriteLiteral(">\r\n                                            </div>\r\n                          " +
"                  <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"authenticity_token\"");

WriteLiteral(" id=\"authenticity_token\"");

WriteLiteral(" value=\"hVhCT6YwA4RoVZmx60+/g7vUv6O9qikfyPMy7GYzb2uD9wqu0ZtJG2eeBa8ZZAY2AksUUze/5" +
"B7dzxDMjoopBg==\"");

WriteLiteral(">\r\n                                            <div");

WriteLiteral(" class=\"form-control-wrapper\"");

WriteLiteral(">\r\n                                                <input");

WriteLiteral(" class=\"btn btn-login-submit\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Đăng nhập\"");

WriteLiteral(">\r\n                                            </div>\r\n                          " +
"              </form>\r\n                                        <p");

WriteLiteral(" class=\"forgot-password-link\"");

WriteLiteral(">\r\n                                            <a");

WriteLiteral(" class=\"btn-link\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(" data-target=\"#fogot-password-dialog\"");

WriteLiteral(" data-toggle=\"modal\"");

WriteLiteral(" href=\"https://edumall.vn/#\"");

WriteLiteral(" id=\"forgot-password-button\"");

WriteLiteral(">Quên mật khẩu đăng nhập?</a>\r\n                                        </p>\r\n    " +
"                                </div>\r\n                                    <div" +
"");

WriteLiteral(" class=\"modal-footer\"");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\"forgot-password-link clearfix\"");

WriteLiteral(">\r\n                                            <a");

WriteLiteral(" class=\"btn btn-link show-social-link\"");

WriteLiteral(" href=\"https://edumall.vn/#\"");

WriteLiteral(">\r\n                                                Đăng nhập với tài khoản mạng x" +
"ã hội\r\n                                                <span>\r\n                 " +
"                                   <i");

WriteLiteral(" class=\"fa fa-angle-down\"");

WriteLiteral("></i>\r\n                                                </span>\r\n                 " +
"                           </a>\r\n                                            <di" +
"v");

WriteLiteral(" class=\"form-control-wrapper social-area\"");

WriteLiteral(">\r\n                                                <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                                                    <div");

WriteLiteral(" class=\"col-md-6\"");

WriteLiteral(">\r\n                                                        <a");

WriteLiteral(" class=\"btn-facebook\"");

WriteLiteral(" href=\"https://edumall.vn/users/auth/facebook\"");

WriteLiteral(">\r\n                                                            <i");

WriteLiteral(" class=\"left fa fa-facebook\"");

WriteLiteral("></i>\r\n                                                            <span");

WriteLiteral(" class=\"left\"");

WriteLiteral(">Facebook</span>\r\n                                                        </a>\r\n " +
"                                                   </div>\r\n                     " +
"                               <div");

WriteLiteral(" class=\"col-md-6\"");

WriteLiteral(">\r\n                                                        <a");

WriteLiteral(" class=\"btn-google\"");

WriteLiteral(" href=\"https://edumall.vn/users/auth/google_oauth2\"");

WriteLiteral(">\r\n                                                            <i");

WriteLiteral(" class=\"left fa fa-google-plus\"");

WriteLiteral("></i>\r\n                                                            <span");

WriteLiteral(" class=\"left\"");

WriteLiteral(@">Google+</span>
                                                        </a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <p");

WriteLiteral(" class=\"bottom-text\"");

WriteLiteral(">\r\n                                            Chưa có tài khoản?\r\n              " +
"                              <a");

WriteLiteral(" class=\"btn-link\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(" data-target=\"#register-modal\"");

WriteLiteral(" data-toggle=\"modal\"");

WriteLiteral(" href=\"https://edumall.vn/#\"");

WriteLiteral(@">Đăng ký</a>
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </header>
");

WriteLiteral("        ");

            
            #line 187 "..\..\Views\Shared\_LayoutHome.cshtml"
   Write(RenderBody());

            
            #line default
            #line hidden
WriteLiteral("\r\n        <footer");

WriteLiteral(" class=\"footer-wrap\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"foo-top clearfix\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"pull-left signature\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" href=\"http://online.gov.vn/HomePage/WebsiteDisplay.aspx?DocId=22565\"");

WriteLiteral(">\r\n                                <img");

WriteLiteral(" alt=\"\"");

WriteLiteral(" src=\"http://online.gov.vn/seals/BQT27R4kAS7t4HnfbMcDEA==.jpgx\"");

WriteLiteral(" title=\"\"");

WriteLiteral(">\r\n                            </a>\r\n                        </div>\r\n            " +
"            <div");

WriteLiteral(" class=\"pull-right social\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" class=\"facebook\"");

WriteLiteral(" href=\"https://www.facebook.com/Edumall.vn\"");

WriteLiteral(" target=\"_blank\"");

WriteLiteral(">\r\n                                <img");

WriteLiteral(" src=\"//static.edumall.vn/assets/stencil/icon/facebook-443909c01eeab7cece5f632063" +
"6aa31cee355643d8394db2fbd186f4ae6f8147.png\"");

WriteLiteral(" alt=\"Facebook 443909c01eeab7cece5f6320636aa31cee355643d8394db2fbd186f4ae6f8147\"");

WriteLiteral(">\r\n                            </a>\r\n                            <a");

WriteLiteral(" class=\"youtube\"");

WriteLiteral(" href=\"https://www.youtube.com/channel/UC33MQ240VzqlTHNJ5vMcZhQ\"");

WriteLiteral(" target=\"_blank\"");

WriteLiteral(">\r\n                                <img");

WriteLiteral(" src=\"//static.edumall.vn/assets/stencil/icon/youtube-71fe620d1b39fe40608f1044d84" +
"cc3e2100a35959341bf81056756d5bb0ab2e8.png\"");

WriteLiteral(" alt=\"Youtube 71fe620d1b39fe40608f1044d84cc3e2100a35959341bf81056756d5bb0ab2e8\"");

WriteLiteral(">\r\n                            </a>\r\n                        </div>\r\n            " +
"        </div>\r\n                    <div");

WriteLiteral(" class=\"foo-content clearfix\"");

WriteLiteral(">\r\n                        <div");

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

WriteLiteral(">\r\n                            <h4>Về TOPICA</h4>\r\n                            <u" +
"l>\r\n                                <li>\r\n                                    <p" +
">\r\n                                        <a");

WriteLiteral(" href=\"https://topica.edu.vn/gioi-thieu.html\"");

WriteLiteral(" target=\"_blank\"");

WriteLiteral(">Giới thiệu TOPICA</a>\r\n                                    </p>\r\n               " +
"                 </li>\r\n                                <li>\r\n                  " +
"                  <p>\r\n                                        <a");

WriteLiteral(" href=\"https://topica.edu.vn/category/hoat-dong-noi-bat/\"");

WriteLiteral(" target=\"_blank\"");

WriteLiteral(">Hoạt động nổi bật</a>\r\n                                    </p>\r\n               " +
"                 </li>\r\n                                <li>\r\n                  " +
"                  <p>\r\n                                        <a");

WriteLiteral(" href=\"https://topica.edu.vn/lich-su.html\"");

WriteLiteral(" target=\"_blank\"");

WriteLiteral(">Lịch sử phát triển</a>\r\n                                    </p>\r\n              " +
"                  </li>\r\n                                <li>\r\n                 " +
"                   <p>\r\n                                        <a");

WriteLiteral(" href=\"https://topica.edu.vn/category/cong-nghe/\"");

WriteLiteral(" target=\"_blank\"");

WriteLiteral(">Công nghệ</a>\r\n                                    </p>\r\n                       " +
"         </li>\r\n                            </ul>\r\n                        </div" +
">\r\n                        <div");

WriteLiteral(" class=\"col col-md-2 about-us\"");

WriteLiteral(">\r\n                            <h4>Về Edumall</h4>\r\n                            <" +
"ul>\r\n                                <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                                    <li>\r\n                                    " +
"    <p>\r\n                                            <a");

WriteLiteral(" href=\"/about\"");

WriteLiteral(">Giới thiệu</a>\r\n                                        </p>\r\n                  " +
"                  </li>\r\n                                    <li>\r\n             " +
"                           <p>\r\n                                            <a");

WriteLiteral(" href=\"/faq\"");

WriteLiteral(">Câu hỏi thường gặp</a>\r\n                                        </p>\r\n          " +
"                          </li>\r\n                                    <li>\r\n     " +
"                                   <p>\r\n                                        " +
"    <a");

WriteLiteral(" href=\"/terms\"");

WriteLiteral(">Điều khoản sử dụng</a>\r\n                                        </p>\r\n          " +
"                          </li>\r\n                                    <li>\r\n     " +
"                                   <p>\r\n                                        " +
"    <a");

WriteLiteral(" href=\"/policy\"");

WriteLiteral(">Quy chế hoạt động</a>\r\n                                        </p>\r\n           " +
"                         </li>\r\n                                    <li>\r\n      " +
"                                  <p>\r\n                                         " +
"   <a");

WriteLiteral(" href=\"/security_policy\"");

WriteLiteral(">Chính sách bảo mật</a>\r\n                                        </p>\r\n          " +
"                          </li>\r\n                                    <li>\r\n     " +
"                                   <p>\r\n                                        " +
"    <a");

WriteLiteral(" href=\"/dispute_solution\"");

WriteLiteral(@">Cơ chế giải quyết tranh chấp</a>
                                        </p>
                                    </li>
                                    <li>
                                        <p>
                                            <a");

WriteLiteral(" href=\"/faq#faq_no_9\"");

WriteLiteral(">Chính sách hoàn học phí</a>\r\n                                        </p>\r\n     " +
"                               </li>\r\n                                </div>\r\n  " +
"                          </ul>\r\n                        </div>\r\n               " +
"         <div");

WriteLiteral(" class=\"col col-md-3 col-sm-6 contact\"");

WriteLiteral(">\r\n                            <h4>Liên hệ</h4>\r\n                            <p");

WriteLiteral(" class=\"hotline\"");

WriteLiteral(">\r\n                                <i");

WriteLiteral(" class=\"fa fa-phone\"");

WriteLiteral("></i>\r\n                                1800.6816 (Trong giờ hành chính)\r\n        " +
"                    </p>\r\n                            <p");

WriteLiteral(" class=\"mail\"");

WriteLiteral(">\r\n                                <i");

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

WriteLiteral("        ");

            
            #line 300 "..\..\Views\Shared\_LayoutHome.cshtml"
   Write(Scripts.Render("~/bundles/base-lib-js"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 301 "..\..\Views\Shared\_LayoutHome.cshtml"
   Write(RenderSection("scripts", required: false));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </body>\r\n\r\n</html>\r\n");

        }
    }
}
#pragma warning restore 1591
