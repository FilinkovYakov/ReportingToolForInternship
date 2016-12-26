namespace Mirantis.ReportingToolForInternship.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Report
    {
        [Key]
        public Guid Id { get; set; }

        public int? MentorsId { get; set; }

        public int? InternsId { get; set; }

        public string Title { get; set; }

        public string TypeOccuring { get; set; }

        public virtual List<Activity> Activities { get; set; }

        public virtual List<FuturePlan> FuturePlans { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public bool IsDraft { get; set; }
    }
}
