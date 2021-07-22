using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RepoApp.BLL.Models;
using RepoApp.BLL.Models.AddModels;
using RepoApp.BLL.Models.DetailModels;
using RepoApp.BLL.Models.EditModels;
using RepoApp.BLL.Models.GridModels;
using RepoApp.Common;
using RepoApp.Common.DataTables;
using RepoApp.DAL.Context;
using RepoApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepoApp.BLL.Repositories
{
    public class UserRepository : BaseRepository
    {
        public UserRepository(FirstContext context) : base(context) { }

        public bool GetConnection(string name)
        {
            var isConnected = _context.Users.FirstOrDefault(x => x.UserName == name).IsConnected;
            return isConnected;
        }

        public string GetSuperiorRoleName(string name)
        {
            var userId = _context.Users.FirstOrDefault(x => x.UserName == name).Id;
            var userRoles = _context.UserRoles.Where(x => x.UserId == userId).Select(x => x.Role).ToArray().OrderBy(x => x.Name);
            return userRoles.First().Name;
        }

        public string GetPassword(Guid id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id).Password;
        }
        public UserModel GetUser(string username, string password)
        {
            var user = _context.Users.Select(u => new UserModel
            {
                Id = u.Id,
                Email = u.Email,
                UserName = u.UserName,
                FullName = u.FullName,
                IsConnected = u.IsConnected,
                Password = u.Password

            }).FirstOrDefault(p => p.UserName.ToLower() == username.ToLower() && p.Password == password);

            return user;
        }
        public List<UserGridModel> GetUsers()
        {
            var userList = _context.Users.Select(u => new UserGridModel
            {
                Id = u.Id,
                UserName = u.UserName,
                FullName = u.FullName,
                Email = u.Email,
                IsConnected = u.IsConnected
            }).ToList();

            return userList;
        }
        public bool UserExists(Guid id)
        {
            var result = false;
            if (_context.Users.Any(x => x.Id == id))
                result = true;
            return result;
        }
        public UserModel GetUser(string username)
        {
            var user = _context.Users.Select(u => new UserModel
            {
                Id = u.Id,
                Email = u.Email,
                UserName = u.UserName,
                FullName = u.FullName,
                IsConnected = u.IsConnected,
                Password = u.Password

            }).FirstOrDefault(p => p.UserName.ToLower() == username.ToLower());

            if (user == null)
            {
                throw new NullException();
            }

            return user;
        }

        public List<UserGridModel> GetUsers(DataTablesParameters parameters)
        {
            var users = _context.Users.Select(u => new UserGridModel
            {
                Id = u.Id,
                UserName = u.UserName,
                FullName = u.FullName,
                Email = u.Email,
                IsConnected = u.IsConnected
            });

            if (!string.IsNullOrEmpty(parameters.Search.Value))
            {
                users = users.Where(x => x.UserName.Contains(parameters.Search.Value) ||
                x.FullName.Contains(parameters.Search.Value) ||
                x.Email.Contains(parameters.Search.Value));
            }


            return users.OrderBy(parameters).Page(parameters).ToList();
        }

        public bool CheckUserName(string name)
        {
            var userNameExists = _context.Users.Any(x => x.UserName == name);

            if (userNameExists)
                return true;
            else
                return false;
        }
        public bool CheckUserNameForEdit(string userName, Guid id)
        {
            var userList = _context.Users.Where(x => x.UserName == userName).ToList();

            foreach (var item in userList)
            {
                if (item.Id == id)
                    return false;
                else
                    return true;
            }
            return false;

        }
        public bool CheckUserEmailForEdit(string email, Guid id)
        {
            var userList = _context.Users.Where(x => x.Email == email).ToList();

            foreach (var item in userList)
            {
                if (item.Id == id)
                    return false;
                else
                    return true;
            }
            return false;

        }
        public bool CheckEmail(string email)
        {
            var emailExists = _context.Users.Any(x => x.Email == email);

            if (emailExists)
                return true;
            else
                return false;
        }
        public void Add(UserAddModel model)
        {

            DMUser userToAdd = new DMUser
            {
                Id = Guid.NewGuid(),
                UserName = model.UserName,
                FullName = model.FullName,
                Email = model.Email,
                Password = model.Password,
                IsConnected = true
            };

            userToAdd.UserRoles = model.Roles.Select(x => new DMUserRole { RoleId = x, UserId = userToAdd.Id,}).ToList();

            foreach (DMUserRole item in userToAdd.UserRoles)
            {
                _context.UserRoles.Add(item);
            }
            _context.Entry(userToAdd).State = EntityState.Added;

            _context.SaveChanges();

        }



        public UserDetailsModel GetDetails(Guid id)
        {

            var userDetails = _context.Users.Select(u => new UserDetailsModel
            {
                Id = u.Id,
                UserName = u.UserName,
                FullName = u.FullName,
                Email = u.Email,
                Password = u.Password,
                IsConnected = u.IsConnected,
                Roles = u.UserRoles.Where(x => x.UserId == u.Id)
                .Select(n => n.Role.Name).ToList()
            }).FirstOrDefault(x => x.Id == id);

            return userDetails;

        }

        public UserEditModel GetEdit(Guid id)
        {
            var user = _context.Users.Select(x => new UserEditModel
            {
                Id = x.Id,
                UserName = x.UserName,
                FullName = x.FullName,
                Email = x.Email,
                Password = x.Password,
                ChangeConnection = x.IsConnected
            }).FirstOrDefault(p => p.Id == id);

            return user;
        }
        public void Edit(UserEditModel model)
        {
            var userToEdit = _context.Users.FirstOrDefault(x => x.Id == model.Id);

            userToEdit.UserName = model.UserName;
            userToEdit.FullName = model.FullName;
            userToEdit.Email = model.Email;
            if (model.ChangeConnection)
                userToEdit.IsConnected = !model.PreviousConnection;


            if (model.IsChangePassword)
            {

                userToEdit.Password = model.Password;
            }

            if (model.IsChangeRoles)
            {
                var rolesList = _context.UserRoles.Where(x => x.UserId == model.Id).ToList();
                _context.UserRoles.RemoveRange(rolesList);
                if (model.Roles != null)
                {
                    userToEdit.UserRoles = model.Roles.Select(x => new DMUserRole { UserId = userToEdit.Id, RoleId = x }).ToList();
                }
            }

            _context.Entry(userToEdit).State = EntityState.Modified;

            _context.SaveChanges();
        }

        public UserDetailsModel GetDelete(Guid id)
        {
            var user = _context.Users.Select(x => new UserDetailsModel
            {
                Id = x.Id,
                UserName = x.UserName,
                FullName = x.FullName,
                Email = x.Email,
                Password = x.Password,
                IsConnected = x.IsConnected,
                Roles = x.UserRoles.Where(p => p.UserId == x.Id)
                .Select(n => n.Role.Name).ToList()
            }).FirstOrDefault(m => m.Id == id);

            return user;
        }
        public void Delete(UserDetailsModel model)
        {
            try
            {
                var userToDelete = _context.Users.FirstOrDefault(x => x.Id == model.Id);
                _context.Users.Remove(userToDelete);

                var rolesList = _context.UserRoles.Where(x => x.UserId == model.Id).ToList();
                _context.UserRoles.RemoveRange(rolesList);

                _context.SaveChanges();
            }
            catch (ArgumentException)
            { }
        }

        public List<string> GetUserRoles(UserModel model)
        {
            var roles = _context.UserRoles.Where(x => x.UserId == model.Id).Select(x => x.Role.Name).ToList();
            return roles;
        }

        public List<SelectListItem> GetRoles()
        {

            var rolesList = _context.Roles.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            return rolesList;

        }




    }
}
