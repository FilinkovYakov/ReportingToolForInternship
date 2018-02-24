namespace Mirantis.ReportingTool.BLL.Contracts
{
    using Entities;
    using System;
    using System.Collections.Generic;

    public interface IReportLogic
    {
        void Add(Report report);
        IList<RepresentingReport> SearchForUser(SearchReportModel searchModel);
        IList<Report> SearchForValidation(SearchReportModel searchModel);
        Report GetById(Guid id);
        RepresentingReport GetRepresentReportById(Guid id);
        void Edit(Report report);
    }
}