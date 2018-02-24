namespace Mirantis.ReportingTool.BLL.Contracts
{
	using Mirantis.ReportingTool.Entities;
	using System;
	using System.Collections.Generic;

	public interface IProjectLogic
	{
		void Add(Project project);
		Project GetById(Guid id);
		void Edit(Project project);
		IList<Project> GetAll();
	}
}
