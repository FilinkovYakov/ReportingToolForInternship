namespace Mirantis.ReportingTool.Entities
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Report
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
        public Guid Id { get; set; }

		public Guid? TaskId { get; set; }
		public Task Task { get; set; }

		public Guid? ManagerId { get; set; }

		[NotMapped]
		public User Manager { get; set; }

        public Guid? EngineerId { get; set; }

		[NotMapped]
		public User Engineer { get; set; }

		[MaxLength(300)]
        public string Title { get; set; }

        public virtual List<Activity> Activities { get; set; }

        public virtual List<FuturePlan> FuturePlans { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public bool IsDraft { get; set; }
    }
}
