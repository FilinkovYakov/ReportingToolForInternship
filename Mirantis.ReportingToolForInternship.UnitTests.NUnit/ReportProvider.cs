namespace Mirantis.ReportingTool.UnitTests.NUnit
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
        public static Report GetCorrectInternsReport()
        {
            return new Report()
            {
                Id = new Guid(),
                InternsId = 1,
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

        public static Report GetCorrectMentorsReport()
        {
            Report report = GetCorrectInternsReport();
            report.MentorsId = 2;
            return report;
        }

        public static ReportVM GetCorrectInternsReportVM()
        {
            return new ReportVM()
            {
                Id = new Guid(),
                InternsId = 1,
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

        public static ReportVM GetCorrectMentorsReportVM()
        {
            ReportVM report = GetCorrectInternsReportVM();
            report.MentorsId = 2;
            return report;
        }
    }
}
