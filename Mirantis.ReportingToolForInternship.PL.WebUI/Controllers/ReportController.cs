namespace Mirantis.ReportingToolForInternship.PL.WebUI.Controllers
{
    using Models.Repositories;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class ReportController : Controller
    {
        public ActionResult AddReport()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddReportAsDraft(ReportVM report)
        {
            report.IsDraft = true;

            if (ModelState.IsValid)
            {
                ReportRepo.Repo.Add(report);
                return Json(new { message = "Report successfully got saved as draft" }, JsonRequestBehavior.AllowGet);
            }

            return View(report);
        }

        [HttpPost]
        public ActionResult SubmitReport(ReportVM report)
        {
            report.IsDraft = false;

            if (ModelState.IsValid)
            {
                ReportRepo.Repo.Add(report);
                return Json(new { message = "Report successfully got submitted" }, JsonRequestBehavior.AllowGet);
            }

            return View(report);
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult ShowSearchResult(SearchVM searchVM)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<ReportVM> reports = ReportRepo.Repo
                    .Where(report => report.MentorName == searchVM.MentorName)
                    .Where(report => report.InternName == searchVM.InternName)
                    .Where(report => report.Date > searchVM.DateFrom && report.Date < searchVM.DateTo)
                    .Where(report => report.Type == searchVM.Type)
                    .ToList();
                return PartialView("_ShowSearchResult", reports);
            }

            return View("Search", searchVM);
        }
    }
}