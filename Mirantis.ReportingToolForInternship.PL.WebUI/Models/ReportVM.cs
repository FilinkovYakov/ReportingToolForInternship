namespace Mirantis.ReportingTool.PL.WebUI.Models
{
    using Entities;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using ValidationAttributes;

    public class ReportVM
    {
        [Key]
        public Guid? Id { get; set; }

        [Display(Name = "Manager :")]
        public int? ManagerId { get; set; }

        [Display(Name = "Engineer :")]
        public int? EngineerId { get; set; }

        [Required(ErrorMessage = "Field 'Title' is required")]
        [MaxLength(300, ErrorMessage = "Title should consist at maximum 300 characters")]
        [Display(Name = "Title :")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Field 'Date' is required")]
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
    }
}