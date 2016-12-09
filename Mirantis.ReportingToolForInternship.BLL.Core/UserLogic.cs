namespace Mirantis.ReportingToolForInternship.BLL.Core
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Entities;

    public class UserLogic : IUserLogic
    {
        public bool Add(User user)
        {
            //local db
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            //local db + service
            throw new NotImplementedException();
        }

        public IList<User> GetUsersByRole(string role)
        {
            //service?
            throw new NotImplementedException();
        }
    }
}
