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

    public class ReportController : Controller
    {
        public ActionResult AddMentorsReport()
        {
            return View();
        }

        public ActionResult AddInternsReport()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddReportAsDraft(ReportVM reportVM)
        {
            reportVM.IsDraft = true;

            if (ModelState.IsValid)
            {
                DataProvider.ReportLogic.Add((Report)reportVM);
                return PartialView("_SuccessSaveReportAsDraft");
            }

            return View(reportVM);
        }

        [HttpPost]
        public ActionResult SubmitReport(ReportVM reportVM)
        {
            reportVM.IsDraft = false;

            if (ModelState.IsValid)
            {
                DataProvider.ReportLogic.Add((Report)reportVM);
                return PartialView("_SuccessSubmitReport");
            }

            return View(reportVM);
        }

        public ActionResult EditInternReport(Guid id)
        {
            ReportVM reportVM = (ReportVM)DataProvider.ReportLogic.GetById(id);
            return View(reportVM);
        }

        [HttpPost]
        public ActionResult RemainReportAsDraft(ReportVM reportVM)
        {
            reportVM.IsDraft = true;

            if (ModelState.IsValid)
            {
                DataProvider.ReportLogic.Edit((Report)reportVM);
                return PartialView("_SuccessRemainedReport");
            }

            return View(reportVM);
        }

        [HttpPost]
        public ActionResult ChangeReportOnFinalVersion(ReportVM reportVM)
        {
            reportVM.IsDraft = false;

            if (ModelState.IsValid)
            {
                DataProvider.ReportLogic.Edit((Report)reportVM);
                return PartialView("_SuccessChangedReportOnFinalVersion");
            }

            return View(reportVM);
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult ShowSearchResult(SearchVM searchVM)
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
    }
}