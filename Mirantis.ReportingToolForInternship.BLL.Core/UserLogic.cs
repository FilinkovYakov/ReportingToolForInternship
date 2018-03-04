namespace Mirantis.ReportingTool.BLL.Core
{
	using Contracts;
	using System;
	using System.Collections.Generic;
	using Entities;
	using DAL.Contracts;

	public class UserLogic : IUserLogic
    {
        private readonly IUserDAO _userDAO;
        private readonly ICustomLogger _customLogger;

        public UserLogic(IUserDAO userDAO, ICustomLogger customLogger)
        {
			_userDAO = userDAO ?? throw new ArgumentNullException(nameof(userDAO));
            _customLogger = customLogger ?? throw new ArgumentNullException(nameof(customLogger));
        }

		public IList<User> GetAll()
		{
			try
			{
				return _userDAO.GetAll();
			}
			catch (Exception e)
			{
				_customLogger.RecordError(e);
				throw;
			}
		}

		public User GetById(Guid? id)
        {
            try
            {
                if (id.HasValue)
                {
					Guid valueId = id.Value;
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
