namespace Mirantis.ReportingToolForInternship.PL.WebUI.Models
{
    using Entities;
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

        [Display(Name = "Type occuring :")]
        public string TypeOccuring { get; set; }

        [Display(Name = "Type origin :")]
        public string TypeOrigin { get; set; }

        [Required(ErrorMessage = "Field 'From' is required")]
        [Display(Name = "From :")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateFrom { get; set; }

        [Required(ErrorMessage = "Field 'To' is required")]
        [Display(Name = "To :")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateTo { get; set; }

        public static explicit operator SearchModel(SearchVM searchVM)
        {
            return new SearchModel()
            {
                InternName = searchVM.InternName,
                MentorName = searchVM.MentorName,
                DateFrom = searchVM.DateFrom,
                DateTo = searchVM.DateTo,
                TypeOccuring = searchVM.TypeOccuring,
                TypeOrigin = searchVM.TypeOrigin
            };
        }
    }
}