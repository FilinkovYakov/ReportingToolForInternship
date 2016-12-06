namespace Mirantis.ReportingToolForInternship.PL.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class UserVM
    {
        [Key]
        public int Id { get; set; }

        public string Login { get; set; }

        public string FullName { get; set; }

        public string Name { get; set; }

        public List<RoleVM> Roles { get; set; }
    }
}