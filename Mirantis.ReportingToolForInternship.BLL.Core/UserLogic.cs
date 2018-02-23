namespace Mirantis.ReportingTool.BLL.Core
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Entities;
    using DAL.Contracts;

    public class UserLogic : IUserLogic
    {
        private readonly IUserDAO _userDAO;
        private readonly ICustomLogger _customLogger;

        public UserLogic(IUserDAO userDAO, ICustomLogger customLogger)
        {
            if (userDAO == null)
                throw new ArgumentNullException("userDAO");
            if (customLogger == null)
                throw new ArgumentNullException("logger");

            _userDAO = userDAO;
            _customLogger = customLogger;
        }

        public User GetById(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    int valueId = id.Value;
                    return _userDAO.GetById(valueId);
                }

                return null;
            }
            catch (Exception e)
            {
                _customLogger.RecordError(e);
                throw;
            }
        }

        public IList<User> GetUsersByRole(string role)
        {
            try
            {
                return _userDAO.GetUsersByRole(role);
            }
            catch (Exception e)
            {
                _customLogger.RecordError(e);
                throw;
            }
        }
    }
}
