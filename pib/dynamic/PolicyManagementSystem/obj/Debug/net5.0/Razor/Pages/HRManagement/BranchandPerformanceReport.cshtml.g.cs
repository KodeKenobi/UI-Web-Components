#pragma checksum "C:\Users\MasegoMsomiMfundoped\source\repos\pibmtgrepo\pibmtgrepo\PolicyManagementSystem\Pages\HRManagement\BranchandPerformanceReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "21cdc9e8c2c41704f74c3b9351392a0cd453d4ea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(PolicyManagementSystem.Pages.HRManagement.Pages_HRManagement_BranchandPerformanceReport), @"mvc.1.0.view", @"/Pages/HRManagement/BranchandPerformanceReport.cshtml")]
namespace PolicyManagementSystem.Pages.HRManagement
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
#line 1 "C:\Users\MasegoMsomiMfundoped\source\repos\pibmtgrepo\pibmtgrepo\PolicyManagementSystem\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\MasegoMsomiMfundoped\source\repos\pibmtgrepo\pibmtgrepo\PolicyManagementSystem\Pages\_ViewImports.cshtml"
using PolicyManagementSystem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\MasegoMsomiMfundoped\source\repos\pibmtgrepo\pibmtgrepo\PolicyManagementSystem\Pages\_ViewImports.cshtml"
using PolicyManagementSystem.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"21cdc9e8c2c41704f74c3b9351392a0cd453d4ea", @"/Pages/HRManagement/BranchandPerformanceReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc6def2faeb211b4b868df841df48a131588104e", @"/Pages/_ViewImports.cshtml")]
    public class Pages_HRManagement_BranchandPerformanceReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PolicyManagementSystem.Controllers.Models.HRManagementViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!-- ============================================================== -->
<!-- pageheader -->
<!-- ============================================================== -->
<div class=""row"">
    <div class=""col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12"">
        <div class=""page-header"">
            <h2 class=""pageheader-title"">Performance Metrics, Rates and Benefits Management</h2>
            <p class=""pageheader-text""></p>
            <div class=""page-breadcrumb"">
                <nav aria-label=""breadcrumb"">
                    <ol class=""breadcrumb"">
");
            WriteLiteral("                        <li class=\"breadcrumb-item\"><a href=\"#\" class=\"breadcrumb-link\">Branch and Performance Report</a></li>\r\n");
            WriteLiteral("                    </ol>\r\n                </nav>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div>\r\n    <iframe");
            BeginWriteAttribute("src", " src=\"", 1116, "\"", 1147, 1);
#nullable restore
#line 27 "C:\Users\MasegoMsomiMfundoped\source\repos\pibmtgrepo\pibmtgrepo\PolicyManagementSystem\Pages\HRManagement\BranchandPerformanceReport.cshtml"
WriteAttributeValue("", 1122, Model.PerfomanceFrameUrl, 1122, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" frameborder=\"0\" width=\"100%\" height=\"600\" allowtransparency></iframe>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PolicyManagementSystem.Controllers.Models.HRManagementViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
