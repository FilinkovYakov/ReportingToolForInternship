namespace Mirantis.ReportingToolForInternship.PL.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class SearchVM
    {
        [Display(Name = "Intern :")]
        public string InternName { get; set; }

        [Display(Name = "Mentor :")]
        public string MentorName { get; set; }

        [Display(Name = "Type :")]
        public string Type { get; set; }

        [Display(Name = "From :")]
        [DataType(DataType.Date)]
        public DateTime DateFrom { get; set; }

        [Display(Name = "To :")]
        [DataType(DataType.Date)]
        public DateTime DateTo { get; set; }

    }
}