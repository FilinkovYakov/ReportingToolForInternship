namespace Mirantis.ReportingToolForInternship.BLL.Contracts
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IAuthenticationUserLogic
    {
        IList<Role> GetRolesByUsersLogin(string login);
        bool TryAuthentication(string login, string password);
        bool IsRoleValid(string role);
    }
}
