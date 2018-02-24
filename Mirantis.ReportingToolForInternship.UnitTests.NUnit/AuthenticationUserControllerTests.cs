namespace Mirantis.ReportingTool.UnitTests.NUnit
{
	using AutoMapper;
	using BLL.Contracts;
    using Entities;
    using global::NUnit.Framework;
    using Moq;
    using PL.WebUI.Controllers;
    using PL.WebUI.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    [TestFixture]
    class AuthenticationUserControllerTests
    {
        [Test]
        public void AuthenticationController_TrySignInUsingUnexistingUser_ReturnSearchPage()
        {
            string login = "login";
            string password = "password";
            AuthenticationUserVM authUser = new AuthenticationUserVM() { Login = login, Password = password };

            Mock<IAuthenticationUserLogic> authLogic = new Mock<IAuthenticationUserLogic>();
            authLogic.Setup(t => t.TryAuthentication(login, password)).Verifiable();

            AuthenticationUserController authController = new AuthenticationUserController(authLogic.Object, Mock.Of<IMapper>(), Mock.Of<ICustomLogger>());
            ActionResult result = authController.SignIn(authUser);

            Assert.IsAssignableFrom<ViewResult>(result);
            authLogic.VerifyAll();
        }
    }
}
