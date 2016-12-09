namespace Mirantis.ReportingToolForInternship.BLL.Contracts
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IUserLogic
    {
        bool Add(User user);
        User GetById(int id);
        IList<User> GetUsersByRole(string role);
    }
}