namespace Mirantis.ReportingToolForInternship.PL.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class RepresentingReportVM
    {
        [Display(Name = "Intern :")]
        public string InternsFullName { get; set; }

        [Display(Name = "Mentor :")]
        public string MentorsFullName { get; set; }

        [Display(Name = "Type occuring :")]
        public string TypeOccuring { get; set; }

        [Display(Name = "Type origin :")]
        public string TypeOrigin { get; set; }

        [Display(Name = "From :")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateFrom { get; set; }

        [Display(Name = "To :")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateTo { get; set; }
    }
}