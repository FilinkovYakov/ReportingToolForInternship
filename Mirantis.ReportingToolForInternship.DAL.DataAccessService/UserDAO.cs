namespace Mirantis.ReportingToolForInternship.DAL.DataAccessService
{
    using Mirantis.ReportingToolForInternship.DAL.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Mirantis.ReportingToolForInternship.Entities;
    using AuthenticationService;

    public class UserDAO : IUserDAO
    {
        public Entities.User GetById(int id)
        {
            using (var client = new AuthenticationServiceClient())
            {
                AuthenticationService.User user = client.GetAll().Where(authUser => authUser.Id == id).FirstOrDefault();
                return AutoMapper.Mapper.Map<Entities.User>(user);
            }
        }

        public IList<Entities.User> GetUsersByRole(string role)
        {
            IList<Entities.User> users = null;
            using (var client = new AuthenticationServiceClient())
            {
                IList<AuthenticationService.User> authUsers = client.SearchUser("", "", role).ToList();
                if (authUsers != null && authUsers.Any())
                {
                    users = new List<Entities.User>();
                    foreach (var authUser in authUsers)
                    {
                        users.Add(AutoMapper.Mapper.Map<Entities.User>(authUser));
                    }
                }
            }

            return users;
        }
    }
}
