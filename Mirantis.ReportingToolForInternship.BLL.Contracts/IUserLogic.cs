namespace Mirantis.ReportingToolForInternship.BLL.Contracts
{
    using Entities;
    using System.Collections.Generic;

    public interface IUserLogic
    {
        User GetById(int? id);
        User GetByLogin(string login);
        IList<User> GetUsersByRole(string role);
    }
}