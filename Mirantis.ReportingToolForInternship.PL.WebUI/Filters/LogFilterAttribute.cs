using Mirantis.ReportingTool.BLL.Contracts;
using Mirantis.ReportingTool.BLL.Core;
using System;
using System.Web.Mvc;

namespace Mirantis.ReportingTool.PL.WebUI.Filters
{
	public class LogActionFilterAttribute : ActionFilterAttribute
	{
		private ICustomLogger _logger = new CustomLogger();

		public override void OnActionExecuting(ActionExecutingContext context)
		{
			Log("Begin", context);
		}

		/// <inheritdoc />
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			Log("End", context, context.Exception);
		}

		private void Log(string stepName, ControllerContext context, Exception exception = null)
		{
			var controllerName = context.RouteData.Values["controller"];
			var actionName = context.RouteData.Values["action"];
			var user = context.HttpContext.User.Identity.Name ?? "Anonymous user";

			if (exception == null)
			{
				var message = $"{stepName} action:{actionName} on controller:{controllerName}. User: {user}";
				_logger.RecordInfo(message);
			}
			else
			{
				var message = $"{stepName} action:{actionName} on controller:{controllerName} with exception(s) . User: {user}";
				_logger.RecordError(message, exception);
			}
		}
	}
}