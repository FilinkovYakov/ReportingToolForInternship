﻿namespace Mirantis.ReportingToolForInternship.PL.WebUI.Controllers
{
    using Models.Repositories;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Entities;
    using BLL.Core;
    using BLL.Contracts;

    public class ReportController : Controller
    {
        private readonly IReportLogic _reportLogic;
        public ReportController(IReportLogic reportLogic)
        {
            _reportLogic = reportLogic;
        }
        public ActionResult AddMentorsReport()
        {
            try
            {
                return View();
            }
            catch(Exception e)
            {
                LoggerProvider.Logger.Error(e);
                return new HttpStatusCodeResult(500);
            }
        }

        public ActionResult AddInternsReport()
        {
            try
            {
                return View();
            }
            catch(Exception e)
            {
                LoggerProvider.Logger.Error(e);
                return new HttpStatusCodeResult(500);
            }
        }

        [HttpPost]
        public ActionResult AddReportAsDraftAfterAddition(ReportVM reportVM)
        {
            try
            {
                reportVM.IsDraft = true;

                if (ModelState.IsValid)
                {
                    _reportLogic.Add((Report)reportVM);
                    return PartialView("_SuccessSaveReportAsDraftAfterAddition");
                }

                return View(reportVM);
            }
            catch (Exception e)
            {
                LoggerProvider.Logger.Error(e);
                return new HttpStatusCodeResult(500);
            }
        }

        [HttpPost]
        public ActionResult SubmitReportAfterAddition(ReportVM reportVM)
        {
            try
            {
                reportVM.IsDraft = false;

                if (ModelState.IsValid)
                {
                    _reportLogic.Add((Report)reportVM);
                    return PartialView("_SuccessSubmitReport");
                }

                return View(reportVM);
            }
            catch (Exception e)
            {
                LoggerProvider.Logger.Error(e);
                return new HttpStatusCodeResult(500);
            }
        }

        public ActionResult EditInternsReport(Guid id)
        {
            try
            {
                ReportVM reportVM = (ReportVM)_reportLogic.GetById(id);
                return View(reportVM);
            }
            catch (Exception e)
            {
                LoggerProvider.Logger.Error(e);
                return new HttpStatusCodeResult(500);
            }
        }

        public ActionResult EditMentorsReport(Guid id)
        {
            try
            {
                ReportVM reportVM = (ReportVM)_reportLogic.GetById(id);
                return View(reportVM);
            }
            catch (Exception e)
            {
                LoggerProvider.Logger.Error(e);
                return new HttpStatusCodeResult(500);
            }
        }

        [HttpPost]
        public ActionResult SaveReportAsDraftAfterEditing(ReportVM reportVM)
        {
            try
            {
                reportVM.IsDraft = true;

                if (ModelState.IsValid)
                {
                    _reportLogic.Edit((Report)reportVM);
                    return PartialView("_SuccessSaveReportAsDraftAfterEditing");
                }

                return View(reportVM);
            }
            catch (Exception e)
            {
                LoggerProvider.Logger.Error(e);
                return new HttpStatusCodeResult(500);
            }
        }

        [HttpPost]
        public ActionResult SubmitReportAfterEditing(ReportVM reportVM)
        {
            try
            {
                reportVM.IsDraft = false;

                if (ModelState.IsValid)
                {
                    _reportLogic.Edit((Report)reportVM);
                    return PartialView("_SuccessSubmitReport");
                }

                return View(reportVM);
            }
            catch (Exception e)
            {
                LoggerProvider.Logger.Error(e);
                return new HttpStatusCodeResult(500);
            }
        }

        public ActionResult Search()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                LoggerProvider.Logger.Error(e);
                return new HttpStatusCodeResult(500);
            }
        }

        public ActionResult ShowSearchResult(SearchVM searchVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IEnumerable<ReportVM> reports = _reportLogic.Search((SearchModel)searchVM).Select(report => (ReportVM)report);
                    if (reports.Any())
                    {
                        return PartialView("_ShowSearchResult", reports);
                    }

                    return PartialView("_ShowNullSearchResult");
                }

                return View("Search", searchVM);
            }
            catch (Exception e)
            {
                LoggerProvider.Logger.Error(e);
                return new HttpStatusCodeResult(500);
            }
        }
    }
}