namespace Mirantis.ReportingToolForInternship.PL.WebUI.Models
{
    using BLL.Contracts;
    using BLL.Core;
    using Microsoft.Practices.Unity;

    public class DataProvider
    {
        public static IReportLogic ReportLogic
        {
            get
            {
                return ContainerProvider.Container.Resolve<IReportLogic>();
            }
        }
    }
}