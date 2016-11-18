namespace Mirantis.ReportingToolForInternship.PL.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class ActivityVM
    {
        public Guid Id { get; set; }

        public Guid ReportId { get; set; }

        public string Description { get; set; }

        public List<QuestionVM> Questions { get; set; }
    }
}