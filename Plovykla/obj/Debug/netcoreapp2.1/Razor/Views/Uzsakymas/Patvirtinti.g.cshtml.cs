#pragma checksum "C:\Users\Mode\source\repos\Plovykla\Plovykla\Views\Uzsakymas\Patvirtinti.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "44baf0fe831c9bc721c8631a26605774bdbd5e89"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Uzsakymas_Patvirtinti), @"mvc.1.0.view", @"/Views/Uzsakymas/Patvirtinti.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Uzsakymas/Patvirtinti.cshtml", typeof(AspNetCore.Views_Uzsakymas_Patvirtinti))]
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
#line 1 "C:\Users\Mode\source\repos\Plovykla\Plovykla\Views\_ViewImports.cshtml"
using Plovykla;

#line default
#line hidden
#line 2 "C:\Users\Mode\source\repos\Plovykla\Plovykla\Views\_ViewImports.cshtml"
using Plovykla.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44baf0fe831c9bc721c8631a26605774bdbd5e89", @"/Views/Uzsakymas/Patvirtinti.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4713744316fd3a9ad53594ff152d5ac06eb35659", @"/Views/_ViewImports.cshtml")]
    public class Views_Uzsakymas_Patvirtinti : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Plovykla.Models.Uzsakymas>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PatvirtintiAct", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\Mode\source\repos\Plovykla\Plovykla\Views\Uzsakymas\Patvirtinti.cshtml"
  
    ViewData["Title"] = "Patvirtinti";
    Layout = "~/Views/Shared/_LayoutAdmin.cshtml";

#line default
#line hidden
            BeginContext(148, 558, true);
            WriteLiteral(@"
<h3 class=""login"">Patvirtinti užsakymą</h3>

<p>
</p>

<table class=""table"">
    <thead>
        <tr>
            <th>
                Uzsakymo data
            </th>
            <th>
                Kaina
            </th>
            <th>
                Darbuotojas
            </th>
            <th>
                Klientas
            </th>
            <th>
                Paslauga
            </th>
            <th>
                Busena
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 38 "C:\Users\Mode\source\repos\Plovykla\Plovykla\Views\Uzsakymas\Patvirtinti.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(738, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(787, 48, false);
#line 41 "C:\Users\Mode\source\repos\Plovykla\Plovykla\Views\Uzsakymas\Patvirtinti.cshtml"
           Write(Html.DisplayFor(modelItem => item.uzsakymo_Data));

#line default
#line hidden
            EndContext();
            BeginContext(835, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(891, 48, false);
#line 44 "C:\Users\Mode\source\repos\Plovykla\Plovykla\Views\Uzsakymas\Patvirtinti.cshtml"
           Write(Html.DisplayFor(modelItem => item.uzsakymoKaina));

#line default
#line hidden
            EndContext();
            BeginContext(939, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(995, 57, false);
#line 47 "C:\Users\Mode\source\repos\Plovykla\Plovykla\Views\Uzsakymas\Patvirtinti.cshtml"
           Write(Html.DisplayFor(modelItem => item.Vartotojai.vartotojoId));

#line default
#line hidden
            EndContext();
            BeginContext(1052, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1108, 55, false);
#line 50 "C:\Users\Mode\source\repos\Plovykla\Plovykla\Views\Uzsakymas\Patvirtinti.cshtml"
           Write(Html.DisplayFor(modelItem => item.Klientai.vartotojoId));

#line default
#line hidden
            EndContext();
            BeginContext(1163, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1219, 55, false);
#line 53 "C:\Users\Mode\source\repos\Plovykla\Plovykla\Views\Uzsakymas\Patvirtinti.cshtml"
           Write(Html.DisplayFor(modelItem => item.Paslauga.paslaugosId));

#line default
#line hidden
            EndContext();
            BeginContext(1274, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1330, 52, false);
#line 56 "C:\Users\Mode\source\repos\Plovykla\Plovykla\Views\Uzsakymas\Patvirtinti.cshtml"
           Write(Html.DisplayFor(modelItem => item.Busenos.busenosId));

#line default
#line hidden
            EndContext();
            BeginContext(1382, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1437, 288, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ba1ae52a14de4adf91bb2dc16f863c44", async() => {
                BeginContext(1471, 22, true);
                WriteLiteral("\r\n                    ");
                EndContext();
                BeginContext(1494, 23, false);
#line 60 "C:\Users\Mode\source\repos\Plovykla\Plovykla\Views\Uzsakymas\Patvirtinti.cshtml"
               Write(Html.AntiForgeryToken());

#line default
#line hidden
                EndContext();
                BeginContext(1517, 76, true);
                WriteLiteral("\r\n                    <input type=\"hidden\" name=\"uzsakymoId\" id=\"uzsakymoId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1593, "\"", 1617, 1);
#line 61 "C:\Users\Mode\source\repos\Plovykla\Plovykla\Views\Uzsakymas\Patvirtinti.cshtml"
WriteAttributeValue("", 1601, item.uzsakymoId, 1601, 16, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1618, 100, true);
                WriteLiteral(" />\r\n                    <input type=\"submit\" name=\"Submit\" value=\"Patvirtinti\" />\r\n                ");
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
            BeginContext(1725, 75, true);
            WriteLiteral("\r\n                   \r\n                \r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 68 "C:\Users\Mode\source\repos\Plovykla\Plovykla\Views\Uzsakymas\Patvirtinti.cshtml"
}

#line default
#line hidden
            BeginContext(1803, 24, true);
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
