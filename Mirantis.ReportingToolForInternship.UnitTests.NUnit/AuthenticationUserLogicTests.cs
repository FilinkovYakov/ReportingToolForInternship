namespace Mirantis.ReportingTool.UnitTests.NUnit
{
    using BLL.Contracts;
    using BLL.Core;
    using DAL.Contracts;
    using Entities;
    using global::NUnit.Framework;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    class AuthenticationUserLogicTests
    {
        [Test]
        public void AuthenticationLogic_TryAuthenticateExistingUserWithCorrectPassword_ReturnUser()
        {
            string login = "login";
            string password = "password";
            Mock<IAuthenticationUserDAO> authUserDAO = new Mock<IAuthenticationUserDAO>();
            authUserDAO.Setup(t => t.TryAuthentication(login, password))
                .Returns(new User() { Login = login }).Verifiable();

            AuthenticationUserLogic authUserLogic = new AuthenticationUserLogic(authUserDAO.Object, Mock.Of<ICustomLogger>());

            User resultUser = authUserLogic.TryAuthentication(login, password);

            Assert.AreEqual(resultUser.Login, login);

            authUserDAO.VerifyAll();
        }
    }
}
