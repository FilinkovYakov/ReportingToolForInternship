namespace Mirantis.ReportingTool.Entities
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Project
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Customer { get; set; }
		public IList<Task> Tasks { get; set; }
	}
}
