using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RepoApp.BLL.Models.AddModels
{
    public class UserAddModel
    {
        public UserAddModel()
        {
            Roles = new List<Guid>();
        }

        [Required(ErrorMessage = "Insert username")]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Insert personal name")]
        [DisplayName("Personal Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Insert password")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Insert email")]
        [EmailAddress(ErrorMessage = "Wrong email")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Select at least a role")]
        [DisplayName("Roles")]
        public List<Guid> Roles { get; set; } 

    }
}
