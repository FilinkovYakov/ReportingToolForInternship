namespace Mirantis.ReportingTool.Entities
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Task
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid Id { get; set; }

		public Guid ProjectId { get; set; }
		public Project Project { get; set; }

		public Guid ReporterId { get; set; }

		[NotMapped]
		public User Reporter { get; set; }

		public Guid? AssigneeId { get; set; }

		[NotMapped]
		public User Assignee { get; set; }

		public string Title { get; set; }
		public string Description { get; set; }
		public string Status { get; set; }

		public IList<Report> Reports { get; set; }
	}
}
