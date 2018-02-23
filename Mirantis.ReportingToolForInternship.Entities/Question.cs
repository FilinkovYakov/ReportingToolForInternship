namespace Mirantis.ReportingTool.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Question
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ActivityId { get; set; }

        public string Description { get; set; }
    }
}
