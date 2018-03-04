namespace Mirantis.ReportingTool.Entities
{
	using System;

	public class SearchTaskModel
	{
		public Guid? ProjectId { get; set; }
		public Guid? ReporterId { get; set; }
		public Guid? AssigneeId { get; set; }
		public string Title { get; set; }
		public string Status { get; set; }
	}
}
