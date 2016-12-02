namespace Mirantis.ReportingToolForInternship.BLL.Contracts
{
    using Entities;
    using System;
    using System.Collections.Generic;

    public interface IReportLogic
    {
        void Add(Report report);
        IList<Report> Search(SearchModel searchModel);
        Report GetById(Guid id);
        void Edit(Report report);
    }
}
