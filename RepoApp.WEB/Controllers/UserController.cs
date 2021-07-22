using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RepoApp.BLL.Models.AddModels;
using RepoApp.BLL.Models.DetailModels;
using RepoApp.BLL.Models.EditModels;
using RepoApp.BLL.Repositories;
using RepoApp.Common;
using RepoApp.Common.DataTables;
using RepoApp.DAL.Context;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace RepoApp.WEB.Controllers
{
    public class UserController : BaseController
    {
        public UserController(FirstContext context) : base(context) { }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetUsers(DataTablesParameters parameters)
        {
            using (UserRepository repo = new UserRepository(_context))
            {
                var userList = repo.GetUsers(parameters);
                return CreateDataTablesResult(userList, parameters);

            }

        }

        [HttpGet]
        public IActionResult Add()
        {

            using (UserRepository repo = new UserRepository(_context))
            {
                var roles = repo.GetRoles();
                ViewBag.Roles = new MultiSelectList(roles, "Id", "Name");
            }
            return PartialView("_Add");
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserAddModel model)
        {
            try
            {
                using (UserRepository repo = new UserRepository(_context))
                {
                    var roles = repo.GetRoles();
                    ViewBag.Roles = new MultiSelectList(roles, "Id", "Name");
                }
                using (UserRepository repo = new UserRepository(_context))
                {

                    if (ModelState.IsValid)
                    {
                        using (var client = new HttpClient())
                        {
                            string startUrl = _WebServiceUrl + "/api/user/";
                            client.BaseAddress = new Uri(startUrl);

                            var postTask = client.PostAsJsonAsync("Add", model).Result;
                            var result = JsonConvert.DeserializeObject<ExecutionResult>(postTask.Content.ReadAsStringAsync().Result);

                            if (postTask.IsSuccessStatusCode)
                            {
                                return await CreateJsonResultViewAsync("~/Views/User/Index.cshtml");
                            }

                            foreach (var a in result.ValidationMessages)
                            {
                                ModelState.AddModelError(a.Key, a.Value);
                            }
                        }
                    }
                }

                return await CreateJsonNotValidResultViewAsync("~/Views/User/_Add.cshtml", model);
            }
            catch (Exception ex)
            {
                return CreateExceptionView(ex);
            }

        }


        [HttpGet]
        public IActionResult GetEdit(Guid id)
        {
            using (UserRepository repo = new UserRepository(_context))
            {
                var roles = repo.GetRoles();
                var model = repo.GetEdit(id);
                ViewBag.Roles = new MultiSelectList(roles, "Id", "Name");
                return PartialView("_Edit", model);
            }
        }
       

        [HttpPost]
        public async Task<IActionResult> Edit(UserEditModel model)
        {

            try
            {
                using (UserRepository repo = new UserRepository(_context))
                {
                    var roles = repo.GetRoles();
                    ViewBag.Roles = new MultiSelectList(roles, "Id", "Name");
                }


                if (ModelState.IsValid)
                {
                    using (var client = new HttpClient())
                    {
                        string startUrl = _WebServiceUrl + "/api/user/";
                        client.BaseAddress = new Uri(startUrl);

                        var postTask = client.PostAsJsonAsync("Edit", model).Result;
                        var result = JsonConvert.DeserializeObject<ExecutionResult>(postTask.Content.ReadAsStringAsync().Result);

                        if (postTask.IsSuccessStatusCode)
                        {
                            return await CreateJsonResultViewAsync("~/Views/User/Index.cshtml");
                        }

                        foreach (var a in result.ValidationMessages)
                        {
                            ModelState.AddModelError(a.Key, a.Value);
                        }
                    }

                }
                return await CreateJsonNotValidResultViewAsync("~/Views/User/_Edit.cshtml", model);
            }

            catch (Exception ex)
            {
                return CreateExceptionView(ex);
            }

        }



        [HttpGet]
        public IActionResult GetDetails(Guid id)
        {
            using (UserRepository repo = new UserRepository(_context))
            {
                var userDetails = repo.GetDetails(id);
                return PartialView("_Details", userDetails);
            }
        }

       

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            using (UserRepository repo = new UserRepository(_context))
            {
                var model = repo.GetDelete(id);
                return PartialView("_Delete", model);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(UserDetailsModel model)
        {
            using (UserRepository repo = new UserRepository(_context))
            {
                repo.Delete(model);
            }
            return await CreateJsonResultViewAsync("~/Views/User/Index.cshtml");

        }
        

    }
}
