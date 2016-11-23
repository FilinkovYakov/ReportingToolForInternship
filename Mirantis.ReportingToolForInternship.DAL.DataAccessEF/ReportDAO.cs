namespace Mirantis.ReportingToolForInternship.DAL.DataAccessEF
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Entities;
    using System.Configuration;
    using System.Data.Entity;

    public class ReportDAO : IReportDAO
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
        private static CustomDBContext dbContext;

        static ReportDAO()
        {
            dbContext = new CustomDBContext(connectionString);
        }

        public void Add(Report report)
        {
            dbContext.Reports.Add(report);
            dbContext.SaveChanges();
        }

        public void Edit(Report report)
        {
            Report tmpReport = GetById(report.Id);
            tmpReport.InternName = report.InternName;
            tmpReport.MentorName = report.MentorName;
            tmpReport.Type = report.Type;
            tmpReport.FuturePlans = report.FuturePlans;
            tmpReport.Date = report.Date;
            tmpReport.Activities = report.Activities;
            tmpReport.IsDraft = report.IsDraft;
            dbContext.SaveChanges();
        }

        public Report GetById(Guid id)
        {
            return dbContext.Reports.Where(report => report.Id == id).First();
        }

        public IEnumerable<Report> Search(SearchModel searchModel)
        {
            var query = dbContext.Reports.Where(report => report.Date >= searchModel.DateFrom && report.Date <= searchModel.DateTo);

            if (searchModel.Type != "All")
            {
                query = query.Where(report => report.Type == searchModel.Type);
            }

            if (searchModel.InternName != "All")
            {
                query = query.Where(report => report.InternName == searchModel.InternName);
            }

            if (searchModel.MentorName != "All")
            {
                query = query.Where(report => report.MentorName == searchModel.MentorName);
            }

            return query.ToList();
        }
    }
}
