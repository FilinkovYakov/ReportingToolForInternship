namespace Mirantis.ReportingToolForInternship.DAL.DataAccessCache
{
    using Contracts;
    using Entities;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UserCache : IUserCache
    {
        private readonly IDictionary<int, Tuple<User, DateTime>> _userLookup = 
            new ConcurrentDictionary<int, Tuple<User, DateTime>>();
        private readonly IDictionary<string, Tuple<ISet<User>, DateTime>> _userByRoleLookup = 
            new ConcurrentDictionary<string, Tuple<ISet<User>, DateTime>>();
        private readonly TimeSpan _timeout;

        public UserCache()
        {
            _timeout =
           TimeSpan.FromMinutes(int.Parse(ConfigurationManager.AppSettings["TimeToLiveObjectInCacheInMinutes"]));
        }

        public User GetUserById(int id)
        {
            //if (id == null)
            //    throw new ArgumentNullException("id");
            Tuple<User, DateTime> value;
            if (_userLookup.TryGetValue(id, out value) && value.Item2 >= DateTime.UtcNow)
            {
                return value.Item1;
            }
            return null;
        }

        public IEnumerable<User> GetUsersByRole(string role)
        {
            if (role == null)
                throw new ArgumentNullException("role");

            Tuple<ISet<User>, DateTime> value;
            if (_userByRoleLookup.TryGetValue(role, out value) && value.Item2 >= DateTime.UtcNow)
            {
                return value.Item1;
            }
            return null;
        }

        public void Set(string role, IEnumerable<User> users)
        {
            if (role == null)
                throw new ArgumentNullException("role");
            if (users == null)
                throw new ArgumentNullException("users");
            DateTime ttl = DateTime.UtcNow.Add(_timeout);
            _userByRoleLookup[role] = new Tuple<ISet<User>, DateTime>(
                new HashSet<User>(users, UserEqualityComparer.Instance),
                ttl);
            foreach (User u in users)
            {
                _userLookup[u.Id] = new Tuple<User, DateTime>(u, ttl);
            }
        }

        public void Set(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            DateTime ttl = DateTime.UtcNow.Add(_timeout);
            Tuple<ISet<User>, DateTime> value;
            _userLookup[user.Id] = new Tuple<User, DateTime>(user, ttl);
            if (_userByRoleLookup.TryGetValue(user.Roles.FirstOrDefault().RoleName, out value))
            {
                value.Item1.Remove(user);
                value.Item1.Add(user);
            }
        }

        private sealed class UserEqualityComparer : IEqualityComparer<User>
        {
            internal static UserEqualityComparer Instance = new UserEqualityComparer();

            public bool Equals(User x, User y)
            {
                if (ReferenceEquals(x, y))
                    return true;
                if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                    return false;

                return x.Id == y.Id;
            }

            public int GetHashCode(User obj)
            {
                return obj == null ? 0 : obj.Id;
            }
        }
    }
}
