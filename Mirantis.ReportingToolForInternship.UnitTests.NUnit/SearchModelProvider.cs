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
        public static SearchModel GetSearchModel()
        {
            return new SearchModel()
            {
                InternsId = -1,
                MentorsId = -1,
                DateFrom = null,
                DateTo = null,
                TypeOccuring = "All",
                TypeOrigin = "All"
            };
        }

        public static SearchVM GetSearchVM()
        {
            return new SearchVM()
            {
                InternsId = -1,
                MentorsId = -1,
                DateFrom = null,
                DateTo = null,
                TypeOccuring = "All",
                TypeOrigin = "All"
            };
        }
    }
}
