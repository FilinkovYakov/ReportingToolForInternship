namespace Mirantis.ReportingTool.PL.WebUI.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using ValidationAttributes;

	public class ReportVM
	{
		[Key]
		public Guid? Id { get; set; }

		[Display(Name = "Task :")]
		[Required(ErrorMessage = "Field 'Task' is required")]
		public Guid? TaskId { get; set; }
		public TaskVM Task { get; set; }

		[Display(Name = "Manager :")]
		public Guid? ManagerId { get; set; }
		public UserVM Manager { get; set; }

		[Display(Name = "Engineer :")]
		public Guid? EngineerId { get; set; }
		public UserVM Engineer { get; set; }

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

		public bool IsEngineerReport()
		{
			return ManagerId == null;
		}
	}
}