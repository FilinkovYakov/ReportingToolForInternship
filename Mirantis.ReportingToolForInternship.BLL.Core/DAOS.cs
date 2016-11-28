namespace Mirantis.ReportingToolForInternship.BLL.Core
{
    using DAL.Contracts;
    using Microsoft.Practices.Unity;

    public class DAOS
    {
        //private static IReportDAO reportDAO;

        static DAOS()
        {
            //reportDAO = ContainerProvider.Container.Resolve<IReportDAO>();
        }

        public static IReportDAO ReportDAO
        {
            get
            {
                return ContainerProvider.Container.Resolve<IReportDAO>();
            }
        }
    }
}
