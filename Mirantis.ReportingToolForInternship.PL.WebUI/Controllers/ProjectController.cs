﻿namespace Mirantis.ReportingTool.PL.WebUI.Controllers
{
	using AutoMapper;
	using Mirantis.ReportingTool.BLL.Contracts;
	using Mirantis.ReportingTool.Entities;
	using Mirantis.ReportingTool.PL.WebUI.AuthorizeAttributes;
	using Mirantis.ReportingTool.PL.WebUI.Constants;
	using Mirantis.ReportingTool.PL.WebUI.Filters;
	using Mirantis.ReportingTool.PL.WebUI.Models;
	using System;
	using System.Collections.Generic;
	using System.Web.Mvc;

	[LogActionFilter]
	[ErrorHandler]
	public class ProjectController : Controller
	{
		private readonly IProjectLogic _projectLogic;
		private readonly ICustomLogger _customLogger;
		private readonly IMapper _mapper;

		public ProjectController(IProjectLogic projectLogic, ICustomLogger customLogger, IMapper mapper)
		{
			_projectLogic = projectLogic ?? throw new ArgumentNullException(nameof(projectLogic));
			_customLogger = customLogger ?? throw new ArgumentNullException(nameof(customLogger));
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		[CustomAuthorize]
		public ActionResult GetAllProjects()
		{
			try
			{
				var projects = _mapper.Map<IList<ProjectVM>>(_projectLogic.GetAll());
				return View(projects);
			}
			catch (Exception e)
			{
				_customLogger.RecordError(e);
				return new HttpStatusCodeResult(500);
			}
		}

		[CustomAuthorize(Roles = AppRoles.Manager)]
		public ActionResult AddProject()
		{
			return View();
		}

		[CustomAuthorize(Roles = AppRoles.Manager)]
		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult AddProject(ProjectVM projectVM)
		{
			if (!ModelState.IsValid)
			{
				return View(projectVM);
			}

			var project = _mapper.Map<Project>(projectVM);
			_projectLogic.Add(project);
			return Json(Url.Action("GetAllProjects"));
		}

		[CustomAuthorize(Roles = AppRoles.Manager)]
		public ActionResult EditProject(Guid id)
		{
			var project = _projectLogic.GetById(id);
			if (project == null)
			{
				return HttpNotFound();
			}
			var projectVM = _mapper.Map<ProjectVM>(_projectLogic.GetById(id));
			return View(projectVM);
		}

		[CustomAuthorize(Roles = AppRoles.Manager)]
		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult EditProject(ProjectVM projectVM)
		{
			if (!ModelState.IsValid)
			{
				return View(projectVM);
			}

			if (projectVM.Id == null)
			{
				return HttpNotFound();
			}

			var project = _projectLogic.GetById(projectVM.Id.Value);
			if (project == null)
			{
				return HttpNotFound();
			}

			project = _mapper.Map<Project>(projectVM);
			_projectLogic.Edit(project);
			return Json(Url.Action("GetAllProjects"));
		}

		[CustomAuthorize]
		public ActionResult Details(Guid id)
		{
			ProjectVM projectVM = _mapper.Map<ProjectVM>(_projectLogic.GetById(id));
			if (projectVM == null)
			{
				return new HttpStatusCodeResult(404);
			}

			return View(projectVM);
		}

		[CustomAuthorize(Roles = AppRoles.Manager)]
		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult DeleteProject(Guid id)
		{
			_projectLogic.Delete(id);
			return Json(Url.Action("GetAllProjects"));
		}
	}
}
