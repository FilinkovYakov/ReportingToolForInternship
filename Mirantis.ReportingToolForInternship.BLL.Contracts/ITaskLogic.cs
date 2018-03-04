namespace Mirantis.ReportingTool.BLL.Contracts
{
	using Mirantis.ReportingTool.Entities;
	using System;
	using System.Collections.Generic;

	public interface ITaskLogic
	{
		void Add(Task task);
		void Edit(Task task);
		IList<Task> GetByUserId(Guid userId);
		IList<Task> Search(SearchTaskModel searchModel);
		Task GetById(Guid id);
	}
}
