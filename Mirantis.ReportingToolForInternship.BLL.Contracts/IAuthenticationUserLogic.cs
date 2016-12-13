namespace Mirantis.ReportingToolForInternship.BLL.Contracts
{
    using Entities;
    using System.Collections.Generic;

    public interface IAuthenticationUserLogic
    {
        User TryAuthentication(string login, string password);
    }
}
