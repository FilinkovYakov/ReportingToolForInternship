namespace Mirantis.ReportingTool.PL.WebUI.Models
{
	using Entities;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Security.Principal;

	public class UserPrincipal : IPrincipal
    {
        private IList<Role> _roles;
        private Guid _id;
        private IIdentity _identity;

        public UserPrincipal(Guid id, IList<Role> roles)
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