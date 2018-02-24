namespace Mirantis.ReportingTool.DAL.DataAccessService
{
	using Contracts;
	using AuthenticationService;

	class AuthenticationUserDAO : IAuthenticationUserDAO
    {
        public Entities.User TryAuthentication(string login, string password)
        {
            using (var client = new AuthenticationServiceClient())
            {
                OperationResultOfUser result = client.AuthorizationUser(login, password);
                return ServiceMapper.Mapper.Map<Entities.User>(result.Result);
            }
        }
    }
}
