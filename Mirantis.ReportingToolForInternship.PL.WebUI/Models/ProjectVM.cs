namespace Mirantis.ReportingTool.PL.WebUI.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;

	public class ProjectVM
	{
		[Key]
		public Guid? Id { get; set; }

		[Required(ErrorMessage = "Field 'Name' is required")]
		[MaxLength(300, ErrorMessage = "Name should consist at maximum 300 characters")]
		[Display(Name = "Name :")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Field 'Customer' is required")]
		[MaxLength(200, ErrorMessage = "Name should consist at maximum 200 characters")]
		[Display(Name = "Customer :")]
		public string Customer { get; set; }
	}
}