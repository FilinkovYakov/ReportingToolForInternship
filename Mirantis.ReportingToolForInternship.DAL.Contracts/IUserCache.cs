namespace Mirantis.ReportingTool.DAL.Contracts
{
	using Entities;
	using System;
	using System.Collections.Generic;

	public interface IUserCache
    {
        IEnumerable<User> GetUsersByRole(string role);
        User GetUserById(Guid id);
        void Set(string role, IEnumerable<User> users);
        void Set(User user);
    }
}
