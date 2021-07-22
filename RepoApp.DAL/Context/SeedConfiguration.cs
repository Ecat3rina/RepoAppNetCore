using RepoApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoApp.DAL.Context
{
    public static class SeedConfiguration
    {
        public static readonly DMRole AdminRole = new DMRole { Id = new Guid("5AE6D943-6DD5-451A-9C64-4CAF213559F6"), Name = "Admin" };

        public static readonly DMUser user1 = new DMUser
        {
            Id = new Guid("C41722D4-482E-42D2-B24B-50CBBE387996"),
            UserName = "user",
            FullName = "Catea",
            Email = "catea@mail",
            Password = "cat",
            IsConnected=true
        };

        public static readonly DMUserRole userRole = new DMUserRole
        {
            UserId = new Guid("C41722D4-482E-42D2-B24B-50CBBE387996"),
            RoleId = new Guid("5AE6D943-6DD5-451A-9C64-4CAF213559F6")
        };
       
    }
}
