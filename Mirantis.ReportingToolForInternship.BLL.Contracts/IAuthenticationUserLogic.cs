namespace Mirantis.ReportingToolForInternship.BLL.Contracts
{
    using Entities;
    using System.Collections.Generic;

    public interface IAuthenticationUserLogic
    {
        IList<Role> GetRolesByUsersLogin(string login);
        bool TryAuthentication(string login, string password);
    }
}
