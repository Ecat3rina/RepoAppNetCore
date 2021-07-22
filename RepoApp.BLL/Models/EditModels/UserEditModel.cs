using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RepoApp.BLL.Models.EditModels
{
    public class UserEditModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Insert Username")]
        [DisplayName("Username")]
        public string UserName { get; set; }

        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [DisplayName("Confirm password")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Insert E-mail")]
        [EmailAddress(ErrorMessage = "Wrong email")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Insert Full name")]
        [DisplayName("Full name")]
        public string FullName { get; set; }

        [DisplayName("Change connection")]
        public bool ChangeConnection { get; set; }

        [DisplayName("Change password")]
        public bool IsChangePassword { get; set; }

        [DisplayName("Roles")]
        public ICollection<Guid> Roles { get; set; } = new HashSet<Guid>();

        [DisplayName("Change roles")]
        public bool IsChangeRoles { get; set; }

        public bool PreviousConnection { get; set; }


    }
}
