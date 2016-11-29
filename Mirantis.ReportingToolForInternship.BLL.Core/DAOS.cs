namespace Mirantis.ReportingToolForInternship.BLL.Core
{
    using DAL.Contracts;
    using Microsoft.Practices.Unity;

    public class DAOS
    {
        public static IReportDAO ReportDAO
        {
            get
            {
                return ContainerProvider.Container.Resolve<IReportDAO>();
            }
        }
    }
}
