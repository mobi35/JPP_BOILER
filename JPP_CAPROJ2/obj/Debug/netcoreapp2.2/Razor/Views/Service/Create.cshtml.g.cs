#pragma checksum "C:\Users\ADRIAN\Desktop\BOOM\jpp_boiler\JPP_CAPROJ2\Views\Service\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "235576b313fca334a56fc60ba75863b9a673c09c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Service_Create), @"mvc.1.0.view", @"/Views/Service/Create.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Service/Create.cshtml", typeof(AspNetCore.Views_Service_Create))]
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
#line 1 "C:\Users\ADRIAN\Desktop\BOOM\jpp_boiler\JPP_CAPROJ2\Views\_ViewImports.cshtml"
using JPP_CAPROJ2;

#line default
#line hidden
#line 2 "C:\Users\ADRIAN\Desktop\BOOM\jpp_boiler\JPP_CAPROJ2\Views\_ViewImports.cshtml"
using JPP_CAPROJ2.Models;

#line default
#line hidden
#line 3 "C:\Users\ADRIAN\Desktop\BOOM\jpp_boiler\JPP_CAPROJ2\Views\_ViewImports.cshtml"
using JPP_CAPROJ2.Models.ViewModel;

#line default
#line hidden
#line 4 "C:\Users\ADRIAN\Desktop\BOOM\jpp_boiler\JPP_CAPROJ2\Views\_ViewImports.cshtml"
using JPP_CAPROJ2.Data.Model;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"235576b313fca334a56fc60ba75863b9a673c09c", @"/Views/Service/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f9b6611511e8f44c76273d3d541a13a7f34e893", @"/Views/_ViewImports.cshtml")]
    public class Views_Service_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Quotations>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn-sm btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Service", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteQuotation", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateQuotation", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
#line 1 "C:\Users\ADRIAN\Desktop\BOOM\jpp_boiler\JPP_CAPROJ2\Views\Service\Create.cshtml"
  
    ViewData["Title"] = "Privacy Policy";
    Layout = "BackEnd";

#line default
#line hidden
            BeginContext(100, 220, true);
            WriteLiteral("\r\n    <section id=\"main-content\"> \r\n         <div class=\"wrapper\">\r\n    <div class=\"row mt\">\r\n\r\n        <div class=\"col-lg-12\">\r\n\r\n            <div class=\"form-panel\">\r\n\r\n                <h1>Boiler</h1>\r\n                ");
            EndContext();
            BeginContext(320, 1084, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "235576b313fca334a56fc60ba75863b9a673c09c5813", async() => {
                BeginContext(394, 28, true);
                WriteLiteral("\r\n                    <ul>\r\n");
                EndContext();
#line 18 "C:\Users\ADRIAN\Desktop\BOOM\jpp_boiler\JPP_CAPROJ2\Views\Service\Create.cshtml"
                          
                            foreach (var c in Model)
                            {
                                if (c.ServiceName == "Boiler")
                                {

#line default
#line hidden
                BeginContext(634, 65, true);
                WriteLiteral("                                    <li class=\"badge badge-info\">");
                EndContext();
                BeginContext(700, 15, false);
#line 23 "C:\Users\ADRIAN\Desktop\BOOM\jpp_boiler\JPP_CAPROJ2\Views\Service\Create.cshtml"
                                                            Write(c.QuotationName);

#line default
#line hidden
                EndContext();
                BeginContext(715, 3, true);
                WriteLiteral(" : ");
                EndContext();
                BeginContext(719, 21, false);
#line 23 "C:\Users\ADRIAN\Desktop\BOOM\jpp_boiler\JPP_CAPROJ2\Views\Service\Create.cshtml"
                                                                               Write(c.Price.ToString("N"));

#line default
#line hidden
                EndContext();
                BeginContext(740, 2, true);
                WriteLiteral("  ");
                EndContext();
                BeginContext(742, 119, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "235576b313fca334a56fc60ba75863b9a673c09c7562", async() => {
                    BeginContext(856, 1, true);
                    WriteLiteral("X");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 23 "C:\Users\ADRIAN\Desktop\BOOM\jpp_boiler\JPP_CAPROJ2\Views\Service\Create.cshtml"
                                                                                                                                           WriteLiteral(c.QuotationPK);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(861, 10, true);
                WriteLiteral("  </li> \r\n");
                EndContext();
#line 24 "C:\Users\ADRIAN\Desktop\BOOM\jpp_boiler\JPP_CAPROJ2\Views\Service\Create.cshtml"
                                }
                            }
                        

#line default
#line hidden
                BeginContext(964, 433, true);
                WriteLiteral(@"
                    </ul>

                    <input type=""text"" placeholder=""Title"" name=""title"" style=""width:200px;"" class=""form-control"" />
                    <input type=""number"" name=""price"" style=""width:200px;"" placeholder=""Price"" class=""form-control"" />
                    <input type=""hidden"" name=""serviceType"" value=""Boiler"" />
                    <input type=""submit"" class=""btn btn-primary"" />
                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1404, 53, true);
            WriteLiteral("\r\n                <h1>Plumbing</h1>\r\n                ");
            EndContext();
            BeginContext(1457, 1086, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "235576b313fca334a56fc60ba75863b9a673c09c12936", async() => {
                BeginContext(1531, 28, true);
                WriteLiteral("\r\n                    <ul>\r\n");
                EndContext();
#line 38 "C:\Users\ADRIAN\Desktop\BOOM\jpp_boiler\JPP_CAPROJ2\Views\Service\Create.cshtml"
                          
                            foreach (var c in Model)
                            {
                                if (c.ServiceName == "Plumbing")
                                {

#line default
#line hidden
                BeginContext(1773, 65, true);
                WriteLiteral("                                    <li class=\"badge badge-info\">");
                EndContext();
                BeginContext(1839, 15, false);
#line 43 "C:\Users\ADRIAN\Desktop\BOOM\jpp_boiler\JPP_CAPROJ2\Views\Service\Create.cshtml"
                                                            Write(c.QuotationName);

#line default
#line hidden
                EndContext();
                BeginContext(1854, 3, true);
                WriteLiteral(" : ");
                EndContext();
                BeginContext(1858, 21, false);
#line 43 "C:\Users\ADRIAN\Desktop\BOOM\jpp_boiler\JPP_CAPROJ2\Views\Service\Create.cshtml"
                                                                               Write(c.Price.ToString("N"));

#line default
#line hidden
                EndContext();
                BeginContext(1879, 2, true);
                WriteLiteral("  ");
                EndContext();
                BeginContext(1881, 118, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "235576b313fca334a56fc60ba75863b9a673c09c14695", async() => {
                    BeginContext(1994, 1, true);
                    WriteLiteral("X");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 43 "C:\Users\ADRIAN\Desktop\BOOM\jpp_boiler\JPP_CAPROJ2\Views\Service\Create.cshtml"
                                                                                                                                           WriteLiteral(c.QuotationPK);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1999, 9, true);
                WriteLiteral("  </li>\r\n");
                EndContext();
#line 44 "C:\Users\ADRIAN\Desktop\BOOM\jpp_boiler\JPP_CAPROJ2\Views\Service\Create.cshtml"

                                }
                            }
                        

#line default
#line hidden
                BeginContext(2103, 433, true);
                WriteLiteral(@"                    </ul>

                    <input type=""text"" placeholder=""Title"" name=""title"" style=""width:200px;"" class=""form-control"" />
                    <input type=""number"" name=""price"" style=""width:200px;"" placeholder=""Price"" class=""form-control"" />
                    <input type=""hidden"" name=""serviceType"" value=""Plumbing"" />
                    <input type=""submit"" class=""btn btn-primary"" />
                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2543, 302, true);
            WriteLiteral(@"

                
            </div>
            <!-- /form-panel -->
        </div>
        <!-- /col-lg-12 -->
    </div>
    <script>


    if ($('.validation').text().trim() == """") {
        $('.validation').hide();
    }



    </script>
         </div>
         </div>

    ");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Quotations>> Html { get; private set; }
    }
}
#pragma warning restore 1591
