using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RepoApp.BLL.Models
{
    public class ProjectViewModelAdd
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Insert project name")]
        [DisplayName("Project name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Select department")]
        [DisplayName("Department")]
        public Guid DepartmentId { get; set; }

        [Required(ErrorMessage = "Select Cedacri International responsible user")]
        [DisplayName("Cedacri International responsible user")]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "Insert Cedacri International responsible user")]
        [DisplayName("Cedacri Italia responsible user name")]
        public string Username { get; set; }

    }
}
