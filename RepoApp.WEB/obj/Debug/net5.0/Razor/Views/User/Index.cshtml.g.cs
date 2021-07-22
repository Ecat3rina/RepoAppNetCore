#pragma checksum "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\User\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "70e1436a1b8bb6498e16c44e93d6e85c78b8cb78"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Index), @"mvc.1.0.view", @"/Views/User/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"70e1436a1b8bb6498e16c44e93d6e85c78b8cb78", @"/Views/User/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4505eb805fbb61849aba5e6bfc78a0241f85f29d", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\User\Index.cshtml"
  
    ViewBag.Title = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<h2>Users</h2>

<div class=""modal fade"" id=""myModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""ModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
                <h3 id=""modal-title""></h3>
            </div>
            <div class=""modal-body"">
                <!-- Modal body -->
            </div>

        </div>
    </div>
</div>


<table id=""myTable"" class=""table table-bordered table-striped"">
</table>

");
#nullable restore
#line 27 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\User\Index.cshtml"
Write(Html.ActionLink("Add user", "Add", "User", new { @class = "btn btn-primary userAdd" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
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
#line 40 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\User\Index.cshtml"
                     Write(Url.Action("GetRole", "User", new { httproute = "ActionRoute" }));

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
                            $(""#myTable"").DataTable({
                                autoWidth: false,
                                serverSide: true,

                                ""columns"": [
                                    {
                                        data: 'Id',
                                        name: 'Id',
                                        visible: false
                                    },
                                    {

                                        data: 'UserName',
                                        name: 'UserName',
                                        title: 'Username',
                                        ""autoWidth"": true
                                    },
             ");
                WriteLiteral(@"                       {
                                        data: 'FullName',
                                        name: 'FullName',
                                        title: 'Full name',
                                        ""autoWidth"": true
                                    },
                                    {
                                        data: 'Email',
                                        name: 'Email',
                                        title: 'E-mail',
                                        ""autoWidth"": true
                                    },
                                    {
                                        data: 'IsConnected',
                                        width: '10px',
                                        title: 'Connection',
                                        className: 'text-center',
                                        render: function (data, type, row) {
                                            if (");
                WriteLiteral(@"!data) return ""<span class='label label-danger '>OFF</span>"";
                                            else return ""<span class='label label-success'>ON</span>"";
                                        }
                                    },

                                    {
                                        data: null,
                                        orderable: false,
                                        className: 'text-center',
                                        render: function (data, type, row) {
                                            return ""<a href='");
#nullable restore
#line 92 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\User\Index.cshtml"
                                                        Write(Url.Action("GetEdit","User"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"/"" + row.Id + ""' class='btn btn-warning userEdit' title='Edit'><span class='glyphicon glyphicon-pencil'></span></a>"";

                                        }
                                    },
                                    {
                                        data: null,
                                        orderable: false,
                                        className: 'text-center',
                                        render: function (data, type, row) {
                                            return ""<a href='");
#nullable restore
#line 101 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\User\Index.cshtml"
                                                        Write(Url.Action("GetDetails", "User", new { httproute = "ActionRoute" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("/\" + row.Id + \"\' class=\'btn btn-info userInfo\' title=\'Details\'><span class=\'glyphicon glyphicon-info-sign\'></span></a>\";\r\n                                        }\r\n                                    },\r\n");
                WriteLiteral("                                ],\r\n\r\n                                ajax: {\r\n                                    url: \"");
#nullable restore
#line 115 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\User\Index.cshtml"
                                     Write(Url.Action("GetUsers", "User", new { httproute = "ActionRoute" }));

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
                                }
                 ");
                WriteLiteral(@"           })
                        }
                         if (response == 'Operator') {

                            $('.userAdd').hide();

                            $(""#myTable"").DataTable({

                                autoWidth: false,
                                serverSide: true,

                                ""columns"": [
                                    {
                                        data: 'Id',
                                        name: 'Id',
                                        visible: false
                                    },
                                    {

                                        data: 'UserName',
                                        name: 'UserName',
                                        title: 'Username',
                                        ""autoWidth"": true
                                    },
                                    {
                                        data: 'FullName',
       ");
                WriteLiteral(@"                                 name: 'FullName',
                                        title: 'Full name',
                                        ""autoWidth"": true
                                    },
                                    {
                                        data: 'Email',
                                        name: 'Email',
                                        title: 'E-mail',
                                        ""autoWidth"": true
                                    },
                                    {
                                        data: 'IsConnected',
                                        width: '5%',
                                        title: 'Connection',
                                        className: 'text-center',
                                        render: function (data, type, row) {
                                            if (!data) return ""<span class='label label-danger '>OFF</span>"";
                               ");
                WriteLiteral(@"             else return ""<span class='label label-success'>ON</span>"";
                                        }
                                    },

                                    {
                                        data: null,
                                        orderable: false,
                                        className: 'text-center',
                                        render: function (data, type, row) {
                                            return ""<a href='");
#nullable restore
#line 183 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\User\Index.cshtml"
                                                        Write(Url.Action("GetEdit","User"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"/"" + row.Id + ""' class='btn btn-warning userEdit' title='Edit'><span class='glyphicon glyphicon-pencil'></span></a>"";
                                        }
                                    },
                                    {
                                        data: null,
                                        orderable: false,
                                        className: 'text-center',
                                        render: function (data, type, row) {
                                            return ""<a href='");
#nullable restore
#line 191 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\User\Index.cshtml"
                                                        Write(Url.Action("GetDetails","User"));

#line default
#line hidden
#nullable disable
                WriteLiteral("/\" + row.Id + \"\' class=\'btn btn-info userInfo\' title=\'Details\'><span class=\'glyphicon glyphicon-info-sign\'></span></a>\";\r\n                                        }\r\n                                    },\r\n");
                WriteLiteral("                                ],\r\n\r\n                                 ajax: {\r\n                                    url: \"");
#nullable restore
#line 205 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\User\Index.cshtml"
                                     Write(Url.Action("GetUsers", "User", new { httproute = "ActionRoute" }));

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
                                }
               ");
                WriteLiteral(@"             })
                        }

                        if (response == 'User') {

                            $('.userAdd').hide();

                            $(""#myTable"").DataTable({

                                autoWidth: false,
                                serverSide: true,

                                ""columns"": [
                                    {
                                        data: 'Id',
                                        name: 'Id',
                                        visible: false
                                    },
                                    {

                                        data: 'UserName',
                                        name: 'UserName',
                                        title: 'Username',
                                        ""autoWidth"": true
                                    },
                                    {
                                        data: 'FullName',
        ");
                WriteLiteral(@"                                name: 'FullName',
                                        title: 'Full name',
                                        ""autoWidth"": true
                                    },
                                    {
                                        data: 'Email',
                                        name: 'Email',
                                        title: 'E-mail',
                                        ""autoWidth"": true
                                    },
                                    {
                                        data: 'IsConnected',
                                        width: '5%',
                                        title: 'Connection',
                                        className: 'text-center',
                                        render: function (data, type, row) {
                                            if (!data) return ""<span class='label label-danger '>OFF</span>"";
                                ");
                WriteLiteral("            else return \"<span class=\'label label-success\'>ON</span>\";\r\n                                        }\r\n                                    },\r\n\r\n");
                WriteLiteral(@"                                    {
                                        data: null,
                                        orderable: false,
                                        className: 'text-center',
                                        render: function (data, type, row) {
                                            return ""<a href='");
#nullable restore
#line 283 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\User\Index.cshtml"
                                                        Write(Url.Action("GetDetails","User"));

#line default
#line hidden
#nullable disable
                WriteLiteral("/\" + row.Id + \"\' class=\'btn btn-info userInfo\' title=\'Details\'><span class=\'glyphicon glyphicon-info-sign\'></span></a>\";\r\n                                        }\r\n                                    },\r\n");
                WriteLiteral("                                ],\r\n\r\n                                 ajax: {\r\n                                    url: \"");
#nullable restore
#line 297 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\User\Index.cshtml"
                                     Write(Url.Action("GetUsers", "User", new { httproute = "ActionRoute" }));

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
                                }
                 ");
                WriteLiteral(@"           })
                        }
                    }
                })



            var validationResult = {
                Valid: ""Valid"",
                UnValid: ""UnValid""
            }

            $(document).on('submit', '#userAddPost', function (event) {
                event.preventDefault();

                $('#userAddPost')
                    .removeData(""validator"") /* added by the raw jquery.validate plugin */
                    .removeData(""unobtrusiveValidation"");  /* added by the jquery unobtrusive plugin*/

                $.validator.unobtrusive.parse('#userAddPost');

                if ($(""#userAddPost"").valid()) {

                    //var userObj =
                    //{
                    //    UserName: $(""#UserName"").val(),
                    //    Password: $(""#Password"").val(),
                    //    Email: $(""#Email"").val(),
                    //    Fullname: $(""#FullName"").val(),
                    //    Roles: $(""#Roles"").val()");
                WriteLiteral(@"
                    //};

                    var userObj = $(""form"").serializeArray();

                    var logout = $(""a[href$='Account/LogOut']"").text();
                    var loggedUsername = logout.replace('Exit ', '');

                    var data = new FormData();

                    data.append(""userData[]"", $(""#UserName"").val())
                    data.append(""userData[]"", $(""#Password"").val())
                    data.append(""userData[]"", $(""#Email"").val())
                    data.append(""userData[]"", $(""#FullName"").val())
                    data.append(""userData[]"", $(""#Roles"").val())


                    $.ajax(
                        {
                            url: """);
#nullable restore
#line 361 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\User\Index.cshtml"
                             Write(Url.Action("Add", "User", new { httproute = "ActionRoute" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""",
                            data: userObj,
                            method: ""Post"",
                            dataType: 'json',
                            success: function (response) {
                               // if (response.viewPage) {
                                  //if (response.validationResult === validationResult.Valid) {
                                if (response.ExecutionStatus == 0) {
                                        $(""#myModal"").modal(""hide"");
                                        $('#myTable').DataTable().ajax.reload();
                                    }

                                // if (response.validationResult === validationResult.UnValid) {
                                if (response.ExecutionStatus == 5) {

                                        $("".modal-body"").html(response.viewPage);
                                        $('select').selectpicker();
                                        $(""#userAddPost"").validate().showErrors({");
                WriteLiteral(@"
                                            ""UserName"": response.ValidationMessages.UserName,
                                            ""Email"": response.ValidationMessages.Email
                                        })

                                    }

                               // }
                            }

                        })
                }
            });


            $(document).on('click', '.userAdd', function (event) {
                event.preventDefault();
                var myUrlAdd = this.pathname;

                    $.ajax(
                        {
                            async: true,
                            url: myUrlAdd,
                            success: function (data) {
                                $("".modal-body"")[0].innerHTML = data;
                                $(""#modal-title"").text(""Add user"");
                                $('#myModal').modal();
                                $('select').selectpicker();

");
                WriteLiteral(@"                            }
                        })

            })

            $(document).on('click', '.userInfo', function (event) {
                event.preventDefault();

                var url = this.pathname;
                var id = url.substring(url.lastIndexOf('/') + 1);

                $.ajax(
                    {
                        async: true,
                        method: ""Get"",
                        url: ""https://localhost:44367/api/User/GetDetails/"" + id,
                        success: function (data) {
                            $.ajax({
                                url: """);
#nullable restore
#line 425 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\User\Index.cshtml"
                                 Write(Url.Action("GetDetails", "User"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""",
                                data: data,
                                method: ""Get"",
                                success: function (data) {
                                    $("".modal-body"")[0].innerHTML = data;
                                    $(""#modal-title"").text(""User details"");
                                    $('#myModal').modal();
                                }
                            })

                        }
                    })
            });

            $(document).on('click', '.userDelete', function (event) {
                event.preventDefault();

                var myUrlInfo = this.pathname;

                $.ajax(
                    {
                        async: true,
                        url: myUrlInfo,
                        success: function (data) {
                            $("".modal-body"")[0].innerHTML = data;
                            $(""#modal-title"").text(""Delete user"");
                            $('#myModa");
                WriteLiteral(@"l').modal();
                        }
                    })
            });


            $(document).on('submit', '#userDeletePost', function (event) {
                event.preventDefault();
                $.ajax(
                    {
                        url: ""/user/delete"",
                        data: {
                            Id: $(""#Id"").val(),
                        },
                        method: ""Post"",
                        success: function (response) {
                            $(""#myModal"").modal(""hide"");
                            $('#myTable').DataTable().ajax.reload();
                        }
                    })
            });

            $(document).on('click', '.userEdit', function (event) {
                event.preventDefault();

                var url = this.pathname;
                var id = url.substring(url.lastIndexOf('/') + 1);
                $.ajax(
                    {
                        async: true,
               ");
                WriteLiteral("         method: \"Get\",\r\n                        url: \"https://localhost:44367/api/User/GetEdit/\"+id,\r\n\r\n                        success: function (data) {\r\n                            $.ajax({\r\n                                url: \"");
#nullable restore
#line 486 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\User\Index.cshtml"
                                 Write(Url.Action("GetEdit", "User"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""",
                                    data: data,
                                    method: ""Get"",
                                    success: function (data) {
                                        $("".modal-body"")[0].innerHTML = data;
                                        $(""#modal-title"").text(""Edit user"");
                                        $('#myModal').modal();
                                        $('select').selectpicker();


                                        if ($(""#IsChangePassword"").is("":checked"")) {
                                            $(""#ConfirmPassword"").prop(""disabled"", false);
                                            $(""#Password"").prop(""disabled"", false);
                                        }
                                        else {
                                            $(""#ConfirmPassword"").prop(""disabled"", true);
                                            $(""#Password"").prop(""disabled"", true);
                                ");
                WriteLiteral(@"        }

                                        $(""#IsChangePassword"").on(""change"", function (e) {
                                            if ($(this).is("":checked"")) {
                                                $(""#ConfirmPassword"").prop(""disabled"", false);
                                                $(""#Password"").prop(""disabled"", false);
                                            }
                                            else {
                                                $(""#ConfirmPassword"").prop(""disabled"", true);
                                                $(""#Password"").prop(""disabled"", true);
                                            }
                                        })


                                        $("".disable"").css({ 'opacity': '1' });

                                        if ($(""#IsChangeRoles"").is(':checked'))
                                            $('#Roles').attr('disabled', false);
                                     ");
                WriteLiteral(@"   else {
                                            $('#Roles').attr(""disabled"", true);
                                        }



                                        $('#IsChangeRoles').change(function () {
                                            if ($(this).is(':checked'))
                                                $('#Roles').attr('disabled', false);
                                            else
                                                $('#Roles').attr(""disabled"", true);
                                        })
                                    }

                            })
                        }
                    })

            });

            $(document).on('submit', '#userEditPost', function (event) {
                event.preventDefault();

                $('#userEditPost')
                    .removeData(""validator"") /* added by the raw jquery.validate plugin */
                    .removeData(""unobtrusiveValidation"");  /* added by th");
                WriteLiteral(@"e jquery unobtrusive plugin*/

                $.validator.unobtrusive.parse('#userEditPost');

                if ($(""#userEditPost"").valid()) {

                    var userObj = $(""form"").serializeArray();


                    var logout = $(""a[href$='Account/LogOut']"").text();
                    var loggedUsername = logout.replace('Exit ', '');


                    var logout = $(""a[href$='Account/LogOut']"").text();
                    var loggedUsername = logout.replace('Exit ', '');

                    var data = new FormData();
                    var password = false;
                    var roles = false;
                    var connection = false;

                    if ($(""#IsChangePassword"").is(':checked'))
                        password = true;
                    if ($(""#IsChangeRoles"").is(':checked'))
                        roles = true;
                    if ($(""#ChangeConnection"").is(':checked'))
                        connection = true;

                ");
                WriteLiteral(@"    data.append(""userData[]"", loggedUsername)
                    data.append(""userData[]"", $(""#UserName"").val())
                    data.append(""userData[]"", $(""#Password"").val())
                    data.append(""userData[]"", $(""#Email"").val())
                    data.append(""userData[]"", $(""#FullName"").val())
                    data.append(""userData[]"", $(""#Roles"").val())
                    data.append(""userData[]"", $(""#Id"").val())
                    data.append(""userData[]"", password)
                    data.append(""userData[]"", roles)
                    data.append(""userData[]"", $(""#ConfirmPassword"").val())
                    data.append(""userData[]"", connection)


                    $.ajax(
                        {
                            url: """);
#nullable restore
#line 589 "C:\Users\crm0261\source\repos\NETCore\RepoApp\RepoApp.WEB\Views\User\Index.cshtml"
                             Write(Url.Action("Edit", "User", new { httproute = "ActionRoute" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""",
                            data: userObj,
                            method: ""Post"",

                            success: function (response) {

                                //if (response.viewPage) {

                                    //if (response.validationResult === validationResult.Valid) {
                                    if (response.ExecutionStatus == 0) {
                                        $(""#myModal"").modal(""hide"");
                                        $('#myTable').DataTable().ajax.reload();
                                    }

                                    //if (response.validationResult === validationResult.UnValid) {
                                    if (response.ExecutionStatus == 5) {


                                        $("".modal-body"").html(response.viewPage);
                                        $('select').selectpicker();
                                        $(""#userEditPost"").validate().showErrors({
                        ");
                WriteLiteral(@"                    ""UserName"": response.ValidationMessages.UserName,
                                            ""Email"": response.ValidationMessages.Email,
                                            ""ConfirmPassword"": response.ValidationMessages.ConfirmPassword,
                                            ""IsChangeRoles"": response.ValidationMessages.IsChangeRoles,
                                            ""Password"": response.ValidationMessages.Password

                                        })
                                        if ($(""#IsChangePassword"").is("":checked"")) {
                                            $(""#ConfirmPassword"").prop(""disabled"", false);
                                            $(""#Password"").prop(""disabled"", false);
                                        }
                                        else {
                                            $(""#ConfirmPassword"").prop(""disabled"", true);
                                            $(""#Password"").prop(""");
                WriteLiteral(@"disabled"", true);
                                        }

                                        $(""#IsChangePassword"").on(""change"", function (e) {
                                            if ($(this).is("":checked"")) {
                                                $(""#ConfirmPassword"").prop(""disabled"", false);
                                                $(""#Password"").prop(""disabled"", false);
                                            }
                                            else {
                                                $(""#ConfirmPassword"").prop(""disabled"", true);
                                                $(""#Password"").prop(""disabled"", true);
                                            }
                                        })

                                        if ($(""#IsChangeRoles"").is(':checked'))
                                            $('#Roles').attr('disabled', false);

                                        else
                      ");
                WriteLiteral(@"                      $('#Roles').attr(""disabled"", true);



                                        $('#IsChangeRoles').change(function () {
                                            if ($(this).is(':checked')) {
                                                $('#Roles').attr('disabled', false);
                                                $('.disabled').css('color', 'black');
                                            }

                                            else
                                                $('#Roles').attr(""disabled"", true);
                                        })


                                    }
                               // }


                            }
                        })
                }
            })
        });

    </script>
");
            }
            );
            WriteLiteral("\r\n");
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
