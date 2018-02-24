namespace Mirantis.ReportingTool.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RepresentingReport
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string ManagerFullName { get; set; }

        public string EngineerFullName { get; set; }

        public string TypeOccuring { get; set; }

        public virtual List<Activity> Activities { get; set; }

        public virtual List<FuturePlan> FuturePlans { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public bool IsDraft { get; set; }
    }
}
