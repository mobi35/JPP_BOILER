#pragma checksum "C:\Users\Lenovo\Desktop\JPP_BOILER-master\JPP_CAPROJ2\Views\Feedback\Contact.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d6a098aee1df5e52c71d8bec22b171fb8deb934"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Feedback_Contact), @"mvc.1.0.view", @"/Views/Feedback/Contact.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Feedback/Contact.cshtml", typeof(AspNetCore.Views_Feedback_Contact))]
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
#line 1 "C:\Users\Lenovo\Desktop\JPP_BOILER-master\JPP_CAPROJ2\Views\_ViewImports.cshtml"
using JPP_CAPROJ2;

#line default
#line hidden
#line 2 "C:\Users\Lenovo\Desktop\JPP_BOILER-master\JPP_CAPROJ2\Views\_ViewImports.cshtml"
using JPP_CAPROJ2.Models;

#line default
#line hidden
#line 3 "C:\Users\Lenovo\Desktop\JPP_BOILER-master\JPP_CAPROJ2\Views\_ViewImports.cshtml"
using JPP_CAPROJ2.Models.ViewModel;

#line default
#line hidden
#line 4 "C:\Users\Lenovo\Desktop\JPP_BOILER-master\JPP_CAPROJ2\Views\_ViewImports.cshtml"
using JPP_CAPROJ2.Data.Model;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d6a098aee1df5e52c71d8bec22b171fb8deb934", @"/Views/Feedback/Contact.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24ae6b3904c003feacca99665b1cd2b511c61e8b", @"/Views/_ViewImports.cshtml")]
    public class Views_Feedback_Contact : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-a contactForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\Lenovo\Desktop\JPP_BOILER-master\JPP_CAPROJ2\Views\Feedback\Contact.cshtml"
  
    ViewData["Title"] = "Contact Us";
    Layout = "FrontEnd";

#line default
#line hidden
            BeginContext(68, 556, true);
            WriteLiteral(@"

<section class=""intro-single"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-12 col-lg-8"">
                <div class=""title-single-box"">
                    <h1 class=""title-single"">Contact Us Now.</h1>
                </div>
            </div>
            <div class=""col-md-12 col-lg-4"">
                <nav aria-label=""breadcrumb"" class=""breadcrumb-box d-flex justify-content-lg-end"">
                    <ol class=""breadcrumb"">
                        <li class=""breadcrumb-item"">
                            ");
            EndContext();
            BeginContext(624, 52, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d6a098aee1df5e52c71d8bec22b171fb8deb9346514", async() => {
                BeginContext(668, 4, true);
                WriteLiteral("Home");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(676, 571, true);
            WriteLiteral(@"
                        </li>
                        <li class=""breadcrumb-item active"" aria-current=""page"">
                            Contact us
                        </li>
                    </ol>
                </nav>
            </div>
        </div>
    </div>
</section>

<!--/ Contact Star /-->
<section class=""contact"" >
    
    <div class=""container"" style=""margin-top:-100px;"">
        <div class=""row"">
            <div class=""col-sm-12 section-t8"">
                <div class=""row"">
                    <div class=""col-md-7"">
                        ");
            EndContext();
            BeginContext(1247, 2511, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d6a098aee1df5e52c71d8bec22b171fb8deb9348678", async() => {
                BeginContext(1316, 2435, true);
                WriteLiteral(@"
                             
                            <div id=""sendmessage"">Your message has been sent. Thank you!</div>
                            <div id=""errormessage""></div>
                            <div class=""row"">
                                <div class=""col-md-6 mb-3"">
                                    <div class=""form-group"">
                                        <input type=""text"" name=""name"" class=""form-control form-control-lg form-control-a"" placeholder=""Your Name"" data-rule=""minlen:4"" data-msg=""Please enter at least 4 chars"">
                                        <div class=""validation""></div>
                                    </div>
                                </div>
                                <div class=""col-md-6 mb-3"">
                                    <div class=""form-group"">
                                        <input name=""email"" type=""email"" class=""form-control form-control-lg form-control-a"" placeholder=""Your Email"" data-rule=""email"" data-msg=""Please ente");
                WriteLiteral(@"r a valid email"">
                                        <div class=""validation""></div>
                                    </div>
                                </div>
                                <div class=""col-md-12 mb-3"">
                                    <div class=""form-group"">
                                        <input type=""text"" name=""subject"" class=""form-control form-control-lg form-control-a"" placeholder=""Subject"" data-rule=""minlen:4"" data-msg=""Please enter at least 8 chars of subject"">
                                        <div class=""validation""></div>
                                    </div>
                                </div>
                                <div class=""col-md-12 mb-3"">
                                    <div class=""form-group"">
                                        <textarea name=""message"" class=""form-control"" name=""message"" cols=""45"" rows=""8"" data-rule=""required"" data-msg=""Please write something for us"" placeholder=""Message""></textarea>
                  ");
                WriteLiteral(@"                      <div class=""validation""></div>
                                    </div>
                                </div>
                                <div class=""col-md-12"">
                                    <button type=""submit"" class=""btn btn-a"">Send Message</button>
                                </div>
                            </div>
                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3758, 3476, true);
            WriteLiteral(@"
                    </div>
                    <div class=""col-md-5 section-md-t3"">
                        <div class=""icon-box section-b2"">
                            <div class=""icon-box-icon"">
                                <span class=""ion-ios-paper-plane""></span>
                            </div>
                            <div class=""icon-box-content table-cell"">
                                <div class=""icon-box-title"">
                                    <h4 class=""icon-title"">Say Hello</h4>
                                </div>
                                <div class=""icon-box-content"">
                                    <p class=""mb-1"">
                                        Email.
                                        <span class=""color-a"">jpp_boiler@yahoo.com.ph</span>
                                    </p>
                                    <p class=""mb-1"">
                                        Phone.
                                        <span class=""color-a""> (049) 834 44");
            WriteLiteral(@"79</span>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class=""icon-box section-b2"">
                            <div class=""icon-box-icon"">
                                <span class=""ion-ios-pin""></span>
                            </div>
                            <div class=""icon-box-content table-cell"">
                                <div class=""icon-box-title"">
                                    <h4 class=""icon-title"">Find us in</h4>
                                </div>
                                <div class=""icon-box-content"">
                                    <p class=""mb-1"">
                                      016 Purok 6 Lawa
                                        <br> Calamba, Laguna
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div c");
            WriteLiteral(@"lass=""icon-box"">
                            <div class=""icon-box-icon"">
                                <span class=""ion-ios-redo""></span>
                            </div>
                            <div class=""icon-box-content table-cell"">
                                <div class=""icon-box-title"">
                                    <h4 class=""icon-title"">Social networks</h4>
                                </div>
                                <div class=""icon-box-content"">
                                    <div class=""socials-footer"">
                                        <ul class=""list-inline"">
                                            <li class=""list-inline-item"">
                                                <a href=""https://www.facebook.com/John-Paul-and-Peter-Boiler-Repair-and-Services-382720831841712/"" class=""link-one"">
                                                    <i class=""fa fa-facebook"" aria-hidden=""true""></i>
                                                </a>
            ");
            WriteLiteral(@"                                </li>
                                          
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!--/ Contact End /-->
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
