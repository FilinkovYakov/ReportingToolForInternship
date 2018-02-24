﻿namespace Mirantis.ReportingTool.PL.WebUI.ValidationAttributes
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

    public class AdditionReportValidator
    {
        private static IReportLogic _reportLogic
        {
            get { return UnityConfig.GetConfiguredContainer().Resolve<IReportLogic>(); }
        }

        public static bool IsExistWithSameTitleAndSameDate(ReportVM reportVM)
        {
            SearchReportModel searchVM = new SearchReportModel()
            {
                Title = reportVM.Title,
                DateTo = reportVM.Date,
                DateFrom = reportVM.Date,
                EngineerId = reportVM.EngineerId,
                ManagerId = reportVM.ManagerId
            };

            return _reportLogic.SearchForValidation(searchVM).Any();
        }
    }
}