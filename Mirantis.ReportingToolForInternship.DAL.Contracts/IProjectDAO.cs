namespace Mirantis.ReportingTool.DAL.Contracts
{
    using Entities;
    using System;
    using System.Collections.Generic;

    public interface IProjectDAO
    {
        void Add(Project project);
		Project GetById(Guid id);
        void Edit(Project project);
		IList<Project> GetAll();
	}
}
