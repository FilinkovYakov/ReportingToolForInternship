namespace Mirantis.ReportingToolForInternship.PL.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class ReportVM
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Mentor :")]
        public string MentorName { get; set; }

        [Display(Name = "Intern :")]
        public string InternName { get; set; }

        [Display(Name = "Type :")]
        public string Type { get; set; }
        
        public List<ActivityVM> Activities { get; set; }

        public List<FuturePlanVM> FuturePlans { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date :")]
        public DateTime Date { get; set; }

        [Display(Name = "Is draft :")]
        public bool IsDraft { get; set; }
    }
}