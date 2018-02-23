namespace Mirantis.ReportingTool.PL.WebUI.ValidationAttributes
{
    using Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ActivityValidator : ValidationAttribute
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
                if (activity.Questions == null)
                {
                    continue;
                }
                else if (string.IsNullOrEmpty(activity.Description) && GetAmountNotEmptyQuestions(activity.Questions) > 0)
                {
                    ErrorMessage = "There are activity with empty discription but with filled questions. Please, fill activity's description or remove it";
                    return false;
                }
            }

            return true;
        }

        //LINQ
        private int GetAmountNotEmptyQuestions(List<QuestionVM> questions)
        {
            int amount = 0;
            foreach (var question in questions)
            {
                if (!string.IsNullOrEmpty(question.Description))
                {
                    amount++;
                }
            }

            return amount;
        }
    }
}