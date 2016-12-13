namespace Mirantis.ReportingToolForInternship.PL.WebUI.Models
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class CookieUser
    {
        public int Id { get; set; }
        public List<Role> Roles { get; set; }
    }
}