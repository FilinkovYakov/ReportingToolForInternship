namespace Mirantis.ReportingToolForInternship.DAL.Contracts
{
    using Entities;
    using System;
    using System.Collections.Generic;

    public interface IReportDAO
    {
        void Add(Report report);
        IList<Report> Search(SearchModel searchModel);
        Report GetById(Guid id);
        void Edit(Report report);
    }
}
