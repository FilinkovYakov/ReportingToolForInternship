﻿namespace Mirantis.ReportingTool.PL.WebUI.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;

	public class SearchTaskVM
    {
		[Display(Name = "Project :")]
		public Guid? ProjectId { get; set; }

		[Display(Name = "Title :")]
        public string Title { get; set; }

        [Display(Name = "Reporter :")]
        public Guid? ReporterId { get; set; }

        [Display(Name = "Assignee :")]
        public Guid? AssigneeId { get; set; }

        [Display(Name = "Status :")]
		public string Status { get; set; }
	}
}