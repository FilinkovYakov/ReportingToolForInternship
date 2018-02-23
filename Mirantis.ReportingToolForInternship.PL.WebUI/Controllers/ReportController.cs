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
    using Automapper;
    using AuthorizeAttributes;
    using Converter;
    using ValidationAttributes;

    public class ReportController : Controller
    {
        private readonly IReportLogic _reportLogic;
        private readonly ICustomLogger _customLogger;
        private readonly IUserLogic _userLogic;

        public ReportController(IReportLogic reportLogic, IUserLogic userLogic, ICustomLogger customLogger)
        {
			_reportLogic = reportLogic ?? throw new ArgumentNullException("report's logic");
            _customLogger = customLogger ?? throw new ArgumentNullException("logger");
            _userLogic = userLogic ?? throw new ArgumentNullException("user's logic");

            UserLogicProvider.UserLogic = userLogic;
        }

        [CustomAuthorize(Roles = "Mentor")]
        public ActionResult AddMentorsReport()
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

        [Authorize(Roles = "Intern")]
        public ActionResult AddInternsReport()
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

        [CustomAuthorize(Roles = "Mentor,Intern")]
        [HttpPost]
        public ActionResult SaveReportAsDraftAfterAddition(ReportVM reportVM)
        {
            try
            {
                if (reportVM.InternsId.HasValue)
                {
                    if (!User.IsInRole("Mentor"))
                    {
                        return new HttpStatusCodeResult(403);
                    }

                    reportVM.MentorsId = int.Parse(User.Identity.Name);
                }
                else
                {
                    if (!User.IsInRole("Intern"))
                    {
                        return new HttpStatusCodeResult(403);
                    }

                    reportVM.InternsId = int.Parse(User.Identity.Name);
                }

                reportVM.IsDraft = true;

                if (AdditionReportValidator.IsExistWithSameTitleAndSameDate(reportVM))
                {
                    ModelState.AddModelError("Title", "Current title already used with current date");
                }

                if (ModelState.IsValid)
                {
                    _reportLogic.Add(PLAutomapper.Mapper.Map<Report>(reportVM));
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

        [CustomAuthorize(Roles = "Mentor,Intern")]
        [HttpPost]
        public ActionResult SubmitReportAfterAddition(ReportVM reportVM)
        {
            try
            {
                if (reportVM.InternsId.HasValue)
                {
                    if (!User.IsInRole("Mentor"))
                    {
                        return new HttpStatusCodeResult(403);
                    }

                    reportVM.MentorsId = int.Parse(User.Identity.Name);
                }
                else
                {
                    if (!User.IsInRole("Intern"))
                    {
                        return new HttpStatusCodeResult(403);
                    }

                    reportVM.InternsId = int.Parse(User.Identity.Name);
                }

                reportVM.IsDraft = false;

                if (AdditionReportValidator.IsExistWithSameTitleAndSameDate(reportVM))
                {
                    ModelState.AddModelError("Title", "Current title already used with current date");
                }

                if (ModelState.IsValid)
                {
                    _reportLogic.Add(PLAutomapper.Mapper.Map<Report>(reportVM));
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

        [CustomAuthorize(Roles = "Intern")]
        public ActionResult EditInternsReport(Guid id)
        {
            try
            {
                ReportVM reportVM = PLAutomapper.Mapper.Map<ReportVM>(_reportLogic.GetById(id));
                if(reportVM.MentorsId.HasValue)
                {
                    return new HttpStatusCodeResult(403);
                }

                int requestersId = int.Parse(User.Identity.Name);
                if (reportVM.InternsId != requestersId)
                {
                    return new HttpStatusCodeResult(403);
                }

                if (!reportVM.IsDraft)
                {
                    return new HttpStatusCodeResult(404);
                }

                return View(reportVM);
            }
            catch (Exception e)
            {
                _customLogger.RecordError(e);
                return new HttpStatusCodeResult(500);
            }
        }

        [CustomAuthorize(Roles = "Mentor")]
        public ActionResult EditMentorsReport(Guid id)
        {
            try
            {
                ReportVM reportVM = PLAutomapper.Mapper.Map<ReportVM>(_reportLogic.GetById(id));
                if (!reportVM.MentorsId.HasValue)
                {
                    return new HttpStatusCodeResult(403);
                }

                int requestersId = int.Parse(User.Identity.Name);
                if (reportVM.MentorsId != requestersId)
                {
                    return new HttpStatusCodeResult(403);
                }

                if (!reportVM.IsDraft)
                {
                    return new HttpStatusCodeResult(404);
                }

                return View(reportVM);
            }
            catch (Exception e)
            {
                _customLogger.RecordError(e);
                return new HttpStatusCodeResult(500);
            }
        }

        [CustomAuthorize(Roles = "Mentor,Intern")]
        [HttpPost]
        public ActionResult SaveReportAsDraftAfterEditing(ReportVM reportVM)
        {
            try
            {
                if (reportVM.MentorsId.HasValue)
                {
                    if (!User.IsInRole("Mentor"))
                    {
                        return new HttpStatusCodeResult(403);
                    }

                    reportVM.MentorsId = int.Parse(User.Identity.Name);
                }
                else
                {
                    if (!User.IsInRole("Intern"))
                    {
                        return new HttpStatusCodeResult(403);
                    }

                    reportVM.InternsId = int.Parse(User.Identity.Name);
                }

                reportVM.IsDraft = true;

                if (EditingReportValidator.IsExistWithSameTitleAndSameDate(reportVM))
                {
                    ModelState.AddModelError("Title", "Current title already used with current date");
                }

                if (ModelState.IsValid)
                {
                    _reportLogic.Edit(PLAutomapper.Mapper.Map<Report>(reportVM));
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

        [CustomAuthorize(Roles = "Mentor,Intern")]
        [HttpPost]
        public ActionResult SubmitReportAfterEditing(ReportVM reportVM)
        {
            try
            {
                if (reportVM.MentorsId.HasValue)
                {
                    if (!User.IsInRole("Mentor"))
                    {
                        return new HttpStatusCodeResult(403);
                    }

                    reportVM.MentorsId = int.Parse(User.Identity.Name);
                }
                else
                {
                    if (!User.IsInRole("Intern"))
                    {
                        return new HttpStatusCodeResult(403);
                    }

                    reportVM.InternsId = int.Parse(User.Identity.Name);
                }

                reportVM.IsDraft = false;

                if (EditingReportValidator.IsExistWithSameTitleAndSameDate(reportVM))
                {
                    ModelState.AddModelError("Title", "Current title already used with current date");
                }

                if (ModelState.IsValid)
                {
                    _reportLogic.Edit(PLAutomapper.Mapper.Map<Report>(reportVM));
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
        public ActionResult ShowSearchResult(SearchVM searchVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int? requesterId = null;
                    if (!string.IsNullOrEmpty(User.Identity.Name))
                    {
                        requesterId = int.Parse(User.Identity.Name);
                    }

                    searchVM.RequesterUserId = requesterId;
                    IList<RepresentingReportVM> reports = _reportLogic.SearchForUser(PLAutomapper.Mapper.Map<SearchModel>(searchVM))
                        ?.Select(report => PLAutomapper.Mapper.Map<RepresentingReportVM>(report)).ToList();
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
        public ActionResult DetailsInternsReport(Guid id)
        {
            try
            {
                RepresentingReportVM reportVM = PLAutomapper.Mapper.Map<RepresentingReportVM>(_reportLogic.GetRepresentReportById(id));
                if (!reportVM.IsInternsReport())
                {
                    return new HttpStatusCodeResult(403);
                }

                int requesterId = int.Parse(User.Identity.Name);
                User requesterUser = _userLogic.GetById(requesterId);
                if (requesterUser.FullName != reportVM.InternsFullName && reportVM.IsDraft)
                {
                    return new HttpStatusCodeResult(403);
                }

                return View(reportVM);
            }
            catch (Exception e)
            {
                _customLogger.RecordError(e);
                return new HttpStatusCodeResult(500);
            }
        }

        [CustomAuthorize]
        public ActionResult DetailsMentorsReport(Guid id)
        {
            try
            {
                RepresentingReportVM reportVM = PLAutomapper.Mapper.Map<RepresentingReportVM>(_reportLogic.GetRepresentReportById(id));
                if (reportVM.IsInternsReport())
                {
                    return new HttpStatusCodeResult(403);
                }

                int requesterId = int.Parse(User.Identity.Name);
                User requesterUser = _userLogic.GetById(requesterId);
                if (requesterUser.FullName != reportVM.MentorsFullName && reportVM.IsDraft)
                {
                    return new HttpStatusCodeResult(403);
                }

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