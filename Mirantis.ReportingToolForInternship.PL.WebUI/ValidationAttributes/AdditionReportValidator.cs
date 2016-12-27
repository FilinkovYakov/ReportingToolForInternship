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

    public class AdditionReportValidator
    {
        private static IReportLogic _reportLogic
        {
            get { return UnityConfig.GetConfiguredContainer().Resolve<IReportLogic>(); }
        }

        public static bool IsExistWithSameTitleAndSameDate(ReportVM reportVM)
        {
            SearchModel searchVM = new SearchModel()
            {
                Title = reportVM.Title,
                DateTo = reportVM.Date,
                DateFrom = reportVM.Date,
                InternsId = reportVM.InternsId,
                MentorsId = reportVM.MentorsId
            };

            return _reportLogic.SearchForValidation(searchVM).Any();
        }
    }
}