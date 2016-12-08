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
    using BLL.Contracts;
    using System.Threading;
    using AutoMapper;

    public class ReportController : Controller
    {
        private readonly IReportLogic _reportLogic;
        private readonly ICustomLogger _customLogger;

        public ReportController(IReportLogic reportLogic, ICustomLogger customLogger)
        {
            _reportLogic = reportLogic;
            _customLogger = customLogger;
        }

        [Authorize(Roles = "Mentor")]
        public ActionResult AddMentorsReport()
        {
            try
            {
                return View();
            }
            catch(Exception e)
            {
                _customLogger.RecordError(e);
                return new HttpStatusCodeResult(500);
            }
        }

        [Authorize(Roles = "Intern")]
        public ActionResult AddInternsReport()
        {
            try
            {
                return View();
            }
            catch(Exception e)
            {
                _customLogger.RecordError(e);
                return new HttpStatusCodeResult(500);
            }
        }

        [Authorize(Roles = "Mentor,Intern")]
        [HttpPost]
        public ActionResult SaveReportAsDraftAfterAddition(ReportVM reportVM)
        {
            try
            {
                reportVM.IsDraft = true;

                if (ModelState.IsValid)
                {
                    _reportLogic.Add(Mapper.Map<Report>(reportVM));
                    return PartialView("_SuccessSaveReportAsDraftAfterAddition");
                }

                return View(reportVM);
            }
            catch (Exception e)
            {
                _customLogger.RecordError(e);
                return PartialView("_ShowFailedResult");
            }
        }

        [Authorize(Roles = "Mentor,Intern")]
        [HttpPost]
        public ActionResult SubmitReportAfterAddition(ReportVM reportVM)
        {
            try
            {
                reportVM.IsDraft = false;

                if (ModelState.IsValid)
                {
                    _reportLogic.Add(Mapper.Map<Report>(reportVM));
                    return PartialView("_SuccessSubmitReport");
                }

                return View(reportVM);
            }
            catch (Exception e)
            {
                _customLogger.RecordError(e);
                return PartialView("_ShowFailedResult");
            }
        }

        [Authorize(Roles = "Intern")]
        public ActionResult EditInternsReport(Guid id)
        {
            try
            {
                ReportVM reportVM = Mapper.Map<ReportVM>(_reportLogic.GetById(id));
                return View(reportVM);
            }
            catch (Exception e)
            {
                _customLogger.RecordError(e);
                return new HttpStatusCodeResult(500);
            }
        }

        [Authorize(Roles = "Mentor")]
        public ActionResult EditMentorsReport(Guid id)
        {
            try
            {
                ReportVM reportVM = Mapper.Map<ReportVM>(_reportLogic.GetById(id));
                return View(reportVM);
            }
            catch (Exception e)
            {
                _customLogger.RecordError(e);
                return new HttpStatusCodeResult(500);
            }
        }

        [Authorize(Roles = "Mentor,Intern")]
        [HttpPost]
        public ActionResult SaveReportAsDraftAfterEditing(ReportVM reportVM)
        {
            try
            {
                reportVM.IsDraft = true;

                if (ModelState.IsValid)
                {
                    _reportLogic.Edit(Mapper.Map<Report>(reportVM));
                    return PartialView("_SuccessSaveReportAsDraftAfterEditing");
                }

                return View(reportVM);
            }
            catch (Exception e)
            {
                _customLogger.RecordError(e);
                return PartialView("_ShowFailedResult");
            }
        }

        [Authorize(Roles = "Mentor,Intern")]
        [HttpPost]
        public ActionResult SubmitReportAfterEditing(ReportVM reportVM)
        {
            try
            {
                reportVM.IsDraft = false;

                if (ModelState.IsValid)
                {
                    _reportLogic.Edit(Mapper.Map<Report>(reportVM));
                    return PartialView("_SuccessSubmitReport");
                }

                return View(reportVM);
            }
            catch (Exception e)
            {
                _customLogger.RecordError(e);
                return PartialView("_ShowFailedResult");
            }
        }

        [AllowAnonymous]
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

        [AllowAnonymous]
        public ActionResult ShowSearchResult(SearchVM searchVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IEnumerable<ReportVM> reports = _reportLogic.Search(Mapper.Map<SearchModel>(searchVM))
                        .Select(report => Mapper.Map<ReportVM>(report));
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
                _customLogger.RecordError(e);
                return PartialView("_ShowFailedResult");
            }
        }

        [Authorize]
        public ActionResult DetailsInternsReport(Guid id)
        {
            try
            {
                ReportVM reportVM = Mapper.Map<ReportVM>(_reportLogic.GetById(id));
                return View(reportVM);
            }
            catch (Exception e)
            {
                _customLogger.RecordError(e);
                return new HttpStatusCodeResult(500);
            }
        }

        [Authorize]
        public ActionResult DetailsMentorsReport(Guid id)
        {
            try
            {
                ReportVM reportVM = Mapper.Map<ReportVM>(_reportLogic.GetById(id));
                return View(reportVM);
            }
            catch (Exception e)
            {
                _customLogger.RecordError(e);
                return new HttpStatusCodeResult(500);
            }
        }
    }
}