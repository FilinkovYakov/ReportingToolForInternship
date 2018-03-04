namespace Mirantis.ReportingTool.BLL.Contracts
{
	using Mirantis.ReportingTool.Entities;
	using System;
	using System.Collections.Generic;

	public interface IProjectLogic
	{
		void Add(Project project);
		void Edit(Project project);
		void Delete(Guid id);
		Project GetById(Guid id);
		IList<Project> GetAll();
	}
}
