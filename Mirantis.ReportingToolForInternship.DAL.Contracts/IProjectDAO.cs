namespace Mirantis.ReportingTool.DAL.Contracts
{
    using Entities;
    using System;
    using System.Collections.Generic;

    public interface IProjectDAO
    {
        void Add(Project project);
		void Edit(Project project);
		void Delete(Guid id);
		Project GetById(Guid id);
		IList<Project> GetAll();
	}
}
