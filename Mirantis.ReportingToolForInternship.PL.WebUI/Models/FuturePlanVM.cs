namespace Mirantis.ReportingToolForInternship.PL.WebUI.Models
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class FuturePlanVM
    {
        [Key]
        public Guid? Id { get; set; }

        public Guid ReportId { get; set; }

        public string Description { get; set; }
    }
}