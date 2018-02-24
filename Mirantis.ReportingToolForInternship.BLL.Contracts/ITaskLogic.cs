namespace Mirantis.ReportingTool.BLL.Contracts
{
	using Mirantis.ReportingTool.Entities;
	using System;
	using System.Collections.Generic;

	public interface ITaskLogic
	{
		void Add(Task task);
		IList<Task> Search(SearchTaskModel searchModel);
		Task GetById(Guid id);
		void Edit(Task task);
	}
}
