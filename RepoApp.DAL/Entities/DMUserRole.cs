using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoApp.DAL.Entities
{
    public class DMUserRole
    {
        public Guid UserId { get; set; }
        public DMUser User { get; set; }
        public Guid RoleId { get; set; }

        public DMRole Role { get; set; }
    }
}
