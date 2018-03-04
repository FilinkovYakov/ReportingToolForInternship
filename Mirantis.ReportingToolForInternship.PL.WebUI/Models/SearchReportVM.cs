namespace Mirantis.ReportingTool.PL.WebUI.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;

	public class SearchReportVM
    {
        public Guid? RequesterUserId { get; set; }

		[Display(Name = "Task :")]
		public Guid? TaskId { get; set; }

		[Display(Name = "Title :")]
        public string Title { get; set; }

        [Display(Name = "Engineer :")]
        public Guid? EngineerId { get; set; }

        [Display(Name = "Manager :")]
        public Guid? ManagerId { get; set; }

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