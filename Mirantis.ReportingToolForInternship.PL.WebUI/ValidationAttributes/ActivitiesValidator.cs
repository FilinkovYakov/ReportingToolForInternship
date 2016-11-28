namespace Mirantis.ReportingToolForInternship.PL.WebUI.ValidationAttributes
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class ActivitiesValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            List<ActivityVM> activities = value as List<ActivityVM>;
            if (activities == null)
            {
                ErrorMessage = "None activities";
                return false;
            }

            if (activities.Count == 0)
            {
                ErrorMessage = "None activities";
                return false;
            }

            foreach (var activity in activities)
            {
                if (!(string.IsNullOrEmpty(activity.Description) || string.IsNullOrWhiteSpace(activity.Description)))
                {
                    return true;
                }
            }

            ErrorMessage = "Fill at least one activity";
            return false;
        }
    }
}