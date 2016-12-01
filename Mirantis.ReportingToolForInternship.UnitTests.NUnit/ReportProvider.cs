namespace Mirantis.ReportingToolForInternship.UnitTests.NUnit
{
    using Entities;
    using PL.WebUI.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class ReportProvider
    {
        public static Report GetCorrectReport()
        {
            return new Report()
            {
                Id = new Guid(),
                InternName = "name",
                Date = DateTime.Now,
                TypeOccuring = "Daily",
                IsDraft = false,
                Activities = new List<Activity>()
                    {
                        new Activity()
                        {
                            Id = new Guid(),
                            Description = "activity"
                        }
                    },

                FuturePlans = new List<FuturePlan>()
                    {
                        new FuturePlan()
                        {
                            Id = new Guid(),
                            Description = "futureplan"
                        }
                    }
            };
        }

        public static ReportVM GetCorrectReportVM()
        {
            return new ReportVM()
            {
                Id = new Guid(),
                InternName = "name",
                Date = DateTime.Now,
                TypeOccuring = "Daily",
                IsDraft = false,
                Activities = new List<ActivityVM>()
                    {
                        new ActivityVM()
                        {
                            Id = new Guid(),
                            Description = "activity"
                        }
                    },

                FuturePlans = new List<FuturePlanVM>()
                    {
                        new FuturePlanVM()
                        {
                            Id = new Guid(),
                            Description = "futureplan"
                        }
                    }
            };
        }
    }
}
