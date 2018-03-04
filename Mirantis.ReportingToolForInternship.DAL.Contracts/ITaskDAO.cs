namespace Mirantis.ReportingTool.DAL.Contracts
{
    using Entities;
    using System;
    using System.Collections.Generic;

    public interface ITaskDAO
    {
        void Add(Task task);
		void Edit(Task task);
		void Delete(Guid id);
		IList<Task> GetByUserId(Guid userId);
		IList<Task> Search(SearchTaskModel searchModel);
		Task GetById(Guid id);
    }
}
