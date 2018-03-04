namespace Mirantis.ReportingTool.DAL.Contracts
{
    using Entities;
    using System;
    using System.Collections.Generic;

    public interface ITaskDAO
    {
        void Add(Task task);
		IList<Task> GetByUserId(Guid userId);
		IList<Task> Search(SearchTaskModel searchModel);
		Task GetById(Guid id);
        void Edit(Task task);
    }
}
