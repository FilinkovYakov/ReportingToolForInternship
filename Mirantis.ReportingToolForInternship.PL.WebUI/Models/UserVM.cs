namespace Mirantis.ReportingToolForInternship.PL.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class UserVM
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Name { get; set; }
    }
}