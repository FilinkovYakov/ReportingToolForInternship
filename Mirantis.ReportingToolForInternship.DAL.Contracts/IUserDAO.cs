namespace Mirantis.ReportingTool.DAL.Contracts
{
	using Entities;
	using System;
	using System.Collections.Generic;

	public interface IUserDAO
    {
        User GetById(Guid id);
        IList<User> GetUsersByRole(string role);
		IList<User> GetAll();
    }
}
