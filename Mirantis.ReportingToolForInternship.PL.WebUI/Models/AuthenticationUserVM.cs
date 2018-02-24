namespace Mirantis.ReportingTool.PL.WebUI.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;

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