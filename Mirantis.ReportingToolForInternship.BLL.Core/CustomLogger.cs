namespace Mirantis.ReportingTool.BLL.Core
{
	using System;
	using log4net;
	using Contracts;
	using System.IO;
	using System.Threading;

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
			logger.Error($"[{Thread.CurrentThread.ManagedThreadId}]:{e.Message}:{e.StackTrace}");
		}

		public void RecordInfo(string info)
		{
			logger.Info($"[{Thread.CurrentThread.ManagedThreadId}]:{info}");
		}
	}
}
