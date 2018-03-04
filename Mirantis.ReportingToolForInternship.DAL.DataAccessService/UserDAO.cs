﻿namespace Mirantis.ReportingTool.DAL.DataAccessService
{
	using Contracts;
	using System.Collections.Generic;
	using System.Linq;
	using AuthenticationService;
	using System;

	public class UserDAO : IUserDAO
    {
		public IList<Entities.User> GetAll()
		{
			using (var client = new AuthenticationServiceClient())
			{
				return client.GetAll()
					.Select(user => ServiceMapper.Mapper.Map<Entities.User>(user)).ToList();
			}
		}

		public Entities.User GetById(Guid id)
        {
            using (var client = new AuthenticationServiceClient())
            {
                AuthenticationService.User user = client.GetAll().ToList().First(authUser => authUser.Id == id);
                return ServiceMapper.Mapper.Map<Entities.User>(user);
            }
        }

        public IList<Entities.User> GetUsersByRole(string role)
        {
            IList<Entities.User> users = new List<Entities.User>();
            using (var client = new AuthenticationServiceClient())
            {
                IList<AuthenticationService.User> authUsers = client.SearchUser("", "", role).ToList();
                if (authUsers != null && authUsers.Any())
                {
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
