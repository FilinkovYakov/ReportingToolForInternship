namespace Mirantis.ReportingToolForInternship.PL.WebUI.Models
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using ValidationAttributes;

    public class ReportVM
    {
        [Key]
        public Guid? Id { get; set; }

        [Display(Name = "Mentor :")]
        public string MentorName { get; set; }

        [Display(Name = "Intern :")]
        public string InternName { get; set; }

        [Display(Name = "Type occuring :")]
        public string TypeOccuring { get; set; }
        
        [ActivitiesValidator]
        public List<ActivityVM> Activities { get; set; }

        public List<FuturePlanVM> FuturePlans { get; set; }

        [Required(ErrorMessage = "Field 'From' is required")]
        [Display(Name = "Date :")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Is draft :")]
        public bool IsDraft { get; set; }

        public static explicit operator Report(ReportVM reportVM)
        {
            return new Report()
            {
                Id = reportVM.Id ?? (new Guid()),
                Activities = reportVM.Activities?.Select(activity => (Activity)activity).ToList(),
                Date = reportVM.Date,
                FuturePlans = reportVM.FuturePlans?.Select(futurePlan => (FuturePlan)futurePlan).ToList(),
                InternName = reportVM.InternName,
                IsDraft = reportVM.IsDraft,
                MentorName = reportVM.MentorName,
                TypeOccuring = reportVM.TypeOccuring
            };
        }

        public static explicit operator ReportVM(Report report)
        {
            return new ReportVM()
            {
                Id = report.Id,
                Activities = report.Activities?.Select(activity => (ActivityVM)activity).ToList(),
                Date = report.Date,
                FuturePlans = report.FuturePlans?.Select(futurePlan => (FuturePlanVM)futurePlan).ToList(),
                InternName = report.InternName,
                IsDraft = report.IsDraft,
                MentorName = report.MentorName,
                TypeOccuring = report.TypeOccuring
            };
        }
    }
}