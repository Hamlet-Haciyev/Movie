#pragma checksum "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Areas\admin\Views\Subscribe\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e50322b58b7e7c7da4df147e61a457d5d56f4ec9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_admin_Views_Subscribe_Index), @"mvc.1.0.view", @"/Areas/admin/Views/Subscribe/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e50322b58b7e7c7da4df147e61a457d5d56f4ec9", @"/Areas/admin/Views/Subscribe/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82c2c930a7a570bf5389ab77803f1c0b68224910", @"/Areas/admin/Views/_ViewImports.cshtml")]
    public class Areas_admin_Views_Subscribe_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Subscribe>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Subscribe", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Send", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary font-weight-bolder"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Areas\admin\Views\Subscribe\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""d-flex flex-column-fluid"">
    <!--begin::Container-->
    <div class=""container"">
        <!--begin::Card-->
        <div class=""card card-custom"">
            <!--begin::Header-->
            <div class=""card-header flex-wrap border-0 pt-6 pb-0"">
                <div class=""card-title"">
                    <h3 class=""card-label"">
                        Subscribe Management
                        <span class=""d-block text-muted pt-2 font-size-sm"">Subscribe management made easy</span>
                    </h3>
                </div>
                <div class=""card-toolbar"">
                    <!--begin::Dropdown-->
                    <div class=""dropdown dropdown-inline mr-2"">
                        <button type=""button"" class=""btn btn-light-primary font-weight-bolder dropdown-toggle"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                            <span class=""svg-icon svg-icon-md"">
                                <!--begin::Svg Icon | path:");
            WriteLiteral(@"/metronic/theme/html/demo1/dist/assets/media/svg/icons/Design/PenAndRuller.svg-->
                                <svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""24px"" height=""24px"" viewBox=""0 0 24 24"" version=""1.1"">
                                    <g stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd"">
                                        <rect x=""0"" y=""0"" width=""24"" height=""24""></rect>
                                        <path d=""M3,16 L5,16 C5.55228475,16 6,15.5522847 6,15 C6,14.4477153 5.55228475,14 5,14 L3,14 L3,12 L5,12 C5.55228475,12 6,11.5522847 6,11 C6,10.4477153 5.55228475,10 5,10 L3,10 L3,8 L5,8 C5.55228475,8 6,7.55228475 6,7 C6,6.44771525 5.55228475,6 5,6 L3,6 L3,4 C3,3.44771525 3.44771525,3 4,3 L10,3 C10.5522847,3 11,3.44771525 11,4 L11,19 C11,19.5522847 10.5522847,20 10,20 L4,20 C3.44771525,20 3,19.5522847 3,19 L3,16 Z"" fill=""#000000"" opacity=""0.3""></path>
                                        <path d=""M16,3 L19,3 C20.1045695");
            WriteLiteral(@",3 21,3.8954305 21,5 L21,15.2485298 C21,15.7329761 20.8241635,16.200956 20.5051534,16.565539 L17.8762883,19.5699562 C17.6944473,19.7777745 17.378566,19.7988332 17.1707477,19.6169922 C17.1540423,19.602375 17.1383289,19.5866616 17.1237117,19.5699562 L14.4948466,16.565539 C14.1758365,16.200956 14,15.7329761 14,15.2485298 L14,5 C14,3.8954305 14.8954305,3 16,3 Z"" fill=""#000000""></path>
                                    </g>
                                </svg>
                                <!--end::Svg Icon-->
                            </span>Export
                        </button>
                    </div>
                    <!--end::Dropdown-->
                    <!--begin::Button-->
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e50322b58b7e7c7da4df147e61a457d5d56f4ec97980", async() => {
                WriteLiteral(@"
                        <span class=""svg-icon svg-icon-md"">
                            <!--begin::Svg Icon | path:/metronic/theme/html/demo1/dist/assets/media/svg/icons/Design/Flatten.svg-->
                            <svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""24px"" height=""24px"" viewBox=""0 0 24 24"" version=""1.1"">
                                <g stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd"">
                                    <rect x=""0"" y=""0"" width=""24"" height=""24""></rect>
                                    <circle fill=""#000000"" cx=""9"" cy=""15"" r=""6""></circle>
                                    <path d=""M8.8012943,7.00241953 C9.83837775,5.20768121 11.7781543,4 14,4 C17.3137085,4 20,6.6862915 20,10 C20,12.2218457 18.7923188,14.1616223 16.9975805,15.1987057 C16.9991904,15.1326658 17,15.0664274 17,15 C17,10.581722 13.418278,7 9,7 C8.93357256,7 8.86733422,7.00080962 8.8012943,7.00241953 Z"" fill=""#000000"" opacity=""0.3""></path>
      ");
                WriteLiteral("                          </g>\r\n                            </svg>\r\n                            <!--end::Svg Icon-->\r\n                        </span>Send\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    <!--end::Button-->
                </div>
            </div>
            <!--end::Header-->
            <!--begin::Body-->
            <div class=""card-body"">
                <!--begin: Datatable-->
                <div class=""datatable datatable-bordered datatable-head-custom datatable-default datatable-primary datatable-loaded"" id=""kt_datatable""");
            BeginWriteAttribute("style", " style=\"", 4592, "\"", 4600, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    <table class=""datatable-table"" style=""display: block;"">
                        <thead class=""datatable-head"">
                            <tr class=""datatable-row"" style=""left: 0px;"">
                                <th data-field=""RecordID"" class=""datatable-cell-left datatable-cell datatable-cell-sort datatable-cell-sorted"" data-sort=""asc"">
                                    <span style=""width: 40px;"">#<i class=""flaticon2-arrow-up""></i></span>
                                </th>
                                <th data-field=""Name"" class=""datatable-cell datatable-cell-sort""><span style=""width: 840px;"">Name</span></th>
                            </tr>
                        </thead>
                        <tbody class=""datatable-body""");
            BeginWriteAttribute("style", " style=\"", 5384, "\"", 5392, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 70 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Areas\admin\Views\Subscribe\Index.cshtml"
                              
                                int i = 1;
                                foreach (var subscribe in Model)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr data-row=\"");
#nullable restore
#line 74 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Areas\admin\Views\Subscribe\Index.cshtml"
                                             Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"datatable-row\" style=\"left: 0px;\">\r\n\r\n                                        <td class=\"datatable-cell-sorted datatable-cell-left datatable-cell\" data-field=\"RecordID\"");
            BeginWriteAttribute("aria-label", " aria-label=\"", 5802, "\"", 5817, 1);
#nullable restore
#line 76 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Areas\admin\Views\Subscribe\Index.cshtml"
WriteAttributeValue("", 5815, i, 5815, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                            <span style=\"width: 40px;\">\r\n                                                <span class=\"font-weight-bolder\">");
#nullable restore
#line 78 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Areas\admin\Views\Subscribe\Index.cshtml"
                                                                            Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                            </span>
                                        </td>

                                        <td data-field=""Name"" class=""datatable-cell"">
                                            <span style=""width: 840px; "">
                                                <div class=""font-weight-bold text-muted"">");
#nullable restore
#line 84 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Areas\admin\Views\Subscribe\Index.cshtml"
                                                                                    Write(subscribe?.Mail);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                            </span>\r\n                                        </td>\r\n\r\n                                    </tr>\r\n");
#nullable restore
#line 89 "C:\Users\FX505GT\Desktop\Movie\Movie\Movie\Areas\admin\Views\Subscribe\Index.cshtml"
                                    i++;
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n\r\n                </div>\r\n            </div>\r\n            <!--end: Datatable-->\r\n        </div>\r\n        <!--end::Body-->\r\n    </div>\r\n    <!--end::Card-->\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Subscribe>> Html { get; private set; }
    }
}
#pragma warning restore 1591