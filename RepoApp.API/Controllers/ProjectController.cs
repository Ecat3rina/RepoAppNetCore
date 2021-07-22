using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepoApp.BLL.Models.AddModels;
using RepoApp.BLL.Models.DeleteModels;
using RepoApp.BLL.Models.EditModels;
using RepoApp.BLL.Repositories;
using RepoApp.Common.DataTables;
using RepoApp.DAL.Context;
using System;

namespace RepoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : BaseController
    {
        public ProjectController(FirstContext context) : base(context) { }


        //[Route("GetProjects")]
        [HttpPost]
        public IActionResult GetProjects(DataTablesParameters parameters)
        {
            using (ProjectRepository repo = new ProjectRepository(_context))
            {
                var projectList = repo.GetProjects(parameters);
                return CreateDataTableResult(projectList, parameters);

            }

        }
        [Route("GetRole")]
        [HttpGet]
        public IActionResult GetRole(string name)
        {

            using (UserRepository repo = new UserRepository(_context))
            {
                var details = repo.GetSuperiorRoleName(name);



                return Json(details);
            }
        }
        [Route("SubmitOnlyProject")]

        [HttpPost]
        public IActionResult SubmitOnlyProject(ProjectAddModel model)
        {

            using (ProjectRepository repo = new ProjectRepository(_context))
            {
                repo.AddOnlyProject(model);
            }

            return CreateJsonOk();
        }

        [Route("SubmitOnlyRepository")]
        [HttpPost]
        public IActionResult SubmitOnlyRepository(RepositoryAddModel model)
        {

            using (ProjectRepository repo = new ProjectRepository(_context))
            {
                repo.AddOnlyRepository(model);
            }

            return CreateJsonOk();
        }

        [Route("EditOnlyProject")]
        [HttpPost]
        public IActionResult EditOnlyProject(ProjectEditModel model)
        {

            using (ProjectRepository repo = new ProjectRepository(_context))
            {
                repo.EditOnlyProject(model);
            }

            return CreateJsonOk();
        }

        [Route("EditOnlyRepository")]
        [HttpPost]
        public IActionResult EditOnlyRepository(RepositoryEditModel model)
        {

            using (ProjectRepository repo = new ProjectRepository(_context))
            {
                repo.EditOnlyRepository(model);
            }

            return CreateJsonOk();
        }


        [Route("DeleteRepository")]
        [HttpPost]
        public IActionResult DeleteRepository(RepositoryDeleteModel repoData)
        {
            using (ProjectRepository repo = new ProjectRepository(_context))
            {
                repo.DeleteRepo(repoData);
                return CreateJsonOk();
            }
        }
        [Route("GetDetails")]
        [HttpGet]
        public IActionResult GetDetails(Guid id)
        {
            try
            {
                using (ProjectRepository repo = new ProjectRepository(_context))
                {
                    var details = repo.GetDetails(id);

                    return Json(details);
                }
            }

            catch (Exception ex)
            {
                return CreateExceptionLog(ex);
            }
        }

        [Route("GetAllUserRepositories")]
        [HttpGet]
        public JsonResult GetAllUserRepositories(Guid id)
        {
            using (ProjectRepository repo = new ProjectRepository(_context))
            {
                string res = repo.GetUserRepositories(id);
                return Json(res);

            }
        }


        [Route("AddRepositoryForEdit/{count}")]
        [HttpGet]

        public IActionResult AddRepositoryForEdit(string count)
        {
            using (ProjectRepository repo = new ProjectRepository(_context))
            {
                string res = repo.GetRepository(count);
                return Json(res);

            }
        }

        [Route("GetEdit")]
        [HttpGet]
        public IActionResult GetEdit(Guid id)
        {
            try
            {
                using (ProjectRepository repo = new ProjectRepository(_context))
                {
                    var model = repo.GetEdit(id);

                    return Json(model);
                }
            }

            catch (Exception ex)
            {
                return CreateExceptionLog(ex);
            }
        }
    }
}
