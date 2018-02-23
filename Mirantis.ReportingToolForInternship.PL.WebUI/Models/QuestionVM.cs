﻿namespace Mirantis.ReportingTool.PL.WebUI.Models
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
        public Guid? Id { get; set; }

        public Guid ActivityId { get; set; }

        public string Description { get; set; }
    }
}