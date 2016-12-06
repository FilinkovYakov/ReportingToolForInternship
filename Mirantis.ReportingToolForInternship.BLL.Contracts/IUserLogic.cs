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
        void CreateUser(User user, string password);
        IList<User> SearchUser(string login, string fullName, string role);
        IList<User> GetAll();
        void UpdateUser(User user);
        void DeleteUser(User user);
        void AuthorizationUser(string login, string password);
        bool ChangePassword(User user, string password);
        void AddRole(string roleName);
        IEnumerable<Role> GetAllRoles();
    }
}
