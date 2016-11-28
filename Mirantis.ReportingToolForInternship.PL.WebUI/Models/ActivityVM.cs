namespace Mirantis.ReportingToolForInternship.PL.WebUI.Models
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class ActivityVM
    {
        [Key]
        public Guid? Id { get; set; }

        public Guid ReportId { get; set; }

        public string Description { get; set; }

        public string Evaluation { get; set; }

        public List<QuestionVM> Questions { get; set; }

        public static explicit operator Activity(ActivityVM activityVM)
        {
            return new Activity()
            {
                Id = activityVM.Id ?? (new Guid()),
                ReportId = activityVM.ReportId,
                Description = activityVM.Description,
                Evaluation = activityVM.Evaluation,
                Questions = activityVM.Questions?.Select(questionVM => (Question)questionVM).ToList()
            };
        }

        public static explicit operator ActivityVM(Activity activity)
        {
            return new ActivityVM()
            {
                Id = activity.Id,
                ReportId = activity.ReportId,
                Description = activity.Description,
                Evaluation = activity.Evaluation,
                Questions = activity.Questions?.Select(question => (QuestionVM)question).ToList()
            };
        }
    }
}