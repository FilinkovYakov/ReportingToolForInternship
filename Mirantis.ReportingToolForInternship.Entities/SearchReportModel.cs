namespace Mirantis.ReportingTool.Entities
{
	using System;

	public class SearchReportModel
    {
        public int? RequesterUserId { get; set; }

        public int? EngineerId { get; set; }

        public int? ManagerId { get; set; }

        public string Title { get; set; }

        public string TypeOrigin { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }
    }
}
