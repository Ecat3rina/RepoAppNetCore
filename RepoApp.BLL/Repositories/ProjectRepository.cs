using RepoApp.BLL.Models;
using RepoApp.BLL.Models.AddModels;
using RepoApp.BLL.Models.DetailModels;
using RepoApp.BLL.Models.EditModels;
using RepoApp.DAL.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepoApp.Common.DataTables;
using RepoApp.BLL.Models.DeleteModels;
using Microsoft.EntityFrameworkCore;
using RepoApp.DAL.Context;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RepoApp.BLL.Repositories
{
    public class ProjectRepository : BaseRepository
    {

        public ProjectRepository(FirstContext context) : base(context) { }
        public string GetFirstDepartment(Guid id)
        {
            var depId = _context.Projects.FirstOrDefault(x => x.Id == id).DepartmentId;
            var name = _context.Departments.FirstOrDefault(x => x.Id == depId).Name;
            return name;
        }
        public List<SelectListItem> GetDepartments()
        {

            var list = _context.Departments.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            return list;
        }
        public List<SelectListItem> GetUsers()
        {

            var list = _context.Users.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.UserName
            }).ToList();

            return list;
        }

        public List<ProjectGridModel> GetProjects(DataTablesParameters parameters)
        {

            var projects = _context.Projects.Select(u => new ProjectGridModel
            {
                Id = u.Id,
                Name = u.Name,
                Department = _context.Departments.FirstOrDefault(x => x.Id == u.DepartmentId).Name,
                User = _context.Users.FirstOrDefault(x => x.Id == u.UserId).UserName,
                Username = u.UserName,
            });

            if (!string.IsNullOrEmpty(parameters.Search.Value))
            {
                projects = projects.Where(x => x.Name.Contains(parameters.Search.Value) ||
                x.Department.Contains(parameters.Search.Value) ||
                x.User.Contains(parameters.Search.Value) ||
                x.Username.Contains(parameters.Search.Value));
            }


            return projects.OrderBy(parameters).Page(parameters).ToList();


        }



        public ProjectDetailsModel GetDetails(Guid id)
        {

            var projectDetails = _context.Projects.Select(u => new ProjectDetailsModel
            {
                Id = u.Id,
                Name = u.Name,
                Department = _context.Departments.FirstOrDefault(x => x.Id == u.DepartmentId).Name,
                User = _context.Users.FirstOrDefault(x => x.Id == u.UserId).UserName,
                Username = u.UserName,
                Repositories = _context.Repositories.Where(x => x.ProjectId == id).
                Select(n => _context.RepositoryTypes.FirstOrDefault(x => x.RepositoryTypeId == n.TypeId).RepositoryTypeName + " : " + n.URL).ToList()
            }).FirstOrDefault(x => x.Id == id);

            return projectDetails;

        }

        public ProjectDetailsModel GetDelete(Guid id)
        {
            var project = _context.Projects.Select(u => new ProjectDetailsModel
            {
                Id = u.Id,
                Name = u.Name,
                Department = _context.Departments.FirstOrDefault(x => x.Id == u.DepartmentId).Name,
                User = _context.Users.FirstOrDefault(x => x.Id == u.UserId).UserName,
                Username = u.UserName,
                Repositories = _context.Repositories.Where(x => x.ProjectId == id).
                Select(n => _context.RepositoryTypes.FirstOrDefault(x => x.RepositoryTypeId == n.TypeId).RepositoryTypeName + " : " + n.URL).ToList()
            }).FirstOrDefault(x => x.Id == id);

            return project;
        }
        public void Delete(ProjectDetailsModel model)
        {
            var projectToDelete = _context.Projects.FirstOrDefault(x => x.Id == model.Id);

            _context.Projects.Remove(projectToDelete);

            var repoList = _context.Repositories.Where(x => x.ProjectId == model.Id).ToList();
            _context.Repositories.RemoveRange(repoList);
            _context.SaveChanges();
        }

        public ProjectViewModelEdit GetEdit(Guid id)
        {
            var project = _context.Projects.Select(u => new ProjectViewModelEdit
            {
                Id = u.Id,
                Name = u.Name,
                Username = u.UserName,
                DepartmentId = u.DepartmentId,
                UserId = u.UserId
            }).FirstOrDefault(x => x.Id == id);

            return project;
        }


        public void EditOnlyProject(ProjectEditModel model)
        {
            var projectModel = _context.Projects.FirstOrDefault(x => x.Id == model.Id);

            projectModel.Name = model.Name;
            projectModel.DepartmentId = model.Department;
            projectModel.UserId = model.User;
            projectModel.UserName = model.Username;

            _context.Entry(projectModel).State = EntityState.Modified;
            _context.SaveChanges();

        }
        public void EditOnlyRepository(RepositoryEditModel model)
        {
            var repoList = _context.Repositories.Where(x => x.ProjectId == model.ProjectId).ToArray();
            var repoModel = new DMRepository();
            var prevIndex = -1;

            if (repoList.Length == 0)
            {
                var newRepo = new DMRepository()
                {
                    Id = Guid.NewGuid(),
                    URL = model.URL,
                    TypeId = model.TypeId,
                    UserId = _context.Projects.FirstOrDefault(x => x.Id == model.ProjectId).UserId,
                    ProjectId = model.ProjectId
                };
                _context.Repositories.Add(newRepo);
            }
            else
            {

                for (int i = 0; i < repoList.Length; i++)
                {
                    if (model.Index == i)
                    {
                        repoList[i].URL = model.URL;
                        repoList[i].TypeId = model.TypeId;
                        repoList[i].ProjectId = model.ProjectId;
                        _context.Entry(repoList[i]).State = EntityState.Modified;

                    }
                    else
                    {
                        if (model.Index >= repoList.Length && model.Index > prevIndex)
                        {
                            prevIndex = model.Index;

                            var newRepo = new DMRepository()
                            {
                                Id = Guid.NewGuid(),
                                URL = model.URL,
                                TypeId = model.TypeId,
                                UserId = _context.Projects.FirstOrDefault(x => x.Id == model.ProjectId).UserId,
                                ProjectId = model.ProjectId
                            };
                            _context.Repositories.Add(newRepo);
                        }
                    }

                }
            }
            _context.SaveChanges();

        }



        public void Edit(ArrayList arrayList, Guid id)
        {
            var projectModel = _context.Projects.FirstOrDefault(x => x.Id == id);

            foreach (var item in arrayList)
            {
                if (item.GetType() == typeof(ProjectEditModel))
                {
                    ProjectEditModel project = (ProjectEditModel)item;
                    projectModel.Name = project.Name;
                    projectModel.DepartmentId = project.Department;
                    projectModel.UserId = project.User;
                    projectModel.UserName = project.Username;

                    this.EditRepository(arrayList, id, project);
                }

            }
            _context.Entry(projectModel).State = EntityState.Modified;

            _context.SaveChanges();
        }
        public void EditRepository(ArrayList model, Guid id, ProjectEditModel project)
        {
            var repoList = _context.Repositories.Where(x => x.ProjectId == id).ToArray();
            var repoModel = new DMRepository();
            var prevIndex = -1;
            foreach (var item in model)
            {
                if (item.GetType() == typeof(RepositoryEditModel))
                {
                    RepositoryEditModel repository = (RepositoryEditModel)item;

                    if (repoList.Length == 0)
                    {
                        var newRepo = new DMRepository()
                        {
                            Id = Guid.NewGuid(),
                            URL = repository.URL,
                            TypeId = repository.TypeId,
                            UserId = project.User,
                            ProjectId = id
                        };
                        _context.Repositories.Add(newRepo);
                    }
                    else
                    {

                        for (int i = 0; i < repoList.Length; i++)
                        {
                            if (repository.Index == i)
                            {
                                repoList[i].URL = repository.URL;
                                repoList[i].TypeId = repository.TypeId;
                                _context.Entry(repoList[i]).State = EntityState.Modified;

                            }
                            else
                            {
                                if (repository.Index >= repoList.Length && repository.Index > prevIndex)
                                {
                                    prevIndex = repository.Index;

                                    var newRepo = new DMRepository()
                                    {
                                        Id = Guid.NewGuid(),
                                        URL = repository.URL,
                                        TypeId = repository.TypeId,
                                        UserId = project.User,
                                        ProjectId = id
                                    };
                                    _context.Repositories.Add(newRepo);
                                }
                            }

                        }
                    }
                }
            }


        }



        public string GetUserRepositories(Guid id)
        {
            var repolist = _context.Repositories.Where(x => x.ProjectId == id).Select(x => x.URL).ToArray();

            var list = _context.RepositoryTypes.Select(x => new RepositoryModel
            {
                RepositoryTypeId = x.RepositoryTypeId,
                RepositoryTypeName = x.RepositoryTypeName
            }).ToList();

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < repolist.Length; i++)
            {
                stringBuilder.Append(@"<div class='pb-10 repoClass' id='repoId'><div class='row'>
                        <div class='col-sm-9'>
                        <label>URL</label>

                        <input name='name" + i + "' type ='text' value='" + repolist[i] + @"' class='form-control url' />
                       <span class='spanClass' id='" + i + @"'></span>
                        </div>
                        <div class='col-sm-2'>

                        <label>Type</label>
                            <select id='select" + i + "' class='repository-selectpicker form-control form-control-sm selectpicker selectpicker-border show-tick'> "
                        + GetOptionRepositoryTypeSelected(list, repolist[i]) + @"
                            </select>
                            </div>
                        <div class='col-sm-1'>
                            <label>Remove</label>
                            <button class='btn btn-danger remove' type='button' id='" + i + @"'><i class='fa fa-minus-circle' aria-hidden='true'></i></button>
                        </div>
                        </div></div>");


            }

            return stringBuilder.ToString();
        }


        public string GetRepository()
        {

            var list = _context.RepositoryTypes.Select(x => new RepositoryModel
            {
                RepositoryTypeId = x.RepositoryTypeId,
                RepositoryTypeName = x.RepositoryTypeName
            }).ToList();

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(@"<div class='pb-10 repoClass' id='repoId'><div class='row'>
                    <div class='col-sm-9'>
                    <label>URL</label>
                    
                    <input name='name0' type ='text' class='form-control url' />
                   <span class='spanClass' id='0'></span>
                   
                    </div>
                    <div class='col-sm-2'>
                    
                    <label>Type</label>
                        <select class='repository-selectpicker form-control form-control-sm selectpicker selectpicker-border show-tick'> " + GetOptionRepositoryType(list) + @"
                        </select>
                        </div>
                    <div class='col-sm-1'>
                            <label>Remove</label>
                        
                        <button class='btn btn-danger remove' type='button' id='removeButton'><i class='fa fa-minus-circle' aria-hidden='true'></i></button>

                    </div>
                    </div>");

            return stringBuilder.ToString();
        }

        public string GetRepository(string id)
        {

            var list = _context.RepositoryTypes.Select(x => new RepositoryModel
            {
                RepositoryTypeId = x.RepositoryTypeId,
                RepositoryTypeName = x.RepositoryTypeName
            }).ToList();

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(@"<div class='pb-10 repoClass' id='repoId'><div class='row'>
                    <div class='col-sm-9'>
                    <label>URL</label>
                    
                    <input name='name" + id + @"' type ='text' class='form-control url' />
                   <span class='spanClass' id='" + id + @"'></span>
                   
                    </div>
                    <div class='col-sm-2'>
                    
                    <label>Type</label>
                        <select class='repository-selectpicker form-control form-control-sm selectpicker selectpicker-border show-tick'> " + GetOptionRepositoryType(list) + @"
                        </select>
                        </div>
                    <div class='col-sm-1'>
                        <label>Remove</label>
                        <button class='btn btn-danger remove' type='button' id='" + id + @"'><i class='fa fa-minus-circle' aria-hidden='true'></i></button>
                    </div>
                    </div>");

            return stringBuilder.ToString();
        }

        public string GetOptionRepositoryType(ICollection<RepositoryModel> repositoryModels)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var item in repositoryModels)
            {
                stringBuilder.Append("<option id=" + item.RepositoryTypeId + ">" + item.RepositoryTypeName + "</option>");
            }
            return stringBuilder.ToString();
        }

        public string GetOptionRepositoryTypeSelected(ICollection<RepositoryModel> repositoryModels, string url)
        {
            var typeId = _context.Repositories.FirstOrDefault(x => x.URL == url).TypeId;

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var item in repositoryModels)
            {
                if (item.RepositoryTypeId == typeId)
                {
                    stringBuilder.Append("<option value=" + item.RepositoryTypeId + " id =" + item.RepositoryTypeId + " selected>" + item.RepositoryTypeName + "</option>");
                }
                else
                {
                    stringBuilder.Append("<option id =" + item.RepositoryTypeId + ">" + item.RepositoryTypeName + "</option>");

                }
            }
            return stringBuilder.ToString();
        }


        public bool CheckProjectName(string projectName)
        {
            var projectNameExists = _context.Projects.Any(x => x.Name == projectName);

            if (projectNameExists)
                return true;
            else
                return false;
        }

        public bool CheckProjectNameForEdit(string projectName, Guid id)
        {
            var projectList = _context.Projects.Where(x => x.Name == projectName).ToList();

            foreach (var item in projectList)
            {
                if (item.Id == id)
                    return false;
                else
                    return true;
            }
            return false;

        }
        public void AddOnlyProject(ProjectAddModel model)
        {
            DMProject projectModel = new DMProject()
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                DepartmentId = model.Department,
                UserId = model.User,
                UserName = model.Username
            };

            _context.Projects.Add(projectModel);
            _context.SaveChanges();

        }
        public void AddOnlyRepository(RepositoryAddModel model)
        {

            var repoModel = new DMRepository()
            {
                Id = Guid.NewGuid(),
                URL = model.URL,
                TypeId = model.TypeId,
                UserId = model.UserId,
                ProjectId = _context.Projects.FirstOrDefault(x => x.Name == model.ProjectName).Id
            };

            _context.Repositories.Add(repoModel);
            _context.SaveChanges();

        }



        public void AddProject(ArrayList model)
        {
            DMProject projectModel = new DMProject();

            foreach (var item in model)
            {
                if (item.GetType() == typeof(ProjectAddModel))
                {
                    ProjectAddModel project = (ProjectAddModel)item;
                    projectModel = new DMProject()
                    {
                        Id = Guid.NewGuid(),
                        Name = project.Name,
                        DepartmentId = project.Department,
                        UserId = project.User,
                        UserName = project.Username
                    };

                    this.AddRepositories(model, projectModel);
                }

            }
            _context.Projects.Add(projectModel);
            _context.SaveChanges();


        }

        public void AddRepositories(ArrayList model, DMProject project)
        {
            foreach (var item in model)
            {
                if (item.GetType() == typeof(RepositoryAddModel))
                {
                    RepositoryAddModel repository = (RepositoryAddModel)item;
                    var repoModel = new DMRepository()
                    {
                        Id = Guid.NewGuid(),
                        URL = repository.URL,
                        TypeId = repository.TypeId,
                        UserId = project.UserId,
                        ProjectId = project.Id
                    };

                    _context.Repositories.Add(repoModel);

                }
            }
        }


        public void DeleteRepo(RepositoryDeleteModel info)
        {
            string url = info.URL;
            Guid id = info.Id;

            if (_context.Repositories.Any(x => x.URL == url && x.TypeId == id))
            {
                var repoToDelete = _context.Repositories.FirstOrDefault(x => x.URL == url && x.TypeId == id);
                _context.Repositories.Remove(repoToDelete);
                _context.SaveChanges();
            }


        }

    }
}
