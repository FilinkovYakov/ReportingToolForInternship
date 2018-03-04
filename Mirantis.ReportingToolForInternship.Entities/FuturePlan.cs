namespace Mirantis.ReportingTool.Entities
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class FuturePlan
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
        public Guid Id { get; set; }

        public Guid ReportId { get; set; }
		public Report Report { get; set; }

        public string Description { get; set; }
    }
}
