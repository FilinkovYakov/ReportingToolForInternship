namespace Mirantis.ReportingTool.PL.WebUI.Models
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class SearchVM
    {
        public int? RequesterUserId { get; set; }

        [Display(Name = "Title :")]
        public string Title { get; set; }

        [Display(Name = "Engineer :")]
        public int? EngineerId { get; set; }

        [Display(Name = "Manager :")]
        public int? ManagerId { get; set; }

        [Display(Name = "Type occurring :")]
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