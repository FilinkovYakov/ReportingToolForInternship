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
        private int _id;
        private IIdentity _identity;

        public UserPrincipal(int id, IList<Role> roles)
        {
            _id = id;
            _roles = roles;
            _identity = new GenericIdentity(_id.ToString());
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