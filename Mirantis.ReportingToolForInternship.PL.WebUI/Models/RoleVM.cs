using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mirantis.ReportingToolForInternship.PL.WebUI.Models
{
    public class RoleVM
    {
        [Key]
        public int Id { get; set; }

        public String RoleName { get; set; }
    }
}