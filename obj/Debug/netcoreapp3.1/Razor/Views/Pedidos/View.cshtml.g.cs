#pragma checksum "C:\Users\Jose Giron\Desktop\Programas estructuras\EstruturaDatos_Lab02\Views\Pedidos\View.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "95f633afe66a65a903f773a218335fef7dba4eca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pedidos_View), @"mvc.1.0.view", @"/Views/Pedidos/View.cshtml")]
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
#line 1 "C:\Users\Jose Giron\Desktop\Programas estructuras\EstruturaDatos_Lab02\Views\_ViewImports.cshtml"
using EstrusturasDatos_Lab02;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Jose Giron\Desktop\Programas estructuras\EstruturaDatos_Lab02\Views\_ViewImports.cshtml"
using EstrusturasDatos_Lab02.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"95f633afe66a65a903f773a218335fef7dba4eca", @"/Views/Pedidos/View.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"33a8812c58ab095954aba28287ac55d370972d5b", @"/Views/_ViewImports.cshtml")]
    public class Views_Pedidos_View : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EstrusturasDatos_Lab02.Models.PaginacionModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Home/Index"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n    <html>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "95f633afe66a65a903f773a218335fef7dba4eca3859", async() => {
                WriteLiteral("\r\n        <title>ASP.NET MVC - Pagination Example</title>\r\n        <link rel=\"stylesheet\" href=\"//netdna.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css\">\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "95f633afe66a65a903f773a218335fef7dba4eca5002", async() => {
                WriteLiteral("\r\n        <div class=\"container\">\r\n            <div class=\"col-md-6 col-md-offset-3\">\r\n                <h1>ASP.NET MVC - Pagination Example</h1>\r\n\r\n                <ul>\r\n");
#nullable restore
#line 14 "C:\Users\Jose Giron\Desktop\Programas estructuras\EstruturaDatos_Lab02\Views\Pedidos\View.cshtml"
                     foreach (var item in Model.Items)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 18 "C:\Users\Jose Giron\Desktop\Programas estructuras\EstruturaDatos_Lab02\Views\Pedidos\View.cshtml"
                       Write(Html.DisplayFor(modelItem => item));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 21 "C:\Users\Jose Giron\Desktop\Programas estructuras\EstruturaDatos_Lab02\Views\Pedidos\View.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </ul>\r\n\r\n");
#nullable restore
#line 24 "C:\Users\Jose Giron\Desktop\Programas estructuras\EstruturaDatos_Lab02\Views\Pedidos\View.cshtml"
                 if (Model.Pager.EndPage > 1)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <ul class=\"pagination\">\r\n");
#nullable restore
#line 27 "C:\Users\Jose Giron\Desktop\Programas estructuras\EstruturaDatos_Lab02\Views\Pedidos\View.cshtml"
                         if (Model.Pager.CurrentPage > 1)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <li>\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "95f633afe66a65a903f773a218335fef7dba4eca7128", async() => {
                    WriteLiteral("First");
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            </li>\r\n                            <li>\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "95f633afe66a65a903f773a218335fef7dba4eca8367", async() => {
                    WriteLiteral("Previous");
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 1147, "~/Home/Index?page=", 1147, 18, true);
#nullable restore
#line 33 "C:\Users\Jose Giron\Desktop\Programas estructuras\EstruturaDatos_Lab02\Views\Pedidos\View.cshtml"
AddHtmlAttributeValue("", 1165, Model.Pager.CurrentPage - 1, 1165, 30, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            </li>\r\n");
#nullable restore
#line 35 "C:\Users\Jose Giron\Desktop\Programas estructuras\EstruturaDatos_Lab02\Views\Pedidos\View.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 37 "C:\Users\Jose Giron\Desktop\Programas estructuras\EstruturaDatos_Lab02\Views\Pedidos\View.cshtml"
                         for (var page = Model.Pager.StartPage; page <= Model.Pager.EndPage; page++)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <li");
                BeginWriteAttribute("class", " class=\"", 1435, "\"", 1493, 1);
#nullable restore
#line 39 "C:\Users\Jose Giron\Desktop\Programas estructuras\EstruturaDatos_Lab02\Views\Pedidos\View.cshtml"
WriteAttributeValue("", 1443, page == Model.Pager.CurrentPage ? "active" : "", 1443, 50, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                \r\n                            </li>\r\n");
#nullable restore
#line 42 "C:\Users\Jose Giron\Desktop\Programas estructuras\EstruturaDatos_Lab02\Views\Pedidos\View.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 44 "C:\Users\Jose Giron\Desktop\Programas estructuras\EstruturaDatos_Lab02\Views\Pedidos\View.cshtml"
                         if (Model.Pager.CurrentPage < Model.Pager.TotalPages)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <li>\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "95f633afe66a65a903f773a218335fef7dba4eca11800", async() => {
                    WriteLiteral("Next");
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 1777, "~/Home/Index?page=", 1777, 18, true);
#nullable restore
#line 47 "C:\Users\Jose Giron\Desktop\Programas estructuras\EstruturaDatos_Lab02\Views\Pedidos\View.cshtml"
AddHtmlAttributeValue("", 1795, Model.Pager.CurrentPage + 1, 1795, 30, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            </li>\r\n                            <li>\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "95f633afe66a65a903f773a218335fef7dba4eca13541", async() => {
                    WriteLiteral("Last");
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 1947, "~/Home/Index?page=", 1947, 18, true);
#nullable restore
#line 50 "C:\Users\Jose Giron\Desktop\Programas estructuras\EstruturaDatos_Lab02\Views\Pedidos\View.cshtml"
AddHtmlAttributeValue("", 1965, Model.Pager.TotalPages, 1965, 25, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            </li>\r\n");
#nullable restore
#line 52 "C:\Users\Jose Giron\Desktop\Programas estructuras\EstruturaDatos_Lab02\Views\Pedidos\View.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </ul>\r\n");
#nullable restore
#line 54 "C:\Users\Jose Giron\Desktop\Programas estructuras\EstruturaDatos_Lab02\Views\Pedidos\View.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </div>\r\n        </div>\r\n        <hr />\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EstrusturasDatos_Lab02.Models.PaginacionModel> Html { get; private set; }
    }
}
#pragma warning restore 1591