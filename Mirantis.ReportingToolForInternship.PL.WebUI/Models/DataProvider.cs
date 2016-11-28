namespace Mirantis.ReportingToolForInternship.PL.WebUI.Models
{
    using BLL.Contracts;
    using BLL.Core;
    using Microsoft.Practices.Unity;

    public class DataProvider
    {
        private static IReportLogic reportLogic;

        static DataProvider()
        {
            reportLogic = ContainerProvider.Container.Resolve<IReportLogic>();
        }

        public static IReportLogic ReportLogic
        {
            get
            {
                return reportLogic;
            }
        }
    }
}