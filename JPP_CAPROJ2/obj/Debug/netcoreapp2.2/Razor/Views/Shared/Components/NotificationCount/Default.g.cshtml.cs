#pragma checksum "C:\Users\ADRIAN\Desktop\JPP_BOILER-master\JPP_BOILER-master\JPP_CAPROJ2\Views\Shared\Components\NotificationCount\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "395f8bcbaa698bb3153357b230d3620bf34aecc4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_NotificationCount_Default), @"mvc.1.0.view", @"/Views/Shared/Components/NotificationCount/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/NotificationCount/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_NotificationCount_Default))]
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
#line 1 "C:\Users\ADRIAN\Desktop\JPP_BOILER-master\JPP_BOILER-master\JPP_CAPROJ2\Views\_ViewImports.cshtml"
using JPP_CAPROJ2;

#line default
#line hidden
#line 2 "C:\Users\ADRIAN\Desktop\JPP_BOILER-master\JPP_BOILER-master\JPP_CAPROJ2\Views\_ViewImports.cshtml"
using JPP_CAPROJ2.Models;

#line default
#line hidden
#line 4 "C:\Users\ADRIAN\Desktop\JPP_BOILER-master\JPP_BOILER-master\JPP_CAPROJ2\Views\_ViewImports.cshtml"
using JPP_CAPROJ2.Data.Model;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"395f8bcbaa698bb3153357b230d3620bf34aecc4", @"/Views/Shared/Components/NotificationCount/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dc651bbfcd05258b6c6e8635c10a76d788886043", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_NotificationCount_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Notification>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(33, 2, true);
            WriteLiteral("\n\n");
            EndContext();
            BeginContext(36, 13, false);
#line 4 "C:\Users\ADRIAN\Desktop\JPP_BOILER-master\JPP_BOILER-master\JPP_CAPROJ2\Views\Shared\Components\NotificationCount\Default.cshtml"
Write(Model.Count());

#line default
#line hidden
            EndContext();
            BeginContext(49, 1, true);
            WriteLiteral("\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Notification>> Html { get; private set; }
    }
}
#pragma warning restore 1591
