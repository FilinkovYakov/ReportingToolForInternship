namespace Mirantis.ReportingTool.PL.WebUI.Controllers
{
	using Models.Repositories;
	using Models;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web.Mvc;
	using Entities;
	using BLL.Contracts;
	using AuthorizeAttributes;
	using Converter;
	using ValidationAttributes;
	using Mirantis.ReportingTool.PL.WebUI.Constants;
	using AutoMapper;
	using Mirantis.ReportingTool.PL.WebUI.Filters;

	[LogActionFilter]
	[ErrorHandler]
	public class ReportController : Controller
	{
		private readonly IReportLogic _reportLogic;
		private readonly ICustomLogger _customLogger;
		private readonly IUserLogic _userLogic;
		private readonly IMapper _mapper;

		public ReportController(IReportLogic reportLogic, IUserLogic userLogic, ITaskLogic taskLogic, IMapper mapper, ICustomLogger customLogger)
		{
			_reportLogic = reportLogic ?? throw new ArgumentNullException(nameof(reportLogic));
			_customLogger = customLogger ?? throw new ArgumentNullException(nameof(customLogger));
			_userLogic = userLogic ?? throw new ArgumentNullException(nameof(userLogic));
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

			UserLogicProvider.UserLogic = userLogic;
			TaskLogicProvider.TaskLogic = taskLogic;
		}

		[CustomAuthorize(Roles = AppRoles.Manager)]
		public ActionResult AddManagerReport()
		{
			return View();
		}

		[CustomAuthorize(Roles = AppRoles.Engineer)]
		public ActionResult AddEngineerReport()
		{
			return View();
		}

		[CustomAuthorize(Roles = AppRoles.ManagerOrEngineer)]
		[HttpPost]
		public ActionResult SaveReportAsDraftAfterAddition(ReportVM reportVM)
		{
			try
			{
				if (reportVM.EngineerId.HasValue)
				{
					if (!User.IsInRole(AppRoles.Manager))
					{
						return new HttpStatusCodeResult(403);
					}

					reportVM.ManagerId = Guid.Parse(User.Identity.Name);
				}
				else
				{
					if (!User.IsInRole(AppRoles.Engineer))
					{
						return new HttpStatusCodeResult(403);
					}

					reportVM.EngineerId = Guid.Parse(User.Identity.Name);
				}

				reportVM.IsDraft = true;

				if (AdditionReportValidator.IsExistWithSameTitleAndSameDate(reportVM))
				{
					ModelState.AddModelError("Title", "Current title already used with current date");
				}

				if (ModelState.IsValid)
				{
					_reportLogic.Add(_mapper.Map<Report>(reportVM));
					return PartialView("_SuccessSaveReportAsDraftAfterAddition");
				}

				return PartialView("_ShowValidationErrors", Converter.GetErrorList(ModelState));
			}
			catch (Exception e)
			{
				_customLogger.RecordError(e);
				return PartialView("_ShowFailedResult");
			}
		}

		[CustomAuthorize(Roles = AppRoles.ManagerOrEngineer)]
		[HttpPost]
		public ActionResult SubmitReportAfterAddition(ReportVM reportVM)
		{
			try
			{
				if (reportVM.EngineerId.HasValue)
				{
					if (!User.IsInRole(AppRoles.Manager))
					{
						return new HttpStatusCodeResult(403);
					}

					reportVM.ManagerId = Guid.Parse(User.Identity.Name);
				}
				else
				{
					if (!User.IsInRole(AppRoles.Engineer))
					{
						return new HttpStatusCodeResult(403);
					}

					reportVM.EngineerId = Guid.Parse(User.Identity.Name);
				}

				reportVM.IsDraft = false;

				if (AdditionReportValidator.IsExistWithSameTitleAndSameDate(reportVM))
				{
					ModelState.AddModelError("Title", "Current title already used with current date");
				}

				if (ModelState.IsValid)
				{
					_reportLogic.Add(_mapper.Map<Report>(reportVM));
					return PartialView("_SuccessSubmitReport");
				}

				return PartialView("_ShowValidationErrors", Converter.GetErrorList(ModelState));
			}
			catch (Exception e)
			{
				_customLogger.RecordError(e);
				return PartialView("_ShowFailedResult");
			}
		}

		[CustomAuthorize(Roles = AppRoles.Engineer)]
		public ActionResult EditEngineerReport(Guid id)
		{
			ReportVM reportVM = _mapper.Map<ReportVM>(_reportLogic.GetById(id));
			if (reportVM.ManagerId.HasValue)
			{
				return new HttpStatusCodeResult(403);
			}

			Guid requestersId = Guid.Parse(User.Identity.Name);
			if (reportVM.EngineerId != requestersId)
			{
				return new HttpStatusCodeResult(403);
			}

			if (!reportVM.IsDraft)
			{
				return new HttpStatusCodeResult(404);
			}

			return View(reportVM);
		}

		[CustomAuthorize(Roles = AppRoles.Manager)]
		public ActionResult EditManagerReport(Guid id)
		{
			ReportVM reportVM = _mapper.Map<ReportVM>(_reportLogic.GetById(id));
			if (!reportVM.ManagerId.HasValue)
			{
				return new HttpStatusCodeResult(403);
			}

			Guid requestersId = Guid.Parse(User.Identity.Name);
			if (reportVM.ManagerId != requestersId)
			{
				return new HttpStatusCodeResult(403);
			}

			if (!reportVM.IsDraft)
			{
				return new HttpStatusCodeResult(404);
			}

			return View(reportVM);
		}

		[CustomAuthorize(Roles = AppRoles.ManagerOrEngineer)]
		[HttpPost]
		public ActionResult SaveReportAsDraftAfterEditing(ReportVM reportVM)
		{
			try
			{
				if (reportVM.ManagerId.HasValue)
				{
					if (!User.IsInRole(AppRoles.Manager))
					{
						return new HttpStatusCodeResult(403);
					}

					reportVM.ManagerId = Guid.Parse(User.Identity.Name);
				}
				else
				{
					if (!User.IsInRole(AppRoles.Engineer))
					{
						return new HttpStatusCodeResult(403);
					}

					reportVM.EngineerId = Guid.Parse(User.Identity.Name);
				}

				reportVM.IsDraft = true;

				if (EditingReportValidator.IsExistWithSameTitleAndSameDate(reportVM))
				{
					ModelState.AddModelError("Title", "Current title already used with current date");
				}

				if (ModelState.IsValid)
				{
					_reportLogic.Edit(_mapper.Map<Report>(reportVM));
					return PartialView("_SuccessSaveReportAsDraftAfterEditing");
				}

				return PartialView("_ShowValidationErrors", Converter.GetErrorList(ModelState));
			}
			catch (Exception e)
			{
				_customLogger.RecordError(e);
				return PartialView("_ShowFailedResult");
			}
		}

		[CustomAuthorize(Roles = AppRoles.ManagerOrEngineer)]
		[HttpPost]
		public ActionResult SubmitReportAfterEditing(ReportVM reportVM)
		{
			try
			{
				if (reportVM.ManagerId.HasValue)
				{
					if (!User.IsInRole(AppRoles.Manager))
					{
						return new HttpStatusCodeResult(403);
					}

					reportVM.ManagerId = Guid.Parse(User.Identity.Name);
				}
				else
				{
					if (!User.IsInRole(AppRoles.Engineer))
					{
						return new HttpStatusCodeResult(403);
					}

					reportVM.EngineerId = Guid.Parse(User.Identity.Name);
				}

				reportVM.IsDraft = false;

				if (EditingReportValidator.IsExistWithSameTitleAndSameDate(reportVM))
				{
					ModelState.AddModelError("Title", "Current title already used with current date");
				}

				if (ModelState.IsValid)
				{
					_reportLogic.Edit(_mapper.Map<Report>(reportVM));
					return PartialView("_SuccessSubmitReport");
				}

				return PartialView("_ShowValidationErrors", Converter.GetErrorList(ModelState));
			}
			catch (Exception e)
			{
				_customLogger.RecordError(e);
				return PartialView("_ShowFailedResult");
			}
		}

		[CustomAuthorize]
		public ActionResult Search()
		{
			return View();
		}

		[CustomAuthorize]
		public ActionResult ShowSearchResult(SearchReportVM searchVM)
		{
			try
			{
				if (ModelState.IsValid)
				{
					Guid? requesterId = null;
					if (!string.IsNullOrEmpty(User.Identity.Name))
					{
						requesterId = Guid.Parse(User.Identity.Name);
					}

					searchVM.RequesterUserId = requesterId;
					IList<ReportVM> reports = _reportLogic.SearchForUser(_mapper.Map<SearchReportModel>(searchVM))
						?.Select(report => _mapper.Map<ReportVM>(report)).ToList();
					if (reports != null && reports.Any())
					{
						return PartialView("_ShowSearchResult", reports);
					}

					return PartialView("_ShowNullSearchResult");
				}

				return View("Search", searchVM);
			}
			catch (Exception e)
			{
				_customLogger.RecordError(e);
				return PartialView("_ShowFailedResult");
			}
		}

		[CustomAuthorize]
		public ActionResult DetailsEngineerReport(Guid id)
		{
			ReportVM reportVM = _mapper.Map<ReportVM>(_reportLogic.GetById(id));
			if (!reportVM.IsEngineerReport())
			{
				return new HttpStatusCodeResult(403);
			}

			Guid requesterId = Guid.Parse(User.Identity.Name);
			User requesterUser = _userLogic.GetById(requesterId);
			if (requesterUser.FullName != reportVM.Engineer.FullName && reportVM.IsDraft)
			{
				return new HttpStatusCodeResult(403);
			}

			return View(reportVM);
		}

		[CustomAuthorize]
		public ActionResult DetailsManagerReport(Guid id)
		{
			ReportVM reportVM = _mapper.Map<ReportVM>(_reportLogic.GetById(id));
			if (reportVM.IsEngineerReport())
			{
				return new HttpStatusCodeResult(403);
			}

			Guid requesterId = Guid.Parse(User.Identity.Name);
			User requesterUser = _userLogic.GetById(requesterId);
			if (requesterUser.FullName != reportVM.Manager.FullName && reportVM.IsDraft)
			{
				return new HttpStatusCodeResult(403);
			}

			return View(reportVM);
		}
	}
}