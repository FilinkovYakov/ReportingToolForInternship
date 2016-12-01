namespace Mirantis.ReportingToolForInternship.BLL.Core
{
    using log4net;
    using Microsoft.Practices.Unity;

    public class LoggerProvider
    {
        public static ILog Logger
        {
            get { return ContainerProvider.Container.Resolve<ILog>() ?? LogManager.GetLogger("CustomLogger"); }
        }
    }
}
