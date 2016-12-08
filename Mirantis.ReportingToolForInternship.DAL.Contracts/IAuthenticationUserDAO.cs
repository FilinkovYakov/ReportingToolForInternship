namespace Mirantis.ReportingToolForInternship.DAL.Contracts
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IAuthenticationUserDAO
    {
        IList<Role> GetRolesByUsersLogin(string login);
        bool TryAuthentication(string login, string password);
    }
}
