namespace Mirantis.ReportingTool.PL.WebUI.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;

	public class TaskVM
	{
		[Key]
		public Guid? Id { get; set; }

		[Display(Name = "Project :")]
		[Required(ErrorMessage = "Project is required")]
		public Guid? ProjectId { get; set; }
		public ProjectVM Project { get; set; }

		[Display(Name = "Reporter :")]
		public Guid? ReporterId { get; set; }
		public UserVM Reporter { get; set; }

		[Display(Name = "Assignee :")]
		public Guid? AssigneeId { get; set; }
		public UserVM Assignee { get; set; }

		[Display(Name = "Title :")]
		[Required(ErrorMessage = "Field 'Title' is required")]
		[MaxLength(300, ErrorMessage = "Title should consist at maximum 300 characters")]
		public string Title { get; set; }

		[Display(Name = "Description :")]
		[DataType(DataType.MultilineText)]
		[MaxLength(4000, ErrorMessage = "Description should consist at maximum 4000 characters")]
		public string Description { get; set; }

		[Display(Name = "Status :")]
		[Required(ErrorMessage = "Field 'Status' is required")]
		public string Status { get; set; }
	}
}