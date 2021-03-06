using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoApp.DAL.Entities
{
    public class DMRole
    {
        public DMRole()
        {
            UserRoles = new List<DMUserRole>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<DMUserRole> UserRoles { get; set; }
    }
}
