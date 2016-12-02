namespace Mirantis.ReportingToolForInternship.BLL.Core
{
    using System;
    using log4net;
    using Contracts;
    using System.IO;

    public class CustomLogger : ICustomLogger
    {
        private ILog logger;

        static CustomLogger()
        {
            string pathToConfig = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Web.config");
            log4net.Config.XmlConfigurator.Configure(new FileInfo(pathToConfig));
        }

        public CustomLogger()
        {
            logger = LogManager.GetLogger("CustomLogger");
        }

        public void RecordError(Exception e)
        {
            logger.Error(e);
        }
    }
}
