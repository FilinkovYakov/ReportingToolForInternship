using Mirantis.ReportingTool.BLL.Contracts;
using Mirantis.ReportingTool.BLL.Core;
using System;
using System.Web.Mvc;

namespace Mirantis.ReportingTool.PL.WebUI.Filters
{
	public class ErrorHandlerAttribute : HandleErrorAttribute
	{
		protected ICustomLogger _logger = new CustomLogger();

		public override void OnException(ExceptionContext context)
		{
			_logger.RecordError(context.Exception);
			context.Result = new HttpStatusCodeResult(500);
		}
	}
}