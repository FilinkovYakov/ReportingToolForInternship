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

        [Display(Name = "Mentor :")]
        public string MentorName { get; set; }

        [Display(Name = "Intern :")]
        public string InternName { get; set; }

        [Display(Name = "Type occuring :")]
        public string TypeOccuring { get; set; }

        public List<Activity> Activities { get; set; }

        public List<FuturePlan> FuturePlans { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date :")]
        public DateTime Date { get; set; }

        [Display(Name = "Is draft :")]
        public bool IsDraft { get; set; }
    }
}
