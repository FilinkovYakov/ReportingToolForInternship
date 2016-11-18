namespace Mirantis.ReportingToolForInternship.PL.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class FuturePlanVM
    {
        public Guid ReportId { get; set; }

        public string Description { get; set; }
    }
}