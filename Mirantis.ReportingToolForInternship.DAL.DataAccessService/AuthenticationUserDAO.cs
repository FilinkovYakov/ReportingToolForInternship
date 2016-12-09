namespace Mirantis.ReportingToolForInternship.DAL.DataAccessService
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AuthenticationService;

    class AuthenticationUserDAO : IAuthenticationUserDAO
    {
        public IList<Entities.Role> GetRolesByUsersLogin(string login)
        {
            IList<Entities.Role> roles = null;

            using (var client = new AuthenticationServiceClient())
            {
                User user = client.SearchUser(login, "", "").First();

                if (user == null)
                {
                    throw new ArgumentException("User with current login doesn't exist");
                }

                if (user.Roles != null && user.Roles.Any())
                {
                    roles = new List<Entities.Role>();
                    foreach (var item in user.Roles)
                    {
                        roles.Add(AutoMapper.Mapper.Map<Entities.Role>(item));
                    }
                }
            }

            return roles;
        }

        public bool TryAuthentication(string login, string password)
        {
            using (var client = new AuthenticationServiceClient())
            {
                OperationResult qwe = client.AuthorizationUser(login, password);
                if (qwe.Errors == null || qwe.Errors.Any())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
