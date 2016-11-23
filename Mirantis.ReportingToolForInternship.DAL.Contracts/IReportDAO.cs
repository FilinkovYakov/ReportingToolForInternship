namespace Mirantis.ReportingToolForInternship.DAL.Contracts
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IReportDAO
    {
        void Add(Report report);
        IEnumerable<Report> Search(SearchModel searchModel);
        Report GetById(Guid id);
        void Edit(Report report);
    }
}
