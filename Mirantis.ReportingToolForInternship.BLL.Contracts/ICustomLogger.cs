﻿namespace Mirantis.ReportingToolForInternship.BLL.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICustomLogger
    {
        void RecordError(Exception e);
    }
}
