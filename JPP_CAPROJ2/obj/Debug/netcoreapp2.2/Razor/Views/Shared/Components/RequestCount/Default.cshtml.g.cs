#pragma checksum "C:\Users\ADRIAN\Desktop\BOOM\jpp_boiler\JPP_CAPROJ2\Views\Shared\Components\RequestCount\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3c154541b0c9e5e28ae2f4b025ec0ea87be9dd79"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_RequestCount_Default), @"mvc.1.0.view", @"/Views/Shared/Components/RequestCount/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/RequestCount/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_RequestCount_Default))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c154541b0c9e5e28ae2f4b025ec0ea87be9dd79", @"/Views/Shared/Components/RequestCount/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f9b6611511e8f44c76273d3d541a13a7f34e893", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_RequestCount_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(12, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 4 "C:\Users\ADRIAN\Desktop\BOOM\jpp_boiler\JPP_CAPROJ2\Views\Shared\Components\RequestCount\Default.cshtml"
  
    if (Model != 0)
    {

#line default
#line hidden
            BeginContext(48, 45, true);
            WriteLiteral("    <span class=\"badge bg-warning\">\r\n        ");
            EndContext();
            BeginContext(94, 5, false);
#line 8 "C:\Users\ADRIAN\Desktop\BOOM\jpp_boiler\JPP_CAPROJ2\Views\Shared\Components\RequestCount\Default.cshtml"
   Write(Model);

#line default
#line hidden
            EndContext();
            BeginContext(99, 15, true);
            WriteLiteral("\r\n    </span>\r\n");
            EndContext();
#line 10 "C:\Users\ADRIAN\Desktop\BOOM\jpp_boiler\JPP_CAPROJ2\Views\Shared\Components\RequestCount\Default.cshtml"
            }
            

#line default
#line hidden
            BeginContext(144, 15, true);
            WriteLiteral("\r\n\r\n     \r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int> Html { get; private set; }
    }
}
#pragma warning restore 1591
