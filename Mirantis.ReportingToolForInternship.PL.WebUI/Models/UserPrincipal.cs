namespace Mirantis.ReportingToolForInternship.PL.WebUI.Models
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Principal;
    using System.Web;

    public class UserPrincipal : IPrincipal
    {
        private IList<Role> _roles;
        private string _login = string.Empty;
        private IIdentity _identity;

        public UserPrincipal(string login, IList<Role> roles)
        {
            _login = login ?? string.Empty;
            _roles = roles;
            _identity = new GenericIdentity(_login);
        }

        public IIdentity Identity
        {
            get
            {
                return _identity;
            }
        }

        public bool IsInRole(string role)
        {
            return _roles.Any(innerRole => innerRole.RoleName == role);
        }
    }
}