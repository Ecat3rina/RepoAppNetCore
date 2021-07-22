#pragma checksum "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\Project\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "55d2a79e650449f4e4e35307f62e2f921423e389"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Project_Index), @"mvc.1.0.view", @"/Views/Project/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55d2a79e650449f4e4e35307f62e2f921423e389", @"/Views/Project/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4505eb805fbb61849aba5e6bfc78a0241f85f29d", @"/Views/_ViewImports.cshtml")]
    public class Views_Project_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\Project\Index.cshtml"
  
    ViewBag.Title = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<h2>Projects</h2>

<div class=""modal fade"" id=""projectModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""ModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
                <h3 id=""modal-title""></h3>
            </div>
            <div class=""body"">
                <!-- Modal body -->
            </div>

        </div>
    </div>
</div>

<table id=""table"" class=""table table-bordered table-striped"">
</table>

");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">
        $(document).ready(function () {

            var logout = $(""a[href$='Account/LogOut']"").text();
            var loggedUsername = logout.replace('Exit ', '');
            $.ajax(
                {
                    type: ""Get"",
                    url: """);
#nullable restore
#line 35 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\Project\Index.cshtml"
                     Write(Url.Action("GetRole", "Project"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""",
                    dataType: 'JSON',
                    data: {
                        name: loggedUsername,
                    },

                    success: function (response) {
                        if (response == 'Admin') {

                $(""#table"").DataTable({
                    autoWidth: false,
                    serverSide: true,

                    //dom:
                    //    ""<'row'<'col-sm-3'l><'col-sm-9'fB>>"" +
                    //    ""<'row'<'col-sm-12'tr>>"" +
                    //    ""<'row'<'col-sm-5'i><'col-sm-7'p>>"",
                    //buttons: [
                    //    {
                    //        text: 'Add',
                    //        action: function (e, dt, node, config) {
                    //            window.location.href = ""https://localhost:44367/Project/Add"";
                    //        }
                    //    }
                    //],
                    //language: { search: """" },


                    ""co");
                WriteLiteral(@"lumns"": [
                        {
                            data: 'Id',
                            name: 'Id',
                            visible: false
                        },
                        {

                            data: 'Name',
                            name: 'Name',
                            title: 'Project name',
                            ""autoWidth"": true
                        },
                        {
                            data: 'Department',
                            name: 'Department',
                            title: 'Department',
                            ""autoWidth"": true

                        },
                        {
                            data: 'User',
                            name: 'User',
                            title: 'Cedacri International responsible user',
                            ""autoWidth"": true
                        },
                        {
                            data: 'Username',");
                WriteLiteral(@"
                            name: 'Username',
                            title: 'Cedacri Italia responsible user name',
                        },

                        {
                            data: null,
                            orderable: false,
                            className: 'text-center',
                            render: function (data, type, row) {
                                return ""<a href='");
#nullable restore
#line 100 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\Project\Index.cshtml"
                                            Write(Url.Action("GetEdit","Project"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"/"" + row.Id + ""'class='btn btn-warning projectEdit' title='Edit'><span class='glyphicon glyphicon-pencil'></span></a>"";
                            }
                        },
                        {
                            data: null,
                            orderable: false,
                            className: 'text-center',
                            render: function (data, type, row) {
                                return ""<a href='");
#nullable restore
#line 108 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\Project\Index.cshtml"
                                            Write(Url.Action("GetDetails","Project"));

#line default
#line hidden
#nullable disable
                WriteLiteral("/\" + row.Id + \"\'class=\'btn btn-info projectInfo\' title=\'Details\'><span class=\'glyphicon glyphicon-info-sign\'></span></a>\";\r\n                            }\r\n                        },\r\n");
                WriteLiteral("                    ],\r\n\r\n\r\n                    ajax: {\r\n                        url: \"");
#nullable restore
#line 123 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\Project\Index.cshtml"
                         Write(Url.Action("GetProjects", "Project"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""",
                        type: ""Post"",

                    },



                    initComplete: function () {
                        var input = $("".dataTables_filter input"").unbind();
                        var inputVar = $("".dataTables_filter input"");
                        $(""#myTable_filter"").append(inputVar);
                        $(""#myTable_filter label"").remove();
                        self = this.api(),
                            $searchButton = $(""<button class='btn btn-sm btn-default'>"")
                                .text(""Search"")
                                .click(function () {
                                    self.search(input.val()).draw();
                                })
                        $("".dataTables_filter"").append($searchButton);
                    },
                })
            }

                        if (response == '""Operator""') {

                dataTable = $(""#table"").DataTable({
                    autoWidth: false,
                WriteLiteral(@"
                    serverSide: true,

                   
                    language: { search: """" },


                    ""columns"": [
                        {
                            data: 'Id',
                            name: 'Id',
                            visible: false
                        },
                        {

                            data: 'Name',
                            name: 'Name',
                            title: 'Project name',
                            ""autoWidth"": true
                        },
                        {
                            data: 'Department',
                            name: 'Department',
                            title: 'Department',
                            ""autoWidth"": true

                        },
                        {
                            data: 'User',
                            name: 'User',
                            title: 'Cedacri International responsible user',
          ");
                WriteLiteral(@"                  ""autoWidth"": true
                        },
                        {
                            data: 'Username',
                            name: 'Username',
                            title: 'Cedacri Italia responsible user name',
                        },

                        {
                            data: null,
                            orderable: false,
                            className: 'text-center',
                            render: function (data, type, row) {
                                return ""<a href='");
#nullable restore
#line 193 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\Project\Index.cshtml"
                                            Write(Url.Action("GetEdit","Project"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"/"" + row.Id + ""'class='btn btn-warning projectEdit' title='Edit'><span class='glyphicon glyphicon-pencil'></span></a>"";
                            }
                        },
                        {
                            data: null,
                            orderable: false,
                            className: 'text-center',
                            render: function (data, type, row) {
                                return ""<a href='");
#nullable restore
#line 201 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\Project\Index.cshtml"
                                            Write(Url.Action("GetDetails","Project"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"/"" + row.Id + ""'class='btn btn-info projectInfo' title='Details'><span class='glyphicon glyphicon-info-sign'></span></a>"";
                            }
                        },
                        
                    ],


                    ajax: {
                        url: """);
#nullable restore
#line 209 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\Project\Index.cshtml"
                         Write(Url.Action("GetProjects", "Project", new { httproute = "ActionRoute" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""",
                        type: ""Post""
                    },



                    initComplete: function () {
                        var input = $("".dataTables_filter input"").unbind();
                        var inputVar = $("".dataTables_filter input"");
                        $(""#myTable_filter"").append(inputVar);
                        $(""#myTable_filter label"").remove();
                        self = this.api(),
                            $searchButton = $(""<button class='btn btn-sm btn-default'>"")
                                .text(""Search"")
                                .click(function () {
                                    self.search(input.val()).draw();
                                })
                        $("".dataTables_filter"").append($searchButton);
                    },
                })
            }


                        if (response == '""User""') {

                dataTable = $(""#table"").DataTable({
                    autoWidth: false,
    ");
                WriteLiteral(@"                serverSide: true,

                    
                    language: { search: """" },


                    ""columns"": [
                        {
                            data: 'Id',
                            name: 'Id',
                            visible: false
                        },
                        {

                            data: 'Name',
                            name: 'Name',
                            title: 'Project name',
                            ""autoWidth"": true
                        },
                        {
                            data: 'Department',
                            name: 'Department',
                            title: 'Department',
                            ""autoWidth"": true

                        },
                        {
                            data: 'User',
                            name: 'User',
                            title: 'Cedacri International responsible user',
              ");
                WriteLiteral(@"              ""autoWidth"": true
                        },
                        {
                            data: 'Username',
                            name: 'Username',
                            title: 'Cedacri Italia responsible user name',
                        },

                        
                        {
                            data: null,
                            orderable: false,
                            className: 'text-center',
                            render: function (data, type, row) {
                                return ""<a href='");
#nullable restore
#line 280 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\Project\Index.cshtml"
                                            Write(Url.Action("GetDetails","Project"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"/"" + row.Id + ""'class='btn btn-info projectInfo' title='Details'><span class='glyphicon glyphicon-info-sign'></span></a>"";
                            }
                        },
                      
                    ],


                    ajax: {
                        url: """);
#nullable restore
#line 288 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\Project\Index.cshtml"
                         Write(Url.Action("GetProjects", "Project", new { httproute = "ActionRoute" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""",
                        type: ""Post""
                    },



                    initComplete: function () {
                        var input = $("".dataTables_filter input"").unbind();
                        var inputVar = $("".dataTables_filter input"");
                        $(""#myTable_filter"").append(inputVar);
                        $(""#myTable_filter label"").remove();
                        self = this.api(),
                            $searchButton = $(""<button class='btn btn-sm btn-default'>"")
                                .text(""Search"")
                                .click(function () {
                                    self.search(input.val()).draw();
                                })
                        $("".dataTables_filter"").append($searchButton);
                    },
                })
            }

                    }
                })

            $(document).on('click', '.projectInfo', function (event) {
                event.preventDefault");
                WriteLiteral(@"();

                var myUrlInfo = this.pathname;

                $.ajax(
                    {
                        async: true,
                        url: myUrlInfo,
                        success: function (data) {
                            $("".body"")[0].innerHTML = data;
                            $(""#modal-title"").text(""Project details"");
                            $('#projectModal').modal();

                        }
                    })
            });



            $(document).on('click', '.projectDelete', function (event) {
                event.preventDefault();

                var myUrlInfo = this.pathname;

                $.ajax(
                    {
                        async: true,
                        url: myUrlInfo,
                        success: function (data) {
                            $("".body"")[0].innerHTML = data;
                            $(""#modal-title"").text(""Delete project"");
                            $('#projectModal");
                WriteLiteral(@"').modal();
                        }
                    })
            });


            $(document).on('submit', '#projectDeletePost', function (event) {
                event.preventDefault();
                $.ajax(
                    {
                        url: ""/project/delete"",
                        data: {
                            Id: $(""#Id"").val(),
                        },
                        method: ""Post"",
                        success: function (response) {
                            $(""#projectModal"").modal(""hide"");
                            $('#table').DataTable().ajax.reload();
                        }
                    })
            });

            $(document).on('click', '.projectEdit', function (event) {
                event.preventDefault();
                var myUrlEdit = this.pathname;
                $.ajax(
                    {
                        success: function (data) {
                            window.location.href = my");
                WriteLiteral("UrlEdit;\r\n\r\n                        }\r\n                    })\r\n                })\r\n            });\r\n\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591