namespace Mirantis.ReportingToolForInternship.PL.WebUI.Models
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class QuestionVM
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ActivityId { get; set; }

        public string Description { get; set; }

        public static explicit operator Question(QuestionVM questionVM)
        {
            return new Question()
            {
                Id = questionVM.Id,
                ActivityId = questionVM.ActivityId,
                Description = questionVM.Description
            };
        }

        public static explicit operator QuestionVM(Question question)
        {
            return new QuestionVM()
            {
                Id = question.Id,
                ActivityId = question.ActivityId,
                Description = question.Description
            };
        }
    }
}