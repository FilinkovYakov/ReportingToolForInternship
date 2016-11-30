namespace Mirantis.ReportingToolForInternship.BLL.Core
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using Entities;
    using System.Linq;

    public class ReportLogic : IReportLogic
    {
        private static Guid defaultGuid = new Guid();

        public void Add(Report report)
        {
            try
            {
                report.Id = Guid.NewGuid();
                report.Activities = GetCorrectActivities(report).ToList();
                report.FuturePlans = GetCorrectFuturePlans(report).ToList();
                DAOS.ReportDAO.Add(report);
            }
            catch (Exception e)
            {
                LoggerProvider.Logger.Error(e);
                throw e;
            }
        }

        public void Edit(Report report)
        {
            try
            {
                report.Activities = GetCorrectActivities(report).ToList();
                report.FuturePlans = GetCorrectFuturePlans(report).ToList();
                DAOS.ReportDAO.Edit(report);
            }
            catch (Exception e)
            {
                LoggerProvider.Logger.Error(e);
                throw e;
            }
        }

        public Report GetById(Guid id)
        {
            try
            {
                return DAOS.ReportDAO.GetById(id);
            }
            catch (Exception e)
            {
                LoggerProvider.Logger.Error(e);
                throw e;
            }
        }

        public IEnumerable<Report> Search(SearchModel searchModel)
        {
            try
            {
                return DAOS.ReportDAO.Search(searchModel);
            }
            catch (Exception e)
            {
                LoggerProvider.Logger.Error(e);
                throw e;
            }
        }

        private IEnumerable<Activity> GetCorrectActivities(Report report)
        {
            if (report.Activities != null)
            {
                foreach (var activity in report.Activities)
                {
                    if (!string.IsNullOrEmpty(activity.Description))
                    {
                        if (activity.Id == defaultGuid)
                        {
                            activity.Id = Guid.NewGuid();
                        }

                        activity.ReportId = report.Id;
                        activity.Questions = GetCorrectQuestions(activity).ToList();
                        yield return activity;
                    }
                }
            }
            else
            {
                throw new ArgumentException("Report should contain at least one activity");
            }
        }

        private IEnumerable<Question> GetCorrectQuestions(Activity activity)
        {
            if (activity.Questions != null)
            {
                foreach (var question in activity.Questions)
                {
                    if (!string.IsNullOrEmpty(question.Description))
                    {
                        if (question.Id == defaultGuid)
                        {
                            question.Id = Guid.NewGuid();
                        }

                        question.ActivityId = activity.Id;
                        yield return question;
                    }
                }
            }
        }

        private IEnumerable<FuturePlan> GetCorrectFuturePlans(Report report)
        {
            if (report.FuturePlans != null)
            {
                foreach (var futurePlan in report.FuturePlans)
                {
                    if (!string.IsNullOrEmpty(futurePlan.Description))
                    {
                        if (futurePlan.Id == defaultGuid)
                        {
                            futurePlan.Id = Guid.NewGuid();
                        }

                        futurePlan.ReportId = report.Id;
                        yield return futurePlan;
                    }
                }
            }
            else
            {
                throw new ArgumentException("Report should contain at least one future plan");
            }
        }
    }
}
