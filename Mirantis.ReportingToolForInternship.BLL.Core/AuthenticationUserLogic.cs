namespace Mirantis.ReportingTool.BLL.Core
{
	using Contracts;
	using System;
	using Entities;
	using DAL.Contracts;

	public class AuthenticationUserLogic : IAuthenticationUserLogic
    {
        private readonly IAuthenticationUserDAO _authUserDAO;
        private readonly ICustomLogger _customLogger;

        public AuthenticationUserLogic(IAuthenticationUserDAO authUserDAO, ICustomLogger customLogger)
        {
            _authUserDAO = authUserDAO;
            _customLogger = customLogger;
        }

        public User TryAuthentication(string login, string password)
        {
            try
            {
				_customLogger.RecordInfo($"Authentication user {login} has started");
				return _authUserDAO.TryAuthentication(login, password);
            }
            catch (Exception e)
            {
                _customLogger.RecordError(e);
                throw;
            }
        }
    }
}
