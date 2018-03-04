namespace Mirantis.ReportingTool.PL.WebUI.Models
{
	using Entities;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	public class UserVM
    {
        [Key]
        public Guid Id { get; set; }

        public string Login { get; set; }

        public string FullName { get; set; }

        public List<Role> Roles { get; set; }
    }
}