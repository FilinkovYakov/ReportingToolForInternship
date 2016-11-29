namespace Mirantis.ReportingToolForInternship.BLL.Core
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using Entities;

    public class ReportLogic : IReportLogic
    {
        private static Guid defaultGuid = new Guid();

        public void Add(Report report)
        {
            try
            {
                report.Id = Guid.NewGuid();

                if (report.Activities != null)
                {
                    foreach (var activity in report.Activities)
                    {
                        activity.Id = Guid.NewGuid();
                        activity.ReportId = report.Id;
                        if (activity.Questions != null)
                        {
                            foreach (var question in activity.Questions)
                            {
                                question.Id = Guid.NewGuid();
                                question.ActivityId = activity.Id;
                            }
                        }
                    }
                }

                if (report.FuturePlans != null)
                {
                    foreach (var futherPlan in report.FuturePlans)
                    {
                        futherPlan.Id = Guid.NewGuid();
                        futherPlan.ReportId = report.Id;
                    }
                }

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
                if (report.Activities != null)
                {
                    foreach (var activity in report.Activities)
                    {
                        if (activity.Id == defaultGuid)
                        {
                            activity.Id = Guid.NewGuid();
                        }

                        activity.ReportId = report.Id;
                        if (activity.Questions != null)
                        {
                            foreach (var question in activity.Questions)
                            {
                                if (question.Id == defaultGuid)
                                {
                                    question.Id = Guid.NewGuid();
                                }

                                question.ActivityId = activity.Id;
                            }
                        }
                    }
                }

                if (report.FuturePlans != null)
                {
                    foreach (var futherPlan in report.FuturePlans)
                    {
                        if (futherPlan.Id == defaultGuid)
                        {
                            futherPlan.Id = Guid.NewGuid();
                        }

                        futherPlan.ReportId = report.Id;
                    }
                }

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
    }
}
