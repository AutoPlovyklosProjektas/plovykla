#pragma checksum "C:\Users\Zilvinas\Source\Repos\plovykla\Plovykla\Views\Uzsakymas\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3e9b6d510e06dcb7978612f73a78d07b8575bbd7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Uzsakymas_Index), @"mvc.1.0.view", @"/Views/Uzsakymas/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Uzsakymas/Index.cshtml", typeof(AspNetCore.Views_Uzsakymas_Index))]
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
#line 1 "C:\Users\Zilvinas\Source\Repos\plovykla\Plovykla\Views\_ViewImports.cshtml"
using Plovykla;

#line default
#line hidden
#line 2 "C:\Users\Zilvinas\Source\Repos\plovykla\Plovykla\Views\_ViewImports.cshtml"
using Plovykla.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e9b6d510e06dcb7978612f73a78d07b8575bbd7", @"/Views/Uzsakymas/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4713744316fd3a9ad53594ff152d5ac06eb35659", @"/Views/_ViewImports.cshtml")]
    public class Views_Uzsakymas_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Plovykla.Models.Uzsakymas>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PridetiDarb", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(47, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Zilvinas\Source\Repos\plovykla\Plovykla\Views\Uzsakymas\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_LayoutAdmin.cshtml";

#line default
#line hidden
            BeginContext(142, 136, true);
            WriteLiteral("\r\n<h3 class=\"login\">Darbuotojo pridėjimas</h3>\r\n\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(279, 49, false);
#line 15 "C:\Users\Zilvinas\Source\Repos\plovykla\Plovykla\Views\Uzsakymas\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.uzsakymo_Data));

#line default
#line hidden
            EndContext();
            BeginContext(328, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(384, 49, false);
#line 18 "C:\Users\Zilvinas\Source\Repos\plovykla\Plovykla\Views\Uzsakymas\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.uzsakymoKaina));

#line default
#line hidden
            EndContext();
            BeginContext(433, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(489, 46, false);
#line 21 "C:\Users\Zilvinas\Source\Repos\plovykla\Plovykla\Views\Uzsakymas\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Vartotojai));

#line default
#line hidden
            EndContext();
            BeginContext(535, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(591, 44, false);
#line 24 "C:\Users\Zilvinas\Source\Repos\plovykla\Plovykla\Views\Uzsakymas\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Klientai));

#line default
#line hidden
            EndContext();
            BeginContext(635, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(691, 44, false);
#line 27 "C:\Users\Zilvinas\Source\Repos\plovykla\Plovykla\Views\Uzsakymas\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Paslauga));

#line default
#line hidden
            EndContext();
            BeginContext(735, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(791, 43, false);
#line 30 "C:\Users\Zilvinas\Source\Repos\plovykla\Plovykla\Views\Uzsakymas\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Busenos));

#line default
#line hidden
            EndContext();
            BeginContext(834, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 36 "C:\Users\Zilvinas\Source\Repos\plovykla\Plovykla\Views\Uzsakymas\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(952, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1001, 48, false);
#line 39 "C:\Users\Zilvinas\Source\Repos\plovykla\Plovykla\Views\Uzsakymas\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.uzsakymo_Data));

#line default
#line hidden
            EndContext();
            BeginContext(1049, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1105, 48, false);
#line 42 "C:\Users\Zilvinas\Source\Repos\plovykla\Plovykla\Views\Uzsakymas\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.uzsakymoKaina));

#line default
#line hidden
            EndContext();
            BeginContext(1153, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1209, 57, false);
#line 45 "C:\Users\Zilvinas\Source\Repos\plovykla\Plovykla\Views\Uzsakymas\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Vartotojai.vartotojoId));

#line default
#line hidden
            EndContext();
            BeginContext(1266, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1322, 55, false);
#line 48 "C:\Users\Zilvinas\Source\Repos\plovykla\Plovykla\Views\Uzsakymas\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Klientai.vartotojoId));

#line default
#line hidden
            EndContext();
            BeginContext(1377, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1433, 55, false);
#line 51 "C:\Users\Zilvinas\Source\Repos\plovykla\Plovykla\Views\Uzsakymas\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Paslauga.paslaugosId));

#line default
#line hidden
            EndContext();
            BeginContext(1488, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1544, 52, false);
#line 54 "C:\Users\Zilvinas\Source\Repos\plovykla\Plovykla\Views\Uzsakymas\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Busenos.busenosId));

#line default
#line hidden
            EndContext();
            BeginContext(1596, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1651, 280, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dc0820c5a26748de8331aeaedc58e7c8", async() => {
                BeginContext(1682, 22, true);
                WriteLiteral("\r\n                    ");
                EndContext();
                BeginContext(1705, 23, false);
#line 58 "C:\Users\Zilvinas\Source\Repos\plovykla\Plovykla\Views\Uzsakymas\Index.cshtml"
               Write(Html.AntiForgeryToken());

#line default
#line hidden
                EndContext();
                BeginContext(1728, 76, true);
                WriteLiteral("\r\n                    <input type=\"hidden\" name=\"uzsakymoId\" id=\"uzsakymoId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1804, "\"", 1828, 1);
#line 59 "C:\Users\Zilvinas\Source\Repos\plovykla\Plovykla\Views\Uzsakymas\Index.cshtml"
WriteAttributeValue("", 1812, item.uzsakymoId, 1812, 16, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1829, 95, true);
                WriteLiteral(" />\r\n                    <input type=\"submit\" name=\"Submit\" value=\"Baigti\" />\r\n                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1931, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 64 "C:\Users\Zilvinas\Source\Repos\plovykla\Plovykla\Views\Uzsakymas\Index.cshtml"
}

#line default
#line hidden
            BeginContext(1970, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Plovykla.Models.Uzsakymas>> Html { get; private set; }
    }
}
#pragma warning restore 1591
