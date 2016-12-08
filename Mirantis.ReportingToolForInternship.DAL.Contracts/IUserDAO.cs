namespace Mirantis.ReportingToolForInternship.DAL.Contracts
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IUserDAO
    {
        bool Add(User user);
        User GetById(int id);
        List<User> GetUsersByRole(string role);
    }
}
