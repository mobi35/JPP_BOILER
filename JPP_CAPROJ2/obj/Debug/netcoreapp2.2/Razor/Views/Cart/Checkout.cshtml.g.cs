#pragma checksum "C:\Users\Lenovo\Desktop\JPP_BOILER-master\JPP_CAPROJ2\Views\Cart\Checkout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "80696bbf7757de3527b5a42f995983efb121c597"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_Checkout), @"mvc.1.0.view", @"/Views/Cart/Checkout.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Cart/Checkout.cshtml", typeof(AspNetCore.Views_Cart_Checkout))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80696bbf7757de3527b5a42f995983efb121c597", @"/Views/Cart/Checkout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24ae6b3904c003feacca99665b1cd2b511c61e8b", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_Checkout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ProductCartViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("return", new global::Microsoft.AspNetCore.Html.HtmlString("confirm(\'are you sure you want to delete?\')"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Cart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RemoveItemCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Checkout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Lenovo\Desktop\JPP_BOILER-master\JPP_CAPROJ2\Views\Cart\Checkout.cshtml"
  
    ViewData["Title"] = "Privacy Policy";
    Layout = "Client";

#line default
#line hidden
            BeginContext(111, 3442, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "80696bbf7757de3527b5a42f995983efb121c5975497", async() => {
                BeginContext(175, 2154, true);
                WriteLiteral(@"
    <section id=""main-content"">
        <div class=""wrapper"">
            <div class=""row mt"">
                <div class=""col-lg-8"">
                    <div class=""form-panel"">
                        <h1>Checkout Page</h1>


                        <input id=""cod"" value=""cod"" name=""paytype"" type=""radio"" /> COD
                        <input id=""bank"" value=""bank"" name=""paytype"" type=""radio"" />  Bank Deposit
                        <div id=""step1"">


                            <br />
                            <div id=""COD"">

                            </div>

                            <div id=""BankAccount"">
                                <br />
                                <input type=""hidden"" id=""bid"" value=""0"" placeholder=""Bank Account"" class=""form-control"" name=""bankNumer"" /><br />
                                <input type=""hidden"" id=""bnum"" value=""0"" placeholder=""Bank Account Number"" class=""form-control"" name=""bankAccount"" />
                            </div>

                            <");
                WriteLiteral(@"a href=""#"" id=""nextStep"">Next Step</a>

                        </div>

                        <div id=""step2"">
                            <h3>Are you sure you want to do this transaction ?</h3>

                            <br />

                            <div  id=""showPayment"">

                            </div>
                            <a href=""#"" id=""previousStep"">Previous Step</a>
                            <button onclick=""return Validate()"">Confirm Checkout</button>
                        </div>



                    </div>
                </div>
                <div class=""col-lg-4"">
                    <div class=""form-panel"">
                        <table class=""table table-striped table-bordered responsive no-wrap"" style=""width:100%"" id=""userList"">
                            <thead>
                                <tr>
                                    <th>Product Name</th>
                                    <th>Quantity</th>
                                    <th>Price</th>
     ");
                WriteLiteral("                           </tr>\n                            </thead>\n                            <tbody>\n");
                EndContext();
#line 62 "C:\Users\Lenovo\Desktop\JPP_BOILER-master\JPP_CAPROJ2\Views\Cart\Checkout.cshtml"
                                  
                                    double? totalPrice = 0;
                                    foreach (var product in Model)
                                    {
                                        totalPrice += product.Cart.Quantity * product.Product.Price;

#line default
#line hidden
                BeginContext(2630, 109, true);
                WriteLiteral("                                                <tr>\n                                                    <td>");
                EndContext();
                BeginContext(2740, 27, false);
#line 68 "C:\Users\Lenovo\Desktop\JPP_BOILER-master\JPP_CAPROJ2\Views\Cart\Checkout.cshtml"
                                                   Write(product.Product.ProductName);

#line default
#line hidden
                EndContext();
                BeginContext(2767, 63, true);
                WriteLiteral("</td>\n\n                                                    <td>");
                EndContext();
                BeginContext(2831, 21, false);
#line 70 "C:\Users\Lenovo\Desktop\JPP_BOILER-master\JPP_CAPROJ2\Views\Cart\Checkout.cshtml"
                                                   Write(product.Cart.Quantity);

#line default
#line hidden
                EndContext();
                BeginContext(2852, 63, true);
                WriteLiteral("</td>\n\n                                                    <td>");
                EndContext();
                BeginContext(2916, 35, false);
#line 72 "C:\Users\Lenovo\Desktop\JPP_BOILER-master\JPP_CAPROJ2\Views\Cart\Checkout.cshtml"
                                                   Write(product.Product.Price.ToString("N"));

#line default
#line hidden
                EndContext();
                BeginContext(2951, 62, true);
                WriteLiteral("</td>\n                                                    <td>");
                EndContext();
                BeginContext(3013, 153, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "80696bbf7757de3527b5a42f995983efb121c59710244", async() => {
                    BeginContext(3156, 6, true);
                    WriteLiteral("Remove");
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
#line 73 "C:\Users\Lenovo\Desktop\JPP_BOILER-master\JPP_CAPROJ2\Views\Cart\Checkout.cshtml"
                                                                                                                  WriteLiteral(product.Cart.CartKey);

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
                BeginContext(3166, 62, true);
                WriteLiteral("  </td>\n                                                </tr>\n");
                EndContext();
#line 75 "C:\Users\Lenovo\Desktop\JPP_BOILER-master\JPP_CAPROJ2\Views\Cart\Checkout.cshtml"
                                    }
                                

#line default
#line hidden
                BeginContext(3300, 107, true);
                WriteLiteral("                            </tbody>\n                        </table>\n                        <p>Total : P ");
                EndContext();
                BeginContext(3408, 30, false);
#line 79 "C:\Users\Lenovo\Desktop\JPP_BOILER-master\JPP_CAPROJ2\Views\Cart\Checkout.cshtml"
                                Write(totalPrice.Value.ToString("N"));

#line default
#line hidden
                EndContext();
                BeginContext(3438, 108, true);
                WriteLiteral(" </p>\n                    </div>\n                </div>\n\n\n            </div>\n        </div>\n\n    </section>\n");
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
            BeginContext(3553, 1367, true);
            WriteLiteral(@"
<br />
<br />

<script>

    function Validate() {
        var bankcheck = document.getElementById(""bank"");

        if (bankcheck.checked) {
            if ($('#bid').val() == """" || $('#bnum').val() == """") { 
                alert(""Please put details"");
                return false;
             }
        }
    }


    var paymentType = """";
    $('#step2').hide();
    $('#step1').hide();
    $('#nextStep').click(function () {

        $('#step1').hide();
        $(' #step2').show();

        if (paymentType == ""bank"") {
          
        } else {
            $('#showPayment').html('<h2>Cash on delivery</h2>');
        }
    });
    $('#previousStep').click(function () {
        $('#step2').hide();
        $('#step1').show();

    });



    $('#BankAccount').hide();
    $('#COD').hide();

    function MyFunction() {
        alert(""asdasd"");
    }

    $('#bank').click(function () {
        paymentType = ""bank"";

        $('#BankAccount').show();
        $('#COD').hide();
        $('#step1').show();


     ");
            WriteLiteral(@"   $('#step2').hide();
        $(' #step1').show();
    })

    $('#cod').click(function () {
        paymentType = ""cod"";
        $('#bid').val('');
        $('#bnum').val(''); 
        $('#step1').show();
        $('#COD').show();
        $('#BankAccount').hide();

        $('#step2').hide();
        $(' #step1').show();
    })

</script>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ProductCartViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
