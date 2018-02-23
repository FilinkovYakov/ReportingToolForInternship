namespace Mirantis.ReportingTool.UnitTests.NUnit
{
    using DAL.Contracts;
    using DAL.DataAccess;
    using Entities;
    using global::NUnit.Framework;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class UserCacheTests
    {
        [Test]
        public void GetByIdGotDataFromCache()
        {
            const int userId = 1;
            Mock<IUserCache> userCacheMock = new Mock<IUserCache>();
            userCacheMock.Setup(x => x.GetUserById(userId))
                .Returns(new User())
                .Verifiable();

            Mock<IUserDAO> userDaoMock = new Mock<IUserDAO>();
            userDaoMock.Setup(x => x.GetById(userId))
                .Verifiable();

            IUserDAO userDao = new CachedUserDAO(userDaoMock.Object, userCacheMock.Object);
            User user = userDao.GetById(userId);
            Assert.That(user, Is.Not.Null);
            userCacheMock.Verify(x => x.GetUserById(userId), Times.Once);
            userDaoMock.Verify(x => x.GetById(userId), Times.Never);
        }

        [Test]
        public void GetByIdGotDataFromDao()
        {
            const int userId = 1;
            User user = new User();
            Mock<IUserCache> userCacheMock = new Mock<IUserCache>();
            userCacheMock.Setup(x => x.GetUserById(userId))
                .Verifiable();
            Mock<IUserDAO> userDaoMock = new Mock<IUserDAO>();
            userDaoMock.Setup(x => x.GetById(userId))
                .Returns(user)
                .Verifiable();
            userCacheMock.Setup(x => x.Set(user))
                .Verifiable();

            IUserDAO userDao = new CachedUserDAO(userDaoMock.Object, userCacheMock.Object);
            User result = userDao.GetById(userId);
            Assert.That(result, Is.Not.Null);
            userCacheMock.Verify(x => x.GetUserById(userId), Times.Once);
            userDaoMock.Verify(x => x.GetById(userId), Times.Once);
            userCacheMock.Verify(x => x.Set(user), Times.Once);
        }

        [Test]
        public void GetByRoleGotDataFromCache()
        {
            const string usersRole = "Mentor";
            Mock<IUserCache> userCacheMock = new Mock<IUserCache>();
            userCacheMock.Setup(x => x.GetUsersByRole(usersRole))
                .Returns(new List<User> {
                    new User()
                })
                .Verifiable();

            Mock<IUserDAO> userDaoMock = new Mock<IUserDAO>();
            userDaoMock.Setup(x => x.GetUsersByRole(usersRole))
                .Verifiable();

            IUserDAO userDao = new CachedUserDAO(userDaoMock.Object, userCacheMock.Object);
            IList<User> users = userDao.GetUsersByRole(usersRole);
            Assert.That(users, Is.Not.Null);
            userCacheMock.Verify(x => x.GetUsersByRole(usersRole), Times.Once);
            userDaoMock.Verify(x => x.GetUsersByRole(usersRole), Times.Never);
        }

        [Test]
        public void GetByRoleGotDataFromDao()
        {
            const string usersRole = "Mentor";
            IList<User> users = new List<User>();
            Mock<IUserDAO> userDaoMock = new Mock<IUserDAO>();
            Mock<IUserCache> userCacheMock = new Mock<IUserCache>();
            userCacheMock.Setup(x => x.GetUsersByRole(usersRole))
                .Verifiable();
            userDaoMock.Setup(x => x.GetUsersByRole(usersRole))
                .Returns(users)
                .Verifiable();
            userCacheMock.Setup(x => x.Set(usersRole, users))
                .Verifiable();
            IUserDAO userDao = new CachedUserDAO(userDaoMock.Object, userCacheMock.Object);
            IList<User> result = userDao.GetUsersByRole(usersRole);
            Assert.That(result, Is.Not.Null);
            userCacheMock.Verify(x => x.GetUsersByRole(usersRole), Times.Once);
            userDaoMock.Verify(x => x.GetUsersByRole(usersRole), Times.Once);
            userCacheMock.Verify(x => x.Set(usersRole, result), Times.Once);
        }
    }
}
