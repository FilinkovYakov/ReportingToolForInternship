namespace Mirantis.ReportingToolForInternship.PL.WebUI.Models
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

        [Display(Name = "Mentor :")]
        public int? MentorsId { get; set; }

        [Display(Name = "Intern :")]
        public int? InternsId { get; set; }

        [Required(ErrorMessage = "Field 'Title' is required")]
        [Display(Name = "Title :")]
        public string Title { get; set; }

        [Display(Name = "Type occuring :")]
        public string TypeOccuring { get; set; }
        
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
    }
}