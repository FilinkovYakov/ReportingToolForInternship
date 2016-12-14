namespace Mirantis.ReportingToolForInternship.UnitTests.NUnit
{
    using BLL.Contracts;
    using Entities;
    using global::NUnit.Framework;
    using Moq;
    using PL.WebUI.Controllers;
    using PL.WebUI.Models;
    using System;
    using System.Security.Principal;
    using System.Web;
    using System.Web.Mvc;

    [TestFixture]
    public class ReportControllerTests_TestsOnEditing
    {
        [Test]
        public void ReportController_EditingExistingInternsDraftReportInController_ReturnViewResult()
        {
            int userId = 0;
            string[] usersRoles = { "Intern" };

            Guid reportId = new Guid();
            Mock<IReportLogic> mockReportLogic = new Mock<IReportLogic>();
            mockReportLogic.Setup(t => t.GetById(It.IsAny<Guid>()))
                .Returns(new Report() { InternsId = userId, IsDraft = true }).Verifiable();

            ReportController reportCrtl = new ReportController(mockReportLogic.Object, Mock.Of<IUserLogic>(), Mock.Of<ICustomLogger>());
            reportCrtl.ControllerContext = ControllerContextProvider.GetFakeControllerContext(userId, usersRoles).Object;
            ActionResult result = reportCrtl.EditInternsReport(reportId);

            Assert.IsNotNull(result);
            Assert.IsAssignableFrom(typeof(ViewResult), result);

            mockReportLogic.Verify(t => t.GetById(reportId), Times.Once);
        }

        [Test]
        public void ReportController_EditingExistingMentorsDraftReportInController_ReturnViewResult()
        {
            int userId = 0;
            string[] usersRoles = { "Mentor" };

            Guid reportId = Guid.NewGuid();
            Mock<IReportLogic> mockReportLogic = new Mock<IReportLogic>();
            mockReportLogic.Setup(t => t.GetById(It.IsAny<Guid>()))
                .Returns(new Report() { MentorsId = userId, IsDraft = true }).Verifiable();

            ReportController reportCrtl = new ReportController(mockReportLogic.Object, Mock.Of<IUserLogic>(), Mock.Of<ICustomLogger>());
            reportCrtl.ControllerContext = ControllerContextProvider.GetFakeControllerContext(userId, usersRoles).Object;
            ActionResult result = reportCrtl.EditMentorsReport(reportId);

            Assert.IsNotNull(result);
            Assert.IsAssignableFrom(typeof(ViewResult), result);

            mockReportLogic.Verify(t => t.GetById(reportId), Times.Once);
        }

        [Test]
        public void ReportController_SaveMentorsReportAsDraftAfterEditing_ReturnPartiralView()
        {
            int userId = 0;
            string[] usersRoles = { "Mentor" };

            Mock<IReportLogic> mockLogic = new Mock<IReportLogic>();
            mockLogic.Setup(t => t.Edit(It.IsAny<Report>())).Verifiable();

            ReportVM mentorsReportVM = ReportProvider.GetCorrectMentorsReportVM();
            ReportController reportCrtl = new ReportController(mockLogic.Object, Mock.Of<IUserLogic>(), Mock.Of<ICustomLogger>());
            reportCrtl.ControllerContext = ControllerContextProvider.GetFakeControllerContext(userId, usersRoles).Object;

            ActionResult result = reportCrtl.SaveReportAsDraftAfterEditing(mentorsReportVM);

            Assert.IsNotNull(result);
            Assert.IsAssignableFrom(typeof(PartialViewResult), result);

            mockLogic.Verify(t => t.Edit(It.IsAny<Report>()), Times.Once);
        }

        [Test]
        public void ReportController_ThrowExceptionDuringSavingInternsReportAfterEditing_ReturnHttpStatus()
        {
            Mock<IReportLogic> mockLogic = new Mock<IReportLogic>();
            mockLogic.Setup(t => t.Edit(It.IsAny<Report>())).Throws<Exception>();

            Mock<ICustomLogger> mockLogger = new Mock<ICustomLogger>();
            mockLogger.Setup(t => t.RecordError(It.IsAny<Exception>())).Verifiable();

            ReportVM internsReportVM = ReportProvider.GetCorrectInternsReportVM();
            ReportController reportCrtl = new ReportController(mockLogic.Object, Mock.Of<IUserLogic>(), mockLogger.Object);

            ActionResult result = reportCrtl.SaveReportAsDraftAfterEditing(internsReportVM);

            Assert.IsNotNull(result);
            Assert.IsAssignableFrom(typeof(PartialViewResult), result);

            mockLogger.VerifyAll();
        }

        [Test]
        public void ReportController_SubmitMentorsReportAfterEditing_ReturnPartiralView()
        {
            int userId = 0;
            string[] usersRoles = { "Mentor" };

            Mock<IReportLogic> mockLogic = new Mock<IReportLogic>();
            mockLogic.Setup(t => t.Edit(It.IsAny<Report>())).Verifiable();

            ReportVM mentorsReportVM = ReportProvider.GetCorrectMentorsReportVM();
            ReportController reportCrtl = new ReportController(mockLogic.Object, Mock.Of<IUserLogic>(), Mock.Of<ICustomLogger>());
            reportCrtl.ControllerContext = ControllerContextProvider.GetFakeControllerContext(userId, usersRoles).Object;

            ActionResult result = reportCrtl.SubmitReportAfterEditing(mentorsReportVM);

            Assert.IsNotNull(result);
            Assert.IsAssignableFrom(typeof(PartialViewResult), result);

            mockLogic.Verify(t => t.Edit(It.IsAny<Report>()), Times.Once);
        }

        [Test]
        public void ReportController_ThrowExceptionDuringSubmittingInternsReportAfterEditing_ReturnPartialView()
        {
            Mock<IReportLogic> mockLogic = new Mock<IReportLogic>();
            mockLogic.Setup(t => t.Edit(It.IsAny<Report>())).Throws<Exception>();

            Mock<ICustomLogger> mockLogger = new Mock<ICustomLogger>();
            mockLogger.Setup(t => t.RecordError(It.IsAny<Exception>())).Verifiable();

            ReportVM internsReportVM = ReportProvider.GetCorrectInternsReportVM();
            ReportController reportCrtl = new ReportController(mockLogic.Object, Mock.Of<IUserLogic>(), mockLogger.Object);

            ActionResult result = reportCrtl.SubmitReportAfterEditing(internsReportVM);

            Assert.IsNotNull(result);
            Assert.IsAssignableFrom(typeof(PartialViewResult), result);

            mockLogger.VerifyAll();
        }
    }
}
