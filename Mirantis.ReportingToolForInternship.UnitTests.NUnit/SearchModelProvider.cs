namespace Mirantis.ReportingTool.UnitTests.NUnit
{
    using Entities;
    using PL.WebUI.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SearchModelProvider
    {
        public static SearchReportModel GetSearchModel()
        {
            return new SearchReportModel()
            {
                EngineerId = Guid.NewGuid(),
                ManagerId = Guid.NewGuid(),
                DateFrom = null,
                DateTo = null,
                TypeOrigin = "All"
            };
        }

        public static SearchReportVM GetSearchVM()
        {
            return new SearchReportVM()
            {
                EngineerId = Guid.NewGuid(),
                ManagerId = Guid.NewGuid(),
                DateFrom = null,
                DateTo = null,
                TypeOrigin = "All"
            };
        }
    }
}
