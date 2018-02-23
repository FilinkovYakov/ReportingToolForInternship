namespace Mirantis.ReportingTool.BLL.Core
{
    using Contracts;
    using System;
    using System.Collections.Generic;
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
