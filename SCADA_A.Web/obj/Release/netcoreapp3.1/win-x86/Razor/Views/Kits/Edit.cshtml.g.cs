#pragma checksum "C:\Project\Web\SCADA_A\SCADA_A.Web\Views\Kits\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2507398b1b1412bdba52ee89ccc6025a9c271fda"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Kits_Edit), @"mvc.1.0.view", @"/Views/Kits/Edit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2507398b1b1412bdba52ee89ccc6025a9c271fda", @"/Views/Kits/Edit.cshtml")]
    #nullable restore
    public class Views_Kits_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SCADA_A.Entidades.OnePieceFlow.Kit>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Project\Web\SCADA_A\SCADA_A.Web\Views\Kits\Edit.cshtml"
  
    ViewData["Title"] = "Edit";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Edit</h1>

<h4>Kit</h4>
<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""Edit"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <input type=""hidden"" asp-for=""idKit"" />
            <div class=""form-group"">
                <label asp-for=""Nombre"" class=""control-label""></label>
                <input asp-for=""Nombre"" class=""form-control"" />
                <span asp-validation-for=""Nombre"" class=""text-danger""></span>
            </div>
            <div class=""form-group form-check"">
                <label class=""form-check-label"">
                    <input class=""form-check-input"" asp-for=""Estatus"" /> ");
#nullable restore
#line 24 "C:\Project\Web\SCADA_A\SCADA_A.Web\Views\Kits\Edit.cshtml"
                                                                    Write(Html.DisplayNameFor(model => model.Estatus));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </label>
            </div>
            <div class=""form-group"">
                <label asp-for=""idLinea"" class=""control-label""></label>
                <select asp-for=""idLinea"" class=""form-control"" asp-items=""ViewBag.idLinea""></select>
                <span asp-validation-for=""idLinea"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <input type=""submit"" value=""Save"" class=""btn btn-primary"" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action=""Index"">Back to List</a>
</div>

");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SCADA_A.Entidades.OnePieceFlow.Kit> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
