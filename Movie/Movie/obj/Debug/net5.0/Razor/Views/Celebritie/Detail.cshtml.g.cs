#pragma checksum "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Views\Celebritie\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8076cc98e7f9c57cc3f46bf0f83ac4d2154a5d10"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Celebritie_Detail), @"mvc.1.0.view", @"/Views/Celebritie/Detail.cshtml")]
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
#line 1 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Views\_ViewImports.cshtml"
using Movie;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Views\_ViewImports.cshtml"
using Movie.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Views\_ViewImports.cshtml"
using Movie.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Views\_ViewImports.cshtml"
using Movie.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8076cc98e7f9c57cc3f46bf0f83ac4d2154a5d10", @"/Views/Celebritie/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f17e9a0e37abfa7f844ea84c223c5e87e2767e08", @"/Views/_ViewImports.cshtml")]
    public class Views_Celebritie_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<VmCelebritie>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("no image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 100%; object-fit: cover; object-position: 50% 50%; height: 450px; "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("60"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("80"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Movie", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Views\Celebritie\Detail.cshtml"
  
    ViewData["Title"] = "Detail";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""banner1-bg-img""></div>
<main>
    <section id=""celebritieInfo"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-4"">
                    <div class=""celebritie__detail__image"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8076cc98e7f9c57cc3f46bf0f83ac4d2154a5d107136", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 344, "~/Uploads/", 344, 10, true);
#nullable restore
#line 13 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Views\Celebritie\Detail.cshtml"
AddHtmlAttributeValue("", 354, Model.Cast.Image, 354, 17, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"col-lg-8\">\r\n                    <div class=\"celebritie__content\">\r\n                        <h2>");
#nullable restore
#line 18 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Views\Celebritie\Detail.cshtml"
                       Write(Model.Cast.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
                        <div class=""celebritie__tabs"">
                            <div class=""celebritie__tabs-title"">
                                <ul>
                                    <li><a class=""active"" href=""#"">BIOGRAPHY</a></li>
                                    <li><a href=""#"">FILMOGRAPHY</a></li>
                                </ul>
                            </div>
                            <div class=""celebritie__tabs-content"">
                                <div class=""biography show"">
                                    <div class=""row"">
                                        <div class=""col-lg-9 col-md-8"">
                                            <div class=""celebritie__tabs-content-left"">
                                                <div class=""subtitle"">
                                                    <h6>Biography of</h6>
                                                    <h4>");
#nullable restore
#line 33 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Views\Celebritie\Detail.cshtml"
                                                   Write(Model.Cast.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                                </div>\r\n                                                <p>\r\n                                                    ");
#nullable restore
#line 36 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Views\Celebritie\Detail.cshtml"
                                               Write(Model.Cast.About);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                </p>
                                            </div>
                                        </div>
                                        <div class=""col-lg-3 col-md-4"">
                                            <div class=""celebritie__tabs-content-right"">
                                                <div class=""overview__clb"">
                                                    <h6>Date of Birth:</h6>
                                                    <p>");
#nullable restore
#line 44 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Views\Celebritie\Detail.cshtml"
                                                  Write(Model.Cast.BirthDay.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                                </div>
                                                <div class=""overview__clb"">
                                                    <h6>Gender:</h6>
                                                    <p>");
#nullable restore
#line 48 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Views\Celebritie\Detail.cshtml"
                                                  Write(Model.Cast.Gender.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                                </div>
                                                <div class=""overview__clb"">
                                                    <h6>Country of Birth:</h6>
                                                    <p>
                                                        ");
#nullable restore
#line 53 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Views\Celebritie\Detail.cshtml"
                                                   Write(Model.Cast.BirthPlace);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class=""filmography"">
");
#nullable restore
#line 61 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Views\Celebritie\Detail.cshtml"
                                     foreach (var item in Model.PlayListMovie)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        <div class=""celebritie__film"">
                                            <div class=""celebritie__film__main"">
                                                <div class=""celebritie__film__img"">
                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8076cc98e7f9c57cc3f46bf0f83ac4d2154a5d1013797", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3809, "~/Uploads/", 3809, 10, true);
#nullable restore
#line 66 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Views\Celebritie\Detail.cshtml"
AddHtmlAttributeValue("", 3819, item.Image, 3819, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                </div>\r\n                                                <div class=\"celebritie__film__title\">\r\n                                                    <h4>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8076cc98e7f9c57cc3f46bf0f83ac4d2154a5d1015810", async() => {
#nullable restore
#line 69 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Views\Celebritie\Detail.cshtml"
                                                                                                                         Write(item.Title);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 69 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Views\Celebritie\Detail.cshtml"
                                                                                                        WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</h4>\r\n                                                </div>\r\n                                            </div>\r\n                                            <div class=\"celebritie__createdDate\">\r\n                                                <p>");
#nullable restore
#line 73 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Views\Celebritie\Detail.cshtml"
                                              Write(item.CreatedDate.ToString("yyyy-MM-dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                            </div>\r\n                                        </div>\r\n");
#nullable restore
#line 76 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Views\Celebritie\Detail.cshtml"

                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </section>\r\n</main>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<VmCelebritie> Html { get; private set; }
    }
}
#pragma warning restore 1591
