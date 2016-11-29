namespace Mirantis.ReportingToolForInternship.PL.WebUI.Controllers
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

    public class ReportController : Controller
    {
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
                    DataProvider.ReportLogic.Add((Report)reportVM);
                    return PartialView("_SuccessSaveReportAsDraft");
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
                    DataProvider.ReportLogic.Add((Report)reportVM);
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
                ReportVM reportVM = (ReportVM)DataProvider.ReportLogic.GetById(id);
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
                ReportVM reportVM = (ReportVM)DataProvider.ReportLogic.GetById(id);
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
                    DataProvider.ReportLogic.Edit((Report)reportVM);
                    return PartialView("_SuccessRemainedReport");
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
                    DataProvider.ReportLogic.Edit((Report)reportVM);
                    return PartialView("_SuccessChangedReportOnFinalVersion");
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
                    IEnumerable<ReportVM> reports = DataProvider.ReportLogic.Search((SearchModel)searchVM).Select(report => (ReportVM)report);
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