namespace Mirantis.ReportingToolForInternship.PL.WebUI.Models
{
    using BLL.Contracts;
    using BLL.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class DataProvider
    {
        static DataProvider()
        {
            ReportLogic = new ReportLogic();
        }

        public static IReportLogic ReportLogic { get; private set; }
    }
}