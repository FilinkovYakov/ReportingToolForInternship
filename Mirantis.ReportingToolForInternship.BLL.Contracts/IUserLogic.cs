namespace Mirantis.ReportingTool.BLL.Contracts
{
    using Entities;
	using System;
	using System.Collections.Generic;

    public interface IUserLogic
    {
        User GetById(Guid? id);
        IList<User> GetUsersByRole(string role);
		IList<User> GetAll();
    }
}