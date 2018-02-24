namespace Mirantis.ReportingTool.Entities
{
	using System;

	public class SearchTaskModel
	{
		public Guid? ProjectId { get; set; }
		public int? ReporterId { get; set; }
		public int? AssigneeId { get; set; }
		public string Title { get; set; }
		public string Status { get; set; }
	}
}
