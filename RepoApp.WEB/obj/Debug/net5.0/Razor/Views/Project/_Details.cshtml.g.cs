#pragma checksum "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\Project\_Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "97973cef047107f961c2aff082273dbcb5d23a85"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Project__Details), @"mvc.1.0.view", @"/Views/Project/_Details.cshtml")]
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
#line 1 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\_ViewImports.cshtml"
using RepoApp.WEB;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\_ViewImports.cshtml"
using RepoApp.WEB.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"97973cef047107f961c2aff082273dbcb5d23a85", @"/Views/Project/_Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4505eb805fbb61849aba5e6bfc78a0241f85f29d", @"/Views/_ViewImports.cshtml")]
    public class Views_Project__Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RepoApp.BLL.Models.DetailModels.ProjectDetailsModel>
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "97973cef047107f961c2aff082273dbcb5d23a853373", async() => {
                WriteLiteral("\r\n    <br />\r\n    <div class=\"container\">\r\n");
                WriteLiteral("        <div class=\"row\">\r\n            <div class=\"col-sm-3\">\r\n                ");
#nullable restore
#line 22 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\Project\_Details.cshtml"
           Write(Html.LabelFor(m => m.Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n            <div class=\"col-sm-9\">\r\n                <span>");
#nullable restore
#line 25 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\Project\_Details.cshtml"
                 Write(Model.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n            </div>\r\n        </div>\r\n        <div class=\"row\">\r\n            <div class=\"col-sm-3\">\r\n                ");
#nullable restore
#line 30 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\Project\_Details.cshtml"
           Write(Html.LabelFor(m => m.Department));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n            <div class=\"col-sm-9\">\r\n                <span>");
#nullable restore
#line 33 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\Project\_Details.cshtml"
                 Write(Model.Department);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n            </div>\r\n        </div>\r\n        <div class=\"row\">\r\n            <div class=\"col-sm-3\">\r\n                ");
#nullable restore
#line 38 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\Project\_Details.cshtml"
           Write(Html.LabelFor(m => m.User));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n            <div class=\"col-sm-9\">\r\n                <span>");
#nullable restore
#line 41 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\Project\_Details.cshtml"
                 Write(Model.User);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n            </div>\r\n        </div>\r\n        <div class=\"row\">\r\n            <div class=\"col-sm-3\">\r\n                ");
#nullable restore
#line 46 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\Project\_Details.cshtml"
           Write(Html.LabelFor(m => m.Username));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n            <div class=\"col-sm-9\">\r\n                <span>");
#nullable restore
#line 49 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\Project\_Details.cshtml"
                 Write(Model.Username);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"row\">\r\n            <div class=\"col-sm-3\">\r\n                ");
#nullable restore
#line 55 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\Project\_Details.cshtml"
           Write(Html.LabelFor(m => m.Repositories));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n            <div class=\"col-sm-9\">\r\n\r\n");
#nullable restore
#line 59 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\Project\_Details.cshtml"
                 foreach (var repo in Model.Repositories)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <span>");
#nullable restore
#line 61 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\Project\_Details.cshtml"
                     Write(repo);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                    <br />\r\n");
#nullable restore
#line 63 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\Project\_Details.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n    <br />\r\n\r\n    <div class=\"modal-footer\"></div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RepoApp.BLL.Models.DetailModels.ProjectDetailsModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
