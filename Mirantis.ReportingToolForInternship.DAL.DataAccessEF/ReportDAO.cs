namespace Mirantis.ReportingToolForInternship.DAL.DataAccessEF
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
            var transaction = dbContext.Database.BeginTransaction();
            var originalReport = dbContext.Reports.Find(report.Id);
            //Remove
            var listOriginalActivities = dbContext.Activities.Where(activity => activity.ReportId == report.Id).ToList();
            var listOriginalQuestions = new List<Question>();
            foreach (var originalActivity in listOriginalActivities)
            {
                var listOriginalQuestionsBelongToActivity = dbContext.Questions.Where(question => question.ActivityId == originalActivity.Id).ToList();
                listOriginalQuestions.AddRange(listOriginalQuestionsBelongToActivity);
            }

            var listOriginalFuturePlans = dbContext.FuturePlans.Where(activity => activity.ReportId == report.Id).ToList();

            foreach (var originalActivity in listOriginalActivities)
            {
                if (!report.Activities.Any(activity => originalActivity.Id == activity.Id))
                {
                    dbContext.Activities.Remove(originalActivity);
                }
            }

            foreach (var originalQuestion in listOriginalQuestions)
            {
                if (!report.Activities.Any(activity => originalActivity.Id == activity.Id))
                {
                    dbContext.Activities.Remove(originalActivity);
                }
            }

            //Edit and add
            dbContext.Entry(originalReport).CurrentValues.SetValues(report);
            foreach (var activity in report.Activities)
            {
                var originalActivity = dbContext.Activities.Find(activity.Id);
                if (originalActivity == null)
                {
                    dbContext.Activities.Add(activity);
                }
                else
                {
                    dbContext.Entry(originalActivity).CurrentValues.SetValues(activity);
                }

                foreach (var question in activity.Questions)
                {
                    var originalQuestion = dbContext.Questions.Find(question.Id);
                    if (originalQuestion == null)
                    {
                        dbContext.Questions.Add(question);
                    }
                    else
                    {
                        dbContext.Entry(originalQuestion).CurrentValues.SetValues(question);
                    }
                }
            }

            foreach (var futurePlan in report.FuturePlans)
            {
                var originalFuturePlan = dbContext.Reports.Find(futurePlan.Id);
                if (originalFuturePlan == null)
                {
                    dbContext.FuturePlans.Add(futurePlan);
                }
                else
                {
                    dbContext.Entry(originalFuturePlan).CurrentValues.SetValues(futurePlan);
                }
            }

            transaction.Commit();
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