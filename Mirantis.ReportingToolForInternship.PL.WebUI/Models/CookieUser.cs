namespace Mirantis.ReportingTool.PL.WebUI.Models
{
	using Entities;
	using System;
	using System.Collections.Generic;

	public class CookieUser
    {
        public Guid Id { get; set; }
        public List<Role> Roles { get; set; }
    }
}