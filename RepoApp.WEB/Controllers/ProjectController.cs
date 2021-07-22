using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RepoApp.BLL.Models;
using RepoApp.BLL.Models.AddModels;
using RepoApp.BLL.Models.DeleteModels;
using RepoApp.BLL.Models.DetailModels;
using RepoApp.BLL.Models.EditModels;
using RepoApp.BLL.Repositories;
using RepoApp.Common;
using RepoApp.Common.DataTables;
using RepoApp.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace RepoApp.WEB.Controllers
{

    public class ProjectController : BaseController
    {
        public ProjectController(FirstContext context) : base(context) { }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Add()
        {
            using (ProjectRepository repo = new ProjectRepository(_context))
            {
                var departments = repo.GetDepartments();
                ViewBag.Departments = new SelectList(departments, "Id", "Name");
                var users = repo.GetUsers();
                ViewBag.Users = new SelectList(users, "Id", "UserName");

            }
            return View("Add");
        }


        [HttpPost]
        public JsonResult GetProjects(DataTablesParameters parameters)
        {
            using (ProjectRepository repo = new ProjectRepository(_context))
            {
                var projectList = repo.GetProjects(parameters);
                return CreateDataTablesResult(projectList, parameters);

            }

        }
        [HttpGet]
        public JsonResult GetRole(string name)
        {

            var httpClient = new HttpClient();
            //var response = httpClient.GetStringAsync("https://localhost:44367/api/project/GetRole/" + name).Result;
            var response = "Admin";

            return Json(response);

        }

        [HttpGet]
        public IActionResult GetEdit(Guid id)
        {
            using (ProjectRepository repo = new ProjectRepository(_context))
            {
                var httpClient = new HttpClient();
                var response = httpClient.GetStringAsync("https://localhost:44367/api/project/GetEdit/" + id).Result;
                ProjectViewModelEdit model = JsonConvert.DeserializeObject<ProjectViewModelEdit>(response);

                var departments = repo.GetDepartments();
                ViewBag.Departments = new SelectList(departments, "Id", "Name");
                var users = repo.GetUsers();
                ViewBag.Users = new SelectList(users, "Id", "UserName");

                return View("_Edit", model);
            }
        }
        [HttpGet]
        public IActionResult GetDetails(Guid id)
        {
            try
            {
                var httpClient = new HttpClient();
                var response = httpClient.GetStringAsync("https://localhost:44367/api/project/getdetails/" + id).Result;

                ProjectDetailsModel model = JsonConvert.DeserializeObject<ProjectDetailsModel>(response);

                return PartialView("_Details", model);

            }

            catch (Exception ex)
            {
                return CreateExceptionView(ex);
            }
        }
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            using (ProjectRepository repo = new ProjectRepository(_context))
            {
                var model = repo.GetDelete(id);
                return PartialView("_Delete", model);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(ProjectDetailsModel model)
        {
            using (ProjectRepository repo = new ProjectRepository(_context))
            {
                repo.Delete(model);
            }

            return await CreateJsonResultViewAsync("~/Views/Project/Index.cshtml");

        }

        [HttpPost]
        public async Task<IActionResult> Edit(List<string> projectData)
        {
            HttpResponseMessage postTask = null, postTask1 = null;
            ExecutionResult result = null, result1 = null;
            var succesRepo = false;
            var hasRepos = false;
            var countProject = 0;
            if (projectData.Count <= 5)
            {
                hasRepos = false;
            }
            else
            {
                hasRepos = true;
            }
            try
            {
                Guid projectId = Guid.Parse(projectData[0]);
                string projectName = projectData[1];
                Guid department = Guid.Parse(projectData[2]);
                Guid user = Guid.Parse(projectData[3]);
                string userName = projectData[4];

                var project = new ProjectEditModel
                {
                    Id = projectId,
                    Name = projectName,
                    Department = department,
                    User = user,
                    Username = userName
                };


                foreach (var item in projectData)
                {
                    if (item.Contains('^'))
                    {
                        string[] repoData = item.Split('^');
                        Guid id = Guid.Parse(repoData[0]);
                        string url = repoData[1];
                        int repoNr = Int16.Parse(repoData[2]);
                        var repo = new RepositoryEditModel
                        {
                            URL = url,
                            TypeId = id,
                            Index = repoNr,
                            ProjectId = projectId
                        };

                        using (var client = new HttpClient())
                        {
                            string startUrl = _WebServiceUrl + "/api/project/";
                            client.BaseAddress = new Uri(startUrl);

                            postTask1 = client.PostAsJsonAsync("EditOnlyRepository", repo).Result;
                            result1 = JsonConvert.DeserializeObject<ExecutionResult>(postTask1.Content.ReadAsStringAsync().Result);

                            if (postTask1.IsSuccessStatusCode)
                            {
                                succesRepo = true;
                            }

                        }

                    }
                    else
                    {
                        if (countProject < 1)
                        {
                            using (var client = new HttpClient())
                            {
                                string startUrl = _WebServiceUrl + "/api/project/";
                                client.BaseAddress = new Uri(startUrl);

                                postTask = client.PostAsJsonAsync("EditOnlyProject", project).Result;
                                result = JsonConvert.DeserializeObject<ExecutionResult>(postTask.Content.ReadAsStringAsync().Result);
                            }
                            countProject++;

                        }
                    }

                }

                if (hasRepos && succesRepo && postTask.IsSuccessStatusCode)
                {
                    return await CreateJsonResultViewAsync("~/Views/Project/Index.cshtml");
                }
                if (!hasRepos && postTask.IsSuccessStatusCode)
                {
                    return await CreateJsonResultViewAsync("~/Views/Project/Index.cshtml");
                }

                return await CreateJsonNotValidResultViewAsync("~/Views/Project/_Edit.cshtml");
            }
            catch (Exception ex)
            {
                return CreateExceptionView(ex);
            }
        }

        [HttpPost]
        public IActionResult AddRepository()
        {
            using (ProjectRepository repo = new ProjectRepository(_context))
            {
                string res = repo.GetRepository();
                return Json(res);

            }
        }


        [HttpPost]
        public async Task<IActionResult> DeleteRepository(List<string> info)

        {

            var repo = new RepositoryDeleteModel()
            {
                Id = Guid.Parse(info[1]),
                URL = info[0]
            };
            using (var client = new HttpClient())
            {
                string startUrl = _WebServiceUrl + "/api/project/";
                client.BaseAddress = new Uri(startUrl);

                var postTask1 = client.PostAsJsonAsync("DeleteRepository", repo).Result;

                if (postTask1.IsSuccessStatusCode)
                {
                    return await CreateJsonResultViewAsync("~/Views/Project/Index.cshtml");
                }

            }
            return await CreateJsonNotValidResultViewAsync("~/Views/Project/_Edit.cshtml");

        }

        [HttpPost]
        public async Task<IActionResult> SubmitProject(List<string> projectData)
        {
            HttpResponseMessage postTask = null, postTask1 = null;
            ExecutionResult result = null, result1 = null;
            var succesRepo = false;
            var hasRepos = false;
            var countProject = 0;

            if (projectData.Count <= 4)
            {
                hasRepos = false;
            }
            else
            {
                hasRepos = true;
            }
            try
            {
                string projectName = projectData[0];
                Guid department = Guid.Parse(projectData[1]);
                Guid user = Guid.Parse(projectData[2]);
                string userName = projectData[3];

                var project = new ProjectAddModel
                {
                    Name = projectName,
                    Department = department,
                    User = user,
                    Username = userName
                };


                foreach (var item in projectData)
                {
                    if (item.Contains('^'))
                    {
                        string[] repoData = item.Split('^');
                        Guid id = Guid.Parse(repoData[0]);
                        string url = repoData[1];
                        var repo = new RepositoryAddModel
                        {
                            URL = url,
                            TypeId = id,
                            UserId = user,
                            ProjectName = projectName
                        };

                        using (var client = new HttpClient())
                        {
                            string startUrl = _WebServiceUrl + "/api/project/";
                            client.BaseAddress = new Uri(startUrl);

                            postTask1 = client.PostAsJsonAsync("SubmitOnlyRepository", repo).Result;
                            result1 = JsonConvert.DeserializeObject<ExecutionResult>(postTask1.Content.ReadAsStringAsync().Result);

                            if (postTask1.IsSuccessStatusCode)
                            {
                                succesRepo = true;
                            }

                        }
                    }
                    else
                    {
                        if (countProject < 1)
                        {
                            using (var client = new HttpClient())
                            {
                                string startUrl = _WebServiceUrl + "/api/project/";
                                client.BaseAddress = new Uri(startUrl);

                                postTask = client.PostAsJsonAsync("SubmitOnlyProject", project).Result;
                                result = JsonConvert.DeserializeObject<ExecutionResult>(postTask.Content.ReadAsStringAsync().Result);
                            }
                            countProject++;

                        }
                    }

                }
                if (hasRepos && succesRepo && postTask.IsSuccessStatusCode)
                {
                     return await CreateJsonResultViewAsync("~/Views/Project/Index.cshtml");
                }
                if (!hasRepos && postTask.IsSuccessStatusCode)
                {
                    return await CreateJsonResultViewAsync("~/Views/Project/Index.cshtml");
                }

                return await CreateJsonNotValidResultViewAsync("~/Views/Project/Add.cshtml");

            }
            catch (Exception ex)
            {
                return CreateExceptionView(ex);
            }
        }


        public JsonResult IsProjectNameValid(string name)
        {
            using (ProjectRepository repo = new ProjectRepository(_context))
            {
                var res = repo.CheckProjectName(name);
                return Json(res == false);

            }
        }
        public JsonResult IsProjectNameValidForEdit(string name, Guid id)
        {
            using (ProjectRepository repo = new ProjectRepository(_context))
            {
                var res = repo.CheckProjectNameForEdit(name, id);
                return Json(res == false);

            }
        }



        [HttpGet]
        public string GetAllUserRepositories(Guid id)
        {

            var httpClient = new HttpClient();

            var response = httpClient.GetStringAsync("https://localhost:44367/api/project/GetAllUserRepositories/" + id).Result;


            return response;

        }
    }
}

