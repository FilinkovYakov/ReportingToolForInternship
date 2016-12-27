namespace Mirantis.ReportingToolForInternship.BLL.Contracts
{
    using Entities;
    using System;
    using System.Collections.Generic;

    public interface IReportLogic
    {
        void Add(Report report);
        IList<RepresentingReport> SearchForUser(SearchModel searchModel);
        IList<Report> SearchForValidation(SearchModel searchModel);
        Report GetById(Guid id);
        RepresentingReport GetRepresentReportById(Guid id);
        void Edit(Report report);
    }
}