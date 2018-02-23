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
            int id = 1;
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

            string role = "Mentor";
            IList<User> mentors = new List<User>
            {
                    new User() { Id = 1 },
                    new User() { Id = 2 }
            };

            Mock<IUserDAO> userDAO = new Mock<IUserDAO>();
            userDAO.Setup(t => t.GetUsersByRole(role)).Returns(mentors).Verifiable();

            UserLogic userLogic = new UserLogic(userDAO.Object, Mock.Of<ICustomLogger>());

            IList<User> resultUsers = userLogic.GetUsersByRole(role);

            Assert.AreEqual(resultUsers, mentors);
            userDAO.VerifyAll();
        }
    }
}
