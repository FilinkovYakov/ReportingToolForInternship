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
        [Display(Name = "Login :")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password :")]
        public string Password { get; set; }
    }
}