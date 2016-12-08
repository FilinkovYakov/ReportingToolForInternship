namespace Mirantis.ReportingToolForInternship.PL.WebUI.Models
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    [Serializable]
    public class AuthenticationUserVM
    {
        [Required]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public List<Role> Roles { get; set; }
    }
}