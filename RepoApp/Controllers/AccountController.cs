using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RepoApp.BLL.Models.AuthenticationModels;
using RepoApp.BLL.Repositories;
using RepoApp.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RepoApp.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(FirstContext context) : base(context) { }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserModel model)
        {
            if (ModelState.IsValid)
            {
                using (UserRepository repo = new UserRepository(_context))
                {
                    var user = repo.GetUser(model.UserName, model.Password);
                    if (user == null)
                    {
                        ModelState.AddModelError("Password", "Incorrect user name or password");
                    }
                    else
                    {
                        if (!repo.GetConnection(model.UserName))
                        {
                            ModelState.AddModelError("Password", "User is not connected");
                        }
                        else
                        {
                            await Authenticate(model.UserName); 
                            return RedirectToAction("Index", "Project");
                        }
                    }
                }
                


            }
            return View(model);
        }
        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
