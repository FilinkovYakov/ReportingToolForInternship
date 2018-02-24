namespace Mirantis.ReportingTool.Entities
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Question
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
        public Guid Id { get; set; }

        public Guid ActivityId { get; set; }

        public string Description { get; set; }
    }
}
