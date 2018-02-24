namespace Mirantis.ReportingTool.DAL.Contracts
{
	using Entities;
	using System.Collections.Generic;

	public interface IUserDAO
    {
        User GetById(int id);
        IList<User> GetUsersByRole(string role);
		IList<User> GetAll();
    }
}
