namespace Mirantis.ReportingToolForInternship.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SearchModel
    {
        public string InternName { get; set; }

        public string MentorName { get; set; }

        public string TypeOccuring { get; set; }

        public string TypeOrigin { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }
    }
}
