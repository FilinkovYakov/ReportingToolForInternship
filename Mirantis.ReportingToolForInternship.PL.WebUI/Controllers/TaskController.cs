namespace Mirantis.ReportingTool.PL.WebUI.Controllers
{
	using AutoMapper;
	using Mirantis.ReportingTool.BLL.Contracts;
	using Mirantis.ReportingTool.Entities;
	using Mirantis.ReportingTool.PL.WebUI.AuthorizeAttributes;
	using Mirantis.ReportingTool.PL.WebUI.Constants;
	using Mirantis.ReportingTool.PL.WebUI.Models;
	using Mirantis.ReportingTool.PL.WebUI.Models.Repositories;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web.Mvc;

	public class TaskController : Controller
	{
		private readonly ITaskLogic _taskLogic;
		private readonly ICustomLogger _customLogger;
		private readonly IMapper _mapper;

		public TaskController(ITaskLogic taskLogic, IProjectLogic projectLogic, IUserLogic userLogic, IMapper mapper, ICustomLogger customLogger)
		{
			_taskLogic = taskLogic ?? throw new ArgumentNullException(nameof(taskLogic));
			_customLogger = customLogger ?? throw new ArgumentNullException(nameof(customLogger));
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

			ProjectLogicProvider.ProjectLogic = projectLogic;
			UserLogicProvider.UserLogic = userLogic;
		}

		[CustomAuthorize]
		public ActionResult Search()
		{
			try
			{
				return View();
			}
			catch (Exception e)
			{
				_customLogger.RecordError(e);
				return new HttpStatusCodeResult(500);
			}
		}

		[CustomAuthorize]
		public ActionResult ShowSearchResult(SearchTaskVM searchVM)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return PartialView("_ShowNullSearchResult");
				}

				IList<TaskVM> reports = _taskLogic.Search(_mapper.Map<SearchTaskModel>(searchVM))
					.Select(report => _mapper.Map<TaskVM>(report)).ToList();

				if (reports != null && reports.Any())
				{
					return PartialView("_ShowSearchResult", reports);
				}

				return PartialView("_ShowNullSearchResult");
			}
			catch (Exception e)
			{
				_customLogger.RecordError(e);
				return PartialView("_ShowFailedResult");
			}
		}

		[CustomAuthorize(Roles = AppRoles.Manager)]
		public ActionResult AddTask()
		{
			return View();
		}

		[CustomAuthorize(Roles = AppRoles.Manager)]
		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult AddTask(TaskVM taskVM)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var task = _mapper.Map<Task>(taskVM);
					Guid reporterId = Guid.Parse(User.Identity.Name);
					task.ReporterId = reporterId;
					_taskLogic.Add(task);
					return RedirectToAction("Search");
				}

				return View();
			}
			catch (Exception e)
			{
				_customLogger.RecordError(e);
				return new HttpStatusCodeResult(500);
			}
		}

		[CustomAuthorize(Roles = AppRoles.Manager)]
		public ActionResult EditTask(Guid id)
		{
			try
			{
				var task = _taskLogic.GetById(id);
				if (task == null)
				{
					return HttpNotFound();
				}
				var taskVM = _mapper.Map<TaskVM>(task);
				return View(taskVM);
			}
			catch (Exception e)
			{
				_customLogger.RecordError(e);
				return new HttpStatusCodeResult(500);
			}
		}

		[CustomAuthorize(Roles = AppRoles.Manager)]
		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult EditTask(TaskVM taskVM)
		{
			try
			{
				if (taskVM.Id == null)
				{
					return HttpNotFound();
				}

				var task = _taskLogic.GetById(taskVM.Id.Value);
				if (task == null)
				{
					return HttpNotFound();
				}

				task = _mapper.Map<Task>(taskVM);
				_taskLogic.Edit(task);
				return RedirectToAction("Search");
			}
			catch (Exception e)
			{
				_customLogger.RecordError(e);
				return new HttpStatusCodeResult(500);
			}
		}

		[CustomAuthorize]
		public ActionResult Details(Guid id)
		{
			try
			{
				TaskVM taskVM = _mapper.Map<TaskVM>(_taskLogic.GetById(id));
				if (taskVM == null)
				{
					return new HttpStatusCodeResult(404);
				}

				return View(taskVM);
			}
			catch (Exception e)
			{
				_customLogger.RecordError(e);
				return new HttpStatusCodeResult(500);
			}
		}

		[CustomAuthorize(Roles = AppRoles.Manager)]
		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult DeleteTask(Guid id)
		{
			try
			{
				_taskLogic.Delete(id);
				return RedirectToAction("Search");
			}
			catch (Exception e)
			{
				_customLogger.RecordError(e);
				return new HttpStatusCodeResult(500);
			}
		}
	}
}
