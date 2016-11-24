namespace Mirantis.ReportingToolForInternship.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;

    public class Activity
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ReportId { get; set; }

        public string Description { get; set; }

        public string Evaluation { get; set; }
             
        public virtual List<Question> Questions { get; set; }
    }
}
