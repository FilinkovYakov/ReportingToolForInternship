namespace Mirantis.ReportingToolForInternship.BLL.Core
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Entities;

    public class ReportLogic : IReportLogic
    {
        public void Add(Report report)
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

        public void Edit(Report report)
        {
            DAOS.ReportDAO.Edit(report);
        }

        public Report GetById(Guid id)
        {
            return DAOS.ReportDAO.GetById(id);
        }

        public IEnumerable<Report> Search(SearchModel searchModel)
        {
            return DAOS.ReportDAO.Search(searchModel);
        }
    }
}
