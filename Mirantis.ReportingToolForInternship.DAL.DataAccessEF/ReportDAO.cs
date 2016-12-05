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

        public void Add(Report report)
        {
            using (var dbContext = new CustomDBContext(connectionString))
            {
                dbContext.Reports.Add(report);
                dbContext.SaveChanges();
            }
        }

        public void Edit(Report report)
        {
            using (var dbContext = new CustomDBContext(connectionString))
            {
                var transaction = dbContext.Database.BeginTransaction();

                //Remove
                RemoveNonexistentActivities(report, dbContext);
                RemoveNonexistentFuturePlans(report, dbContext);

                //Edit and add
                var originalReport = dbContext.Reports.Find(report.Id);
                dbContext.Entry(originalReport).CurrentValues.SetValues(report);

                AddNewAndEditOldActivities(report, dbContext);
                AddNewAndEditOldFuturePlans(report, dbContext);

                transaction.Commit();
                dbContext.SaveChanges();
            }
        }

        public Report GetById(Guid id)
        {
            using (var dbContext = new CustomDBContext(connectionString))
            {
                return dbContext.Reports.Where(report => report.Id == id)
                    .Include(report => report.Activities
                    .Select(activity => activity.Questions))
                    .Include(report => report.FuturePlans).First();
            }
        }

        public IList<Report> Search(SearchModel searchModel)
        {
            using (var dbContext = new CustomDBContext(connectionString))
            {
                var query = dbContext.Reports.Select(report => report);
                if (searchModel.DateTo != null)
                {
                    query = query.Where(report => report.Date <= searchModel.DateTo);
                } 

                if (searchModel.DateFrom != null)
                {
                    query = query.Where(report => report.Date >= searchModel.DateFrom);
                }

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

                query = query.OrderBy(report => report.Date);

                return query.Include(report => report.Activities
                    .Select(activity => activity.Questions))
                    .Include(report => report.FuturePlans)
                    .ToList();
            }
        }

        private void RemoveNonexistentActivities(Report report, CustomDBContext dbContext)
        {
            var listOriginalActivities = dbContext.Activities.Where(activity => activity.ReportId == report.Id).ToList();

            foreach (var originalActivity in listOriginalActivities)
            {
                Activity newActivity = report.Activities.Where(activity => activity.Id == originalActivity.Id).FirstOrDefault();
                if (newActivity == null)
                {
                    dbContext.Activities.Remove(originalActivity);
                    //Каскад?
                }
                else
                {
                    RemoveNonexistentQuestions(newActivity, dbContext);
                }
            }
        }

        private void RemoveNonexistentQuestions(Activity newActivity, CustomDBContext dbContext)
        {
            var listOriginalQuestions = dbContext.Questions.Where(question => question.ActivityId == newActivity.Id).ToList();

            if (listOriginalQuestions.Any())
            {
                foreach (var originalQuestion in listOriginalQuestions)
                {
                    if (newActivity.Questions == null)
                    {
                        dbContext.Questions.Remove(originalQuestion);
                    }
                    else
                    {
                        Question newQuestion = newActivity.Questions.Where(question => question.Id == originalQuestion.Id).FirstOrDefault();
                        if (newQuestion == null)
                        {
                            dbContext.Questions.Remove(originalQuestion);
                        }
                    }
                }
            }
        }

        private void RemoveNonexistentFuturePlans(Report report, CustomDBContext dbContext)
        {
            var listOriginalFuturePlans = dbContext.FuturePlans.Where(activity => activity.ReportId == report.Id).ToList();

            foreach (var originalFuturePlan in listOriginalFuturePlans)
            {
                if (!report.FuturePlans.Any(futurePlan => futurePlan.Id == originalFuturePlan.Id))
                {
                    dbContext.FuturePlans.Remove(originalFuturePlan);
                }
            }
        }

        private void AddNewAndEditOldActivities(Report report, CustomDBContext dbContext)
        {
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

                AddNewAndEditOldQuestions(activity, dbContext);
            }
        }

        private void AddNewAndEditOldQuestions(Activity activity, CustomDBContext dbContext)
        {
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

        private void AddNewAndEditOldFuturePlans(Report report, CustomDBContext dbContext)
        {
            foreach (var futurePlan in report.FuturePlans)
            {
                var originalFuturePlan = dbContext.FuturePlans.Find(futurePlan.Id);
                if (originalFuturePlan == null)
                {
                    dbContext.FuturePlans.Add(futurePlan);
                }
                else
                {
                    dbContext.Entry(originalFuturePlan).CurrentValues.SetValues(futurePlan);
                }
            }
        }
    }
}