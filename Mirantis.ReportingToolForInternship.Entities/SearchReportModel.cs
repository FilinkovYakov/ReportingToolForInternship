namespace Mirantis.ReportingTool.Entities
{
	using System;

	public class SearchReportModel
    {
        public Guid? RequesterUserId { get; set; }

		public Guid? TaskId { get; set; }

		public Guid? EngineerId { get; set; }

        public Guid? ManagerId { get; set; }

        public string Title { get; set; }

        public string TypeOrigin { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }
    }
}
