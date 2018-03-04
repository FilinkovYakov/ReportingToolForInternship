namespace Mirantis.ReportingTool.DAL.DataAccess
{
	using Mirantis.ReportingTool.DAL.Contracts;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Entities;

	public class CachedUserDAO : IUserDAO
    {
        private readonly IUserDAO _userDao;
        private readonly IUserCache _cache;

        public CachedUserDAO(IUserDAO userDao, IUserCache cache)
        {
			_userDao = userDao ?? throw new ArgumentNullException(nameof(userDao));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

		public IList<User> GetAll()
		{
			return _userDao.GetAll();
		}

		public User GetById(Guid id)
        {
            User user = _cache.GetUserById(id);
            if (user == null)
            {
                user = _userDao.GetById(id);
                _cache.Set(user);
            }

            return user;
        }

        public IList<User> GetUsersByRole(string role)
        {
            if (role == null)
                throw new ArgumentNullException("role");
            IEnumerable<User> users = _cache.GetUsersByRole(role);
            if (users == null)
            {
                users = _userDao.GetUsersByRole(role);
                _cache.Set(role, users);
            }

            return users.ToList();
        }
    }
}
