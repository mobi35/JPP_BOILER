#pragma checksum "D:\Zx\jppboiler\jpp_boiler\JPP_CAPROJ2\Views\Cart\CheckoutSuccess.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "01ef847f764a5924824775d43c45166d2a00ea81"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_CheckoutSuccess), @"mvc.1.0.view", @"/Views/Cart/CheckoutSuccess.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Cart/CheckoutSuccess.cshtml", typeof(AspNetCore.Views_Cart_CheckoutSuccess))]
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
#line 1 "D:\Zx\jppboiler\jpp_boiler\JPP_CAPROJ2\Views\_ViewImports.cshtml"
using JPP_CAPROJ2;

#line default
#line hidden
#line 2 "D:\Zx\jppboiler\jpp_boiler\JPP_CAPROJ2\Views\_ViewImports.cshtml"
using JPP_CAPROJ2.Models;

#line default
#line hidden
#line 3 "D:\Zx\jppboiler\jpp_boiler\JPP_CAPROJ2\Views\_ViewImports.cshtml"
using JPP_CAPROJ2.Models.ViewModel;

#line default
#line hidden
#line 4 "D:\Zx\jppboiler\jpp_boiler\JPP_CAPROJ2\Views\_ViewImports.cshtml"
using JPP_CAPROJ2.Data.Model;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01ef847f764a5924824775d43c45166d2a00ea81", @"/Views/Cart/CheckoutSuccess.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f9b6611511e8f44c76273d3d541a13a7f34e893", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_CheckoutSuccess : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\Zx\jppboiler\jpp_boiler\JPP_CAPROJ2\Views\Cart\CheckoutSuccess.cshtml"
  
    ViewData["Title"] = "CheckoutSuccess";
    Layout = "~/Views/Shared/Client.cshtml";

#line default
#line hidden
            BeginContext(114, 78, true);
            WriteLiteral("\r\n<section id=\"main-content\">\r\n    <section class=\"wrapper\">\r\n\r\n\r\n        <h2>");
            EndContext();
            BeginContext(193, 5, false);
#line 12 "D:\Zx\jppboiler\jpp_boiler\JPP_CAPROJ2\Views\Cart\CheckoutSuccess.cshtml"
       Write(Model);

#line default
#line hidden
            EndContext();
            BeginContext(198, 33, true);
            WriteLiteral("</h2>\r\n    </section>\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string> Html { get; private set; }
    }
}
#pragma warning restore 1591
