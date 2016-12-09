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
        User GetById(int id);
        IList<User> GetUsersByRole(string role);
    }
}
