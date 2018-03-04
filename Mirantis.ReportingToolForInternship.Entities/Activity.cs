namespace Mirantis.ReportingTool.Entities
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Activity
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
        public Guid Id { get; set; }

        public Guid ReportId { get; set; }
		public Report Report { get; set; }

		public string Description { get; set; }

        public string Evaluation { get; set; }
             
        public virtual List<Question> Questions { get; set; }
    }
}
