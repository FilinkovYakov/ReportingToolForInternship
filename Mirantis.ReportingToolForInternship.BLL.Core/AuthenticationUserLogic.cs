namespace Mirantis.ReportingToolForInternship.BLL.Core
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Entities;

    public class AuthenticationUserLogic : IAuthenticationUserLogic
    {
        public IList<Role> GetRolesByUsersLogin(string login)
        {
            //service
            throw new NotImplementedException();
        }

        public bool IsRoleValid(string role)
        {
            //service
            throw new NotImplementedException();
        }

        public bool TryAuthentication(string login, string password)
        {
            //service
            throw new NotImplementedException();
        }
    }
}
