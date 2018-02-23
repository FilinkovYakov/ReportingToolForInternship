namespace Mirantis.ReportingTool.PL.WebUI.Models
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class ActivityVM
    {
        [Key]
        public Guid? Id { get; set; }

        public Guid ReportId { get; set; }

        public string Description { get; set; }

        public string Evaluation { get; set; }

        public List<QuestionVM> Questions { get; set; }
    }
}