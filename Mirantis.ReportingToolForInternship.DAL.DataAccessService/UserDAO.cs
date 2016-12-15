namespace Mirantis.ReportingToolForInternship.DAL.DataAccessService
{
    using Contracts;
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
                AuthenticationService.User user = client.GetAll().FirstOrDefault(authUser => authUser.Id == id);
                return ServiceMapper.Mapper.Map<Entities.User>(user);
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
                        users.Add(ServiceMapper.Mapper.Map<Entities.User>(authUser));
                    }
                }
            }

            return users;
        }
    }
}
