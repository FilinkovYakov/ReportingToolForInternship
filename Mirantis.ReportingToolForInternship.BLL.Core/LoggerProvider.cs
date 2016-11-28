namespace Mirantis.ReportingToolForInternship.BLL.Core
{
    using log4net;

    public class LoggerProvider
    {
        private static ILog logger;

        static LoggerProvider()
        {
            logger = LogManager.GetLogger("CustomLogger");
        }

        public static ILog Logger
        {
            get { return logger; }
        }
    }
}
