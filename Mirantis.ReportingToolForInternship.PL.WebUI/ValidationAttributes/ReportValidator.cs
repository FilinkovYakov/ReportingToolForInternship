namespace Mirantis.ReportingToolForInternship.PL.WebUI.ValidationAttributes
{
    using App_Start;
    using BLL.Contracts;
    using Entities;
    using Microsoft.Practices.Unity;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class ReportValidator : ValidationAttribute
    {
        public IReportLogic _ReportLogic
        {
            get { return UnityConfig.GetConfiguredContainer().Resolve<IReportLogic>("StandartReportLogic"); }
        }

        public override bool IsValid(object value)
        {
            ReportVM report = value as ReportVM;
            if (report == null)
            {
                ErrorMessage = "Report is incorrect";
                return false;
            }

            SearchModel searchVM = new SearchModel()
            {
                Title = report.Title,
                DateTo = report.Date,
                DateFrom = report.Date
            };

            if (_ReportLogic.Search(searchVM).Any())
            {
                ErrorMessage = "Report shouldn't contain same title as form other report with same date";
                return false;
            }

            return true;
        }
    }
}