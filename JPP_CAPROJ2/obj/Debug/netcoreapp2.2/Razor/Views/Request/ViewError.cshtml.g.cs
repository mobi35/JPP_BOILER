#pragma checksum "C:\Users\Lenovo\Desktop\JPP_BOILER-master\JPP_CAPROJ2\Views\Request\ViewError.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "519e55f4e4ca6c0ed3920f6c0ec56dbce5d5b33d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Request_ViewError), @"mvc.1.0.view", @"/Views/Request/ViewError.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Request/ViewError.cshtml", typeof(AspNetCore.Views_Request_ViewError))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"519e55f4e4ca6c0ed3920f6c0ec56dbce5d5b33d", @"/Views/Request/ViewError.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24ae6b3904c003feacca99665b1cd2b511c61e8b", @"/Views/_ViewImports.cshtml")]
    public class Views_Request_ViewError : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Request>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\Lenovo\Desktop\JPP_BOILER-master\JPP_CAPROJ2\Views\Request\ViewError.cshtml"
  
    ViewData["Title"] = "Privacy Policy";
    Layout = "Client";

#line default
#line hidden
            BeginContext(70, 1, true);
            WriteLiteral("\n");
            EndContext();
            BeginContext(86, 65, true);
            WriteLiteral(" <section id=\"main-content\"> \n         <div class=\"wrapper\">\n<h1>");
            EndContext();
            BeginContext(152, 13, false);
#line 9 "C:\Users\Lenovo\Desktop\JPP_BOILER-master\JPP_CAPROJ2\Views\Request\ViewError.cshtml"
Write(Model.Message);

#line default
#line hidden
            EndContext();
            BeginContext(165, 24, true);
            WriteLiteral("</h1>\n\n</div>\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Request> Html { get; private set; }
    }
}
#pragma warning restore 1591
