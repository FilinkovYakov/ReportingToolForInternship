namespace Mirantis.ReportingTool.Entities
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Task
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid Id { get; set; }

		public Guid ProjectId { get; set; }
		public Project Project { get; set; }

		public int ReporterId { get; set; }

		[NotMapped]
		public User Reporter { get; set; }

		public int? AssigneeId { get; set; }

		[NotMapped]
		public User Assignee { get; set; }

		public string Title { get; set; }
		public string Description { get; set; }
		public string Status { get; set; }
	}
}
