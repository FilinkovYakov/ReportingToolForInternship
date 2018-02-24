namespace Mirantis.ReportingTool.BLL.Contracts
{
    using Entities;
    using System.Collections.Generic;

    public interface IUserLogic
    {
        User GetById(int? id);
        IList<User> GetUsersByRole(string role);
		IList<User> GetAll();
    }
}