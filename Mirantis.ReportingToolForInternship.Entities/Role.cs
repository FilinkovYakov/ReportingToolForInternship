﻿namespace Mirantis.ReportingToolForInternship.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Serializable]
    public class Role
    {
        public int Id { get; set; }

        public string RoleName { get; set; }
    }
}
