#pragma checksum "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Areas\admin\Views\Contact\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e9f36d39ebe21752d2871edc5b4f9d1f3b3f0783"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_admin_Views_Contact_Index), @"mvc.1.0.view", @"/Areas/admin/Views/Contact/Index.cshtml")]
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
#line 1 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Areas\admin\Views\_ViewImports.cshtml"
using Movie;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Areas\admin\Views\_ViewImports.cshtml"
using Movie.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Areas\admin\Views\_ViewImports.cshtml"
using Movie.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Areas\admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Areas\admin\Views\_ViewImports.cshtml"
using Movie.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e9f36d39ebe21752d2871edc5b4f9d1f3b3f0783", @"/Areas/admin/Views/Contact/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bfc85c1a9876e5dfba17cd6ba16fdcc1284ee89b", @"/Areas/admin/Views/_ViewImports.cshtml")]
    public class Areas_admin_Views_Contact_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Contact>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("main__title-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "contact", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("main__table-btn main__table-btn--delete delete"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Areas\admin\Views\Contact\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/admin/Views/Shared/_LayoutMain.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<main class=""main"">
    <div class=""container-fluid"">
        <div class=""row"">
            <!-- main title -->
            <div class=""col-12"">
                <div class=""main__title"">
                    <h2>Contact</h2>

                    <span class=""main__title-stat"">");
#nullable restore
#line 15 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Areas\admin\Views\Contact\Index.cshtml"
                                               Write(_context.Contacts.ToList().Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" Total</span>

                    <div class=""main__title-wrap"">
                        <!-- filter sort -->
                        <div class=""filter"" id=""filter__sort"">
                            <span class=""filter__item-label"">Sort by:</span>

                            <div class=""filter__item-btn dropdown-toggle"" role=""navigation"" id=""filter-sort"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                <input type=""button"" value=""Date created"">
                                <span></span>
                            </div>

                            <ul class=""filter__item-menu dropdown-menu scrollbar-dropdown"" aria-labelledby=""filter-sort"">
                                <li>Date created</li>
                                <li>Rating</li>
                                <li>Views</li>
                            </ul>
                        </div>
                        <!-- end filter sort -->
                        <!-- search");
            WriteLiteral(" -->\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e9f36d39ebe21752d2871edc5b4f9d1f3b3f07837926", async() => {
                WriteLiteral(@"
                            <input type=""text"" placeholder=""Find movie / tv series.."">
                            <button type=""button"">
                                <i class=""icon ion-ios-search""></i>
                            </button>
                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        <!-- end search -->
                    </div>
                </div>
            </div>
            <!-- end main title -->
            <!-- users -->
            <div class=""col-12"">
                <div class=""main__table-wrap"">
                    <table class=""main__table"">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>NAME</th>
                                <th>EMAIL</th>
                                <th>SUBJECT</th>
                                <th>PHONE</th>
                                <th>TEXT</th>
                                <th>CREATED DATE</th>
                                <th>ACTIONS</th>
                            </tr>
                        </thead>

                        <tbody>
");
#nullable restore
#line 64 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Areas\admin\Views\Contact\Index.cshtml"
                              
                                int i = 1;
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 66 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Areas\admin\Views\Contact\Index.cshtml"
                                 foreach (var item in Model)
                                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td>\r\n                                            <div class=\"main__table-text\">");
#nullable restore
#line 71 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Areas\admin\Views\Contact\Index.cshtml"
                                                                     Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                        </td>\r\n                                        <td>\r\n                                            <div class=\"main__table-text\"><a href=\"#\">");
#nullable restore
#line 74 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Areas\admin\Views\Contact\Index.cshtml"
                                                                                 Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></div>\r\n                                        </td>\r\n                                        <td>\r\n                                            <div class=\"main__table-text main__table-text--rate\">");
#nullable restore
#line 77 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Areas\admin\Views\Contact\Index.cshtml"
                                                                                            Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                        </td>\r\n                                        <td>\r\n                                            <div class=\"main__table-text\">");
#nullable restore
#line 80 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Areas\admin\Views\Contact\Index.cshtml"
                                                                     Write(item.Subject);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                        </td>\r\n                                        <td>\r\n                                            <div class=\"main__table-text\">");
#nullable restore
#line 83 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Areas\admin\Views\Contact\Index.cshtml"
                                                                     Write(item.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                        </td>\r\n                                        <td>\r\n                                            <div class=\"main__table-text main__table-text--green\">");
#nullable restore
#line 86 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Areas\admin\Views\Contact\Index.cshtml"
                                                                                              Write(item.Text.Length > 150 ? item.Text.Substring(0,150) + " ..." : item.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                        </td>\r\n                                        <td>\r\n                                            <div class=\"main__table-text\">");
#nullable restore
#line 89 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Areas\admin\Views\Contact\Index.cshtml"
                                                                     Write(item.CreatedDate.ToString("dd MMM yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                        </td>\r\n                                        <td>\r\n                                            <div class=\"main__table-btns\">\r\n                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e9f36d39ebe21752d2871edc5b4f9d1f3b3f078314738", async() => {
                WriteLiteral("\r\n                                                    <i class=\"icon ion-ios-trash\"></i>\r\n                                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 93 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Areas\admin\Views\Contact\Index.cshtml"
                                                                                                                   WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                            </div>\r\n                                        </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 99 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Areas\admin\Views\Contact\Index.cshtml"
                                    i++;
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </tbody>
                    </table>
                </div>
            </div>
            <!-- end users -->
            <!-- paginator -->
            <div class=""col-12"">
                <div class=""paginator-wrap"">
                    <span>");
#nullable restore
#line 109 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Areas\admin\Views\Contact\Index.cshtml"
                      Write(_context.Contacts.ToList().Count > 10 ? "10" : _context.Contacts.ToList().Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(" from ");
#nullable restore
#line 109 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Areas\admin\Views\Contact\Index.cshtml"
                                                                                                              Write(_context.Contacts.ToList().Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n\r\n");
#nullable restore
#line 111 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Areas\admin\Views\Contact\Index.cshtml"
                     if (Model.Count >= 10)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <ul class=""paginator"">
                            <li class=""paginator__item paginator__item--prev"">
                                <a href=""#""><i class=""icon ion-ios-arrow-back""></i></a>
                            </li>
                            <li class=""paginator__item""><a href=""#"">1</a></li>
                            <li class=""paginator__item paginator__item--active""><a href=""#"">2</a></li>
                            <li class=""paginator__item""><a href=""#"">3</a></li>
                            <li class=""paginator__item""><a href=""#"">4</a></li>
                            <li class=""paginator__item paginator__item--next"">
                                <a href=""#""><i class=""icon ion-ios-arrow-forward""></i></a>
                            </li>
                        </ul>
");
#nullable restore
#line 125 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Areas\admin\Views\Contact\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </div>
            </div>
            <!-- end paginator -->
        </div>
    </div>
</main>
<!-- end main content -->
<!-- modal status -->
<div id=""modal-status"" class=""zoom-anim-dialog mfp-hide modal"">
    <h6 class=""modal__title"">Status change</h6>

    <p class=""modal__text"">Are you sure about immediately change status?</p>

    <div class=""modal__btns"">
        <button class=""modal__btn modal__btn--apply"" type=""button"">Apply</button>
        <button class=""modal__btn modal__btn--dismiss"" type=""button"">Dismiss</button>
    </div>
</div>
<!-- end modal status -->
<!-- modal delete -->
<div id=""modal-delete"" class=""zoom-anim-dialog mfp-hide modal"">
    <h6 class=""modal__title"">Item delete</h6>

    <p class=""modal__text"">Are you sure to permanently delete this item?</p>

    <div class=""modal__btns"">
        <button class=""modal__btn modal__btn--apply"" type=""button"">Delete</button>
        <button class=""modal__btn modal__btn--dismiss"" type=""button"">Dismiss</but");
            WriteLiteral("ton>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script src=""https://unpkg.com/sweetalert/dist/sweetalert.min.js""></script>
    <script>
        $('.delete').on('click', function (e) {
            e.preventDefault();
            let url = $(this).attr('href');
            swal({
                title: ""Are you sure?"",
                text: ""Once deleted, you will not be able to recover this imaginary file!"",
                icon: ""warning"",
                buttons: true,
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete) {
                        fetch(url).then(response => response.json()).then(data => {
                            if (data.code == 204) {
                                swal(data.message, {
                                    icon: ""success"",
                                });
                                window.location.reload();
                            } else {
                                swal(data.message, {
               ");
                WriteLiteral(@"                     icon: ""error"",
                                });
                            }
                        })
                    } else {
                        swal(""Item wasn't deleted"", { icon: ""error"" });
                    }
                });
        })</script>
");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public AppDbContext _context { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Contact>> Html { get; private set; }
    }
}
#pragma warning restore 1591
