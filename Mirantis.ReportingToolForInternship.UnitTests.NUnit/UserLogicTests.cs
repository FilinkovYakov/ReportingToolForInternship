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
    public class UserLogicTests
    {
        [Test]
        public void UserLogic_GetByIdExistingUser_ReturnUser()
        {
			Guid id = Guid.NewGuid();
            Mock<IUserDAO> userDAO = new Mock<IUserDAO>();
            userDAO.Setup(t => t.GetById(id)).Returns(new User() { Id = id }).Verifiable();
            UserLogic userLogic = new UserLogic(userDAO.Object, Mock.Of<ICustomLogger>());

            User resultUser = userLogic.GetById(id);

            Assert.AreEqual(resultUser.Id, id);
            userDAO.VerifyAll();
        }

        [Test]
        public void UserLogic_GetUsersByRole_ReturnListUsers()
        {

            string role = "Manager";
            IList<User> managers = new List<User>
            {
                    new User() { Id = Guid.NewGuid() },
                    new User() { Id = Guid.NewGuid() }
            };

            Mock<IUserDAO> userDAO = new Mock<IUserDAO>();
            userDAO.Setup(t => t.GetUsersByRole(role)).Returns(managers).Verifiable();

            UserLogic userLogic = new UserLogic(userDAO.Object, Mock.Of<ICustomLogger>());

            IList<User> resultUsers = userLogic.GetUsersByRole(role);

            Assert.AreEqual(resultUsers, managers);
            userDAO.VerifyAll();
        }
    }
}
