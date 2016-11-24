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
            dbContext.Entry<Report>(report).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public Report GetById(Guid id)
        {
            return dbContext.Reports.Where(report => report.Id == id).First();
        }

        public IEnumerable<Report> Search(SearchModel searchModel)
        {
            var query = dbContext.Reports.Where(report => report.Date >= searchModel.DateFrom && report.Date <= searchModel.DateTo);

            if (searchModel.TypeOccuring != "All")
            {
                query = query.Where(report => report.TypeOccuring == searchModel.TypeOccuring);
            }

            if (searchModel.InternName != "All")
            {
                query = query.Where(report => report.InternName == searchModel.InternName);
            }

            if (searchModel.TypeOrigin == "Mentor's")
            {
                if (searchModel.MentorName != "All")
                {
                    query = query.Where(report => report.MentorName == searchModel.MentorName);
                }
                else
                {
                    query = query.Where(report => !string.IsNullOrEmpty(report.MentorName));
                }
            }
            else if (searchModel.TypeOrigin == "Intern's")
            {
                query = query.Where(report => string.IsNullOrEmpty(report.MentorName));
            }

            return query.AsNoTracking().ToList();
        }
    }
}
