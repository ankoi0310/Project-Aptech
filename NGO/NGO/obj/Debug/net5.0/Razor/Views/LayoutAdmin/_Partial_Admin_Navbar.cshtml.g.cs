#pragma checksum "F:\APTECH\RESTful-API\Project-Aptech\NGO\NGO\Views\LayoutAdmin\_Partial_Admin_Navbar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bbdc1dc093c1f19f63bc2a9a7bbce16722a7f756"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_LayoutAdmin__Partial_Admin_Navbar), @"mvc.1.0.view", @"/Views/LayoutAdmin/_Partial_Admin_Navbar.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "F:\APTECH\RESTful-API\Project-Aptech\NGO\NGO\Views\_ViewImports.cshtml"
using NGO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\APTECH\RESTful-API\Project-Aptech\NGO\NGO\Views\_ViewImports.cshtml"
using NGO.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bbdc1dc093c1f19f63bc2a9a7bbce16722a7f756", @"/Views/LayoutAdmin/_Partial_Admin_Navbar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"31363b82102af789cfabdcc4279d00c354dfe815", @"/Views/_ViewImports.cshtml")]
    public class Views_LayoutAdmin__Partial_Admin_Navbar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/images/faces/face1.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("user"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("user"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/images/faces/face4.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/images/faces/face2.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/images/faces/face3.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<header class=""mdc-top-app-bar"">
    <div class=""mdc-top-app-bar__row"">
        <div class=""mdc-top-app-bar__section mdc-top-app-bar__section--align-start"">
            <button class=""material-icons mdc-top-app-bar__navigation-icon mdc-icon-button sidebar-toggler"">menu</button>
            <span class=""mdc-top-app-bar__title"">Admin</span>
            <div class=""mdc-text-field mdc-text-field--outlined mdc-text-field--with-leading-icon search-text-field d-none d-md-flex"">
                <i class=""material-icons mdc-text-field__icon"">search</i>
                <input class=""mdc-text-field__input"" id=""text-field-hero-input"">
                <div class=""mdc-notched-outline"">
                    <div class=""mdc-notched-outline__leading""></div>
                    <div class=""mdc-notched-outline__notch"">
                        <label for=""text-field-hero-input"" class=""mdc-floating-label"">Search..</label>
                    </div>
                    <div class=""mdc-notched-outline__trailing""></div>");
            WriteLiteral(@"
                </div>
            </div>
        </div>
        <div class=""mdc-top-app-bar__section mdc-top-app-bar__section--align-end mdc-top-app-bar__section-right"">
            <div class=""menu-button-container menu-profile d-none d-md-block"">
                <button class=""mdc-button mdc-menu-button"">
                    <span class=""d-flex align-items-center"">
                        <span class=""figure"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "bbdc1dc093c1f19f63bc2a9a7bbce16722a7f7566870", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </span>
                        <span class=""user-name"">Clyde Miles</span>
                    </span>
                </button>
                <div class=""mdc-menu mdc-menu-surface"" tabindex=""-1"">
                    <ul class=""mdc-list"" role=""menu"" aria-hidden=""true"" aria-orientation=""vertical"">
                        <li class=""mdc-list-item"" role=""menuitem"">
                            <div class=""item-thumbnail item-thumbnail-icon-only"">
                                <i class=""mdi mdi-account-edit-outline text-primary""></i>
                            </div>
                            <div class=""item-content d-flex align-items-start flex-column justify-content-center"">
                                <h6 class=""item-subject font-weight-normal"">Edit profile</h6>
                            </div>
                        </li>
                        <li class=""mdc-list-item"" role=""menuitem"">
                            <div class=""item-thumbnail item-thumbnai");
            WriteLiteral(@"l-icon-only"">
                                <i class=""mdi mdi-settings-outline text-primary""></i>
                            </div>
                            <div class=""item-content d-flex align-items-start flex-column justify-content-center"">
                                <h6 class=""item-subject font-weight-normal"">Logout</h6>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
            <div class=""divider d-none d-md-block""></div>
            <div class=""menu-button-container d-none d-md-block"">
                <button class=""mdc-button mdc-menu-button"">
                    <i class=""mdi mdi-settings""></i>
                </button>
                <div class=""mdc-menu mdc-menu-surface"" tabindex=""-1"">
                    <ul class=""mdc-list"" role=""menu"" aria-hidden=""true"" aria-orientation=""vertical"">
                        <li class=""mdc-list-item"" role=""menuitem"">
                            <div c");
            WriteLiteral(@"lass=""item-thumbnail item-thumbnail-icon-only"">
                                <i class=""mdi mdi-alert-circle-outline text-primary""></i>
                            </div>
                            <div class=""item-content d-flex align-items-start flex-column justify-content-center"">
                                <h6 class=""item-subject font-weight-normal"">Settings</h6>
                            </div>
                        </li>
                        <li class=""mdc-list-item"" role=""menuitem"">
                            <div class=""item-thumbnail item-thumbnail-icon-only"">
                                <i class=""mdi mdi-progress-download text-primary""></i>
                            </div>
                            <div class=""item-content d-flex align-items-start flex-column justify-content-center"">
                                <h6 class=""item-subject font-weight-normal"">Update</h6>
                            </div>
                        </li>
                    </ul>
");
            WriteLiteral(@"                </div>
            </div>
            <div class=""menu-button-container"">
                <button class=""mdc-button mdc-menu-button"">
                    <i class=""mdi mdi-bell""></i>
                </button>
                <div class=""mdc-menu mdc-menu-surface"" tabindex=""-1"">
                    <h6 class=""title""> <i class=""mdi mdi-bell-outline mr-2 tx-16""></i> Notifications</h6>
                    <ul class=""mdc-list"" role=""menu"" aria-hidden=""true"" aria-orientation=""vertical"">
                        <li class=""mdc-list-item"" role=""menuitem"">
                            <div class=""item-thumbnail item-thumbnail-icon"">
                                <i class=""mdi mdi-email-outline""></i>
                            </div>
                            <div class=""item-content d-flex align-items-start flex-column justify-content-center"">
                                <h6 class=""item-subject font-weight-normal"">You received a new message</h6>
                                <sm");
            WriteLiteral(@"all class=""text-muted""> 6 min ago </small>
                            </div>
                        </li>
                        <li class=""mdc-list-item"" role=""menuitem"">
                            <div class=""item-thumbnail item-thumbnail-icon"">
                                <i class=""mdi mdi-account-outline""></i>
                            </div>
                            <div class=""item-content d-flex align-items-start flex-column justify-content-center"">
                                <h6 class=""item-subject font-weight-normal"">New user registered</h6>
                                <small class=""text-muted""> 15 min ago </small>
                            </div>
                        </li>
                        <li class=""mdc-list-item"" role=""menuitem"">
                            <div class=""item-thumbnail item-thumbnail-icon"">
                                <i class=""mdi mdi-alert-circle-outline""></i>
                            </div>
                            <div ");
            WriteLiteral(@"class=""item-content d-flex align-items-start flex-column justify-content-center"">
                                <h6 class=""item-subject font-weight-normal"">System Alert</h6>
                                <small class=""text-muted""> 2 days ago </small>
                            </div>
                        </li>
                        <li class=""mdc-list-item"" role=""menuitem"">
                            <div class=""item-thumbnail item-thumbnail-icon"">
                                <i class=""mdi mdi-update""></i>
                            </div>
                            <div class=""item-content d-flex align-items-start flex-column justify-content-center"">
                                <h6 class=""item-subject font-weight-normal"">You have a new update</h6>
                                <small class=""text-muted""> 3 days ago </small>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
            <di");
            WriteLiteral(@"v class=""menu-button-container"">
                <button class=""mdc-button mdc-menu-button"">
                    <i class=""mdi mdi-email""></i>
                    <span class=""count-indicator"">
                        <span class=""count"">3</span>
                    </span>
                </button>
                <div class=""mdc-menu mdc-menu-surface"" tabindex=""-1"">
                    <h6 class=""title""><i class=""mdi mdi-email-outline mr-2 tx-16""></i> Messages</h6>
                    <ul class=""mdc-list"" role=""menu"" aria-hidden=""true"" aria-orientation=""vertical"">
                        <li class=""mdc-list-item"" role=""menuitem"">
                            <div class=""item-thumbnail"">
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "bbdc1dc093c1f19f63bc2a9a7bbce16722a7f75615333", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            </div>
                            <div class=""item-content d-flex align-items-start flex-column justify-content-center"">
                                <h6 class=""item-subject font-weight-normal"">Mark send you a message</h6>
                                <small class=""text-muted""> 1 Minutes ago </small>
                            </div>
                        </li>
                        <li class=""mdc-list-item"" role=""menuitem"">
                            <div class=""item-thumbnail"">
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "bbdc1dc093c1f19f63bc2a9a7bbce16722a7f75617025", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            </div>
                            <div class=""item-content d-flex align-items-start flex-column justify-content-center"">
                                <h6 class=""item-subject font-weight-normal"">Cregh send you a message</h6>
                                <small class=""text-muted""> 15 Minutes ago </small>
                            </div>
                        </li>
                        <li class=""mdc-list-item"" role=""menuitem"">
                            <div class=""item-thumbnail"">
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "bbdc1dc093c1f19f63bc2a9a7bbce16722a7f75618719", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            </div>
                            <div class=""item-content d-flex align-items-start flex-column justify-content-center"">
                                <h6 class=""item-subject font-weight-normal"">Profile picture updated</h6>
                                <small class=""text-muted""> 18 Minutes ago </small>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
            <div class=""menu-button-container d-none d-md-block"">
                <button class=""mdc-button mdc-menu-button"">
                    <i class=""mdi mdi-arrow-down-bold-box""></i>
                </button>
                <div class=""mdc-menu mdc-menu-surface"" tabindex=""-1"">
                    <ul class=""mdc-list"" role=""menu"" aria-hidden=""true"" aria-orientation=""vertical"">
                        <li class=""mdc-list-item"" role=""menuitem"">
                            <div class=""item-thumbnail item-thumbnail-icon-only"">");
            WriteLiteral(@"
                                <i class=""mdi mdi-lock-outline text-primary""></i>
                            </div>
                            <div class=""item-content d-flex align-items-start flex-column justify-content-center"">
                                <h6 class=""item-subject font-weight-normal"">Lock screen</h6>
                            </div>
                        </li>
                        <li class=""mdc-list-item"" role=""menuitem"">
                            <div class=""item-thumbnail item-thumbnail-icon-only"">
                                <i class=""mdi mdi-logout-variant text-primary""></i>
                            </div>
                            <div class=""item-content d-flex align-items-start flex-column justify-content-center"">
                                <h6 class=""item-subject font-weight-normal"">Logout</h6>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </d");
            WriteLiteral("iv>\r\n    </div>\r\n</header>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
