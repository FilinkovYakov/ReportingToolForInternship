namespace Mirantis.ReportingTool.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FuturePlan
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ReportId { get; set; }

        public string Description { get; set; }
    }
}
