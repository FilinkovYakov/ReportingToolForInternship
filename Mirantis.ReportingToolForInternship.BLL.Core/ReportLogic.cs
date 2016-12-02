namespace Mirantis.ReportingToolForInternship.BLL.Core
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using Entities;
    using System.Linq;
    using DAL.Contracts;

    public class ReportLogic : IReportLogic
    {
        private static Guid defaultGuid = new Guid();
        private readonly IReportDAO _reportDAO;
        private readonly ICustomLogger _customLogger;

        public ReportLogic(IReportDAO reportDAO, ICustomLogger customLogger)
        {
            _reportDAO = reportDAO;
            _customLogger = customLogger;
        }

        public void Add(Report report)
        {
            try
            {
                report.Id = Guid.NewGuid();
                report.Activities = GetCorrectActivities(report).ToList();
                report.FuturePlans = GetCorrectFuturePlans(report).ToList();
                _reportDAO.Add(report);
            }
            catch (Exception e)
            {
                _customLogger.RecordError(e);
                throw;
            }
        }

        public void Edit(Report report)
        {
            try
            {
                report.Activities = GetCorrectActivities(report).ToList();
                report.FuturePlans = GetCorrectFuturePlans(report).ToList();
                _reportDAO.Edit(report);
            }
            catch (Exception e)
            {
                _customLogger.RecordError(e);
                throw;
            }
        }

        public Report GetById(Guid id)
        {
            try
            {
                return _reportDAO.GetById(id);
            }
            catch (Exception e)
            {
                _customLogger.RecordError(e);
                throw;
            }
        }

        public IList<Report> Search(SearchModel searchModel)
        {
            try
            {
                return _reportDAO.Search(searchModel);
            }
            catch (Exception e)
            {
                _customLogger.RecordError(e);
                throw;
            }
        }

        private IEnumerable<Activity> GetCorrectActivities(Report report)
        {
            if (report.Activities == null)
            {
                throw new ArgumentException("Report should contain at least one activity");
            }

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
            if (report.FuturePlans == null)
            {
                throw new ArgumentException("Report should contain at least one future plan");
            }

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
    }
}
