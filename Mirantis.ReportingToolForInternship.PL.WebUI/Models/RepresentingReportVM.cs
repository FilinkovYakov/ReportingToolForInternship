namespace Mirantis.ReportingTool.PL.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using ValidationAttributes;

    public class RepresentingReportVM
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Title :")]
        public string Title { get; set; }

        [Display(Name = "Engineer :")]
        public string EngineerFullName { get; set; }

        [Display(Name = "Manager :")]
        public string ManagerFullName { get; set; }

        [Display(Name = "Type occurring :")]
        public string TypeOccuring { get; set; }

        [Display(Name = "Type origin :")]
        public string TypeOrigin { get; set; }

        [Required(ErrorMessage = "Field 'From' is required")]
        [Display(Name = "Date :")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Is draft :")]
        public bool IsDraft { get; set; }

        [ActivitiesValidator]
        [ActivityValidator]
        public List<ActivityVM> Activities { get; set; }

        [FuturePlansValidator]
        public List<FuturePlanVM> FuturePlans { get; set; }

        public bool IsEngineerReport()
        {
            return string.IsNullOrEmpty(ManagerFullName);
        }
    }
}