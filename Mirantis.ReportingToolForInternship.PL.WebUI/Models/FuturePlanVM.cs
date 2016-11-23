namespace Mirantis.ReportingToolForInternship.PL.WebUI.Models
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class FuturePlanVM
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ReportId { get; set; }

        public string Description { get; set; }

        public static explicit operator FuturePlan(FuturePlanVM futurePlanVM)
        {
            return new FuturePlan()
            {
                Id = futurePlanVM.Id,
                ReportId = futurePlanVM.ReportId,
                Description = futurePlanVM.Description
            };
        }

        public static explicit operator FuturePlanVM(FuturePlan futurePlan)
        {
            return new FuturePlanVM()
            {
                Id = futurePlan.Id,
                ReportId = futurePlan.ReportId,
                Description = futurePlan.Description
            };
        }
    }
}