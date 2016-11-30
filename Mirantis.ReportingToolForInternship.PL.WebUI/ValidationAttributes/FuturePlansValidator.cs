namespace Mirantis.ReportingToolForInternship.PL.WebUI.ValidationAttributes
{
    using Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class FuturePlansValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            List<FuturePlanVM> futurePlans = value as List<FuturePlanVM>;
            if (futurePlans == null)
            {
                ErrorMessage = "Future plans missing";
                return false;
            }

            if (futurePlans.Count == 0)
            {
                ErrorMessage = "Future plans missing";
                return false;
            }

            foreach (var futurePlan in futurePlans)
            {
                if (!(string.IsNullOrEmpty(futurePlan.Description) || string.IsNullOrWhiteSpace(futurePlan.Description)))
                {
                    return true;
                }
            }

            ErrorMessage = "Fill at least one future plan";
            return false;
        }
    }
}