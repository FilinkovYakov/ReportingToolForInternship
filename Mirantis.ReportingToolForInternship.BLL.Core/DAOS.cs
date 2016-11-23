namespace Mirantis.ReportingToolForInternship.BLL.Core
{
    using Contracts;
    using DAL.Contracts;
    using DAL.DataAccessEF;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DAOS
    {
        static DAOS()
        {
            ReportDAO = new ReportDAO();
        }

        public static IReportDAO ReportDAO { get; private set; }
    }
}
