using Microsoft.AspNetCore.Mvc;
using RepoApp.BLL.Models.AddModels;
using RepoApp.BLL.Models.EditModels;
using RepoApp.BLL.Repositories;
using RepoApp.Common.DataTables;
using RepoApp.DAL.Context;
using System;
using System.Collections.Generic;

namespace RepoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        public UserController(FirstContext context) : base(context) { }

        [Route("GetUsers")]
        [HttpPost]
        public IActionResult GetUsers([FromForm] DataTablesParameters parameters)
        {
            try
            {
                using (UserRepository repo = new UserRepository(_context))
                {
                    var userList = repo.GetUsers(parameters);
                    return CreateDataTableResult(userList, parameters);

                }
            }
            catch (Exception ex)
            {
                return CreateExceptionLog(ex);
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

        [Route("GetEdit/{id:guid}")]
        [HttpGet]
        public IActionResult GetEdit(Guid id)
        {

            using (UserRepository repo = new UserRepository(_context))
            {
                if (repo.UserExists(id))
                {
                    var model = repo.GetEdit(id);
                    return Json(model);

                }
                return BadRequest();
            }
        }

        [Route("Add")]
        [HttpPost]
        public IActionResult Add(UserAddModel _model)
        {
            try
            {

                using (UserRepository repo = new UserRepository(_context))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (ModelState.IsValid)
                    {
                        if (repo.CheckUserName(_model.UserName))
                        {
                            
                            errors.Add("UserName", "User name already exists");
                        }
                        if (repo.CheckEmail(_model.Email))
                        {
                            
                            errors.Add("Email", "Email already exists");

                        }
                        if (!repo.CheckUserName(_model.UserName) && !repo.CheckEmail(_model.Email))
                        {
                            repo.Add(_model);
                            return CreateJsonOk();

                        }
                    }
                    return CreateJsonValidationError(errors);

                }

            }


            catch (Exception ex)
            {
                return CreateExceptionLog(ex);
            }
        }


        [Route("Edit")]
        [HttpPost]
        public IActionResult Edit(UserEditModel _model)
        {

            var changePassword = false;
            var equalPasswords = false;
            var changeRoles = false;

            try
            {
                // ExecutionResult execResult = new ExecutionResult();
                Dictionary<string, string> errors = new Dictionary<string, string>();

                if (ModelState.IsValid)
                {
                    using (UserRepository repo = new UserRepository(_context))
                    {

                        if (_model.IsChangePassword)
                        {


                            if (string.IsNullOrEmpty(_model.Password))
                            {
                                //execResult.ExecutionStatus = ResultOutcome.NOTVALID;
                                errors.Add("Password", "Insert password");
                                changePassword = true;
                                equalPasswords = true;

                            }


                            else if (!_model.Password.Equals(_model.ConfirmPassword))
                            {

                                //execResult.ExecutionStatus = ResultOutcome.NOTVALID;
                                errors.Add("ConfirmPassword", "Passwords don't match");
                                equalPasswords = true;

                            }

                        }

                        if (_model.IsChangeRoles)
                        {
                            if (_model.Roles.Count == 0)
                            {
                                //execResult.ExecutionStatus = ResultOutcome.NOTVALID;
                                errors.Add("IsChangeRoles", "Select at least one role");
                                changeRoles = true;
                            }
                        }

                        if (repo.CheckUserNameForEdit(_model.UserName, _model.Id))
                        {
                            // execResult.ExecutionStatus = ResultOutcome.NOTVALID;
                            errors.Add("UserName", "User name already exists");
                        }
                        if (repo.CheckUserEmailForEdit(_model.Email, _model.Id))
                        {
                            //execResult.ExecutionStatus = ResultOutcome.NOTVALID;
                            errors.Add("Email", "Email already exists");
                        }
                        if (!repo.CheckUserNameForEdit(_model.UserName, _model.Id)
                            && !repo.CheckUserEmailForEdit(_model.Email, _model.Id)
                            && !changePassword && !changeRoles && !equalPasswords)
                        {
                            // model.Id = GetCurrentUserId();
                            repo.Edit(_model);
                            return CreateJsonOk();


                        }


                    }
                }
                return CreateJsonValidationError(errors);


            }

            catch (Exception ex)
            {
                return CreateExceptionLog(ex);
            }
        }

        [Route("GetDetails/{id:guid}")]
        [HttpGet]
        public IActionResult GetDetails(Guid id)
        {
            try
            {

                using (UserRepository repo = new UserRepository(_context))
                {

                    if (repo.UserExists(id))
                    {
                        var details = repo.GetDetails(id);
                        return Json(details);
                    }
                    else
                        return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return CreateExceptionLog(ex);
            }

        }
    }
}
