﻿namespace Mirantis.ReportingTool.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SearchModel
    {
        public int? RequesterUserId { get; set; }

        public int? EngineerId { get; set; }

        public int? ManagerId { get; set; }

        public string Title { get; set; }

        public string TypeOccuring { get; set; }

        public string TypeOrigin { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }
    }
}
