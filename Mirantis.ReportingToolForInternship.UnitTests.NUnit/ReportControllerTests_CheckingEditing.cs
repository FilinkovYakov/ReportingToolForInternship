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
    using System.Security.Principal;
    using System.Web;
    using System.Web.Mvc;

    [TestFixture]
    public class ReportControllerTests_CheckingEditing
    {
        [Test]
        public void ReportController_EditingExistingEngineerDraftReportInController_ReturnViewResult()
        {
			Guid userId = Guid.NewGuid();
            string[] usersRoles = { "Engineer" };

            Guid reportId = new Guid();
            Mock<IReportLogic> mockReportLogic = new Mock<IReportLogic>();
            mockReportLogic.Setup(t => t.GetById(It.IsAny<Guid>()))
                .Returns(new Report() { EngineerId = userId, IsDraft = true }).Verifiable();

            ReportController reportCrtl = new ReportController(mockReportLogic.Object, Mock.Of<IUserLogic>(), Mock.Of<ITaskLogic>(), Mock.Of<IMapper>(), Mock.Of<ICustomLogger>());
            reportCrtl.ControllerContext = ControllerContextProvider.GetFakeControllerContext(userId, usersRoles).Object;
            ActionResult result = reportCrtl.EditEngineerReport(reportId);

            Assert.IsNotNull(result);
            Assert.IsAssignableFrom(typeof(ViewResult), result);

            mockReportLogic.Verify(t => t.GetById(reportId), Times.Once);
        }

        [Test]
        public void ReportController_EditingExistingManagerDraftReportInController_ReturnViewResult()
        {
            Guid userId = Guid.NewGuid();
            string[] usersRoles = { "Manager" };

            Guid reportId = Guid.NewGuid();
            Mock<IReportLogic> mockReportLogic = new Mock<IReportLogic>();
            mockReportLogic.Setup(t => t.GetById(It.IsAny<Guid>()))
                .Returns(new Report() { ManagerId = userId, IsDraft = true }).Verifiable();

            ReportController reportCrtl = new ReportController(mockReportLogic.Object, Mock.Of<IUserLogic>(), Mock.Of<ITaskLogic>(), Mock.Of<IMapper>(), Mock.Of<ICustomLogger>());
            reportCrtl.ControllerContext = ControllerContextProvider.GetFakeControllerContext(userId, usersRoles).Object;
            ActionResult result = reportCrtl.EditManagerReport(reportId);

            Assert.IsNotNull(result);
            Assert.IsAssignableFrom(typeof(ViewResult), result);

            mockReportLogic.Verify(t => t.GetById(reportId), Times.Once);
        }

        [Test]
        public void ReportController_ThrowExceptionDuringSavingEngineerReportAfterEditing_ReturnHttpStatus()
        {
            Mock<IReportLogic> mockLogic = new Mock<IReportLogic>();
            mockLogic.Setup(t => t.Edit(It.IsAny<Report>())).Throws<Exception>();

            Mock<ICustomLogger> mockLogger = new Mock<ICustomLogger>();
            mockLogger.Setup(t => t.RecordError(It.IsAny<Exception>())).Verifiable();

            ReportVM engineerReportVM = ReportProvider.GetCorrectEngineerReportVM();
            ReportController reportCrtl = new ReportController(mockLogic.Object, Mock.Of<IUserLogic>(), Mock.Of<ITaskLogic>(), Mock.Of<IMapper>(), mockLogger.Object);

            ActionResult result = reportCrtl.SaveReportAsDraftAfterEditing(engineerReportVM);

            Assert.IsNotNull(result);
            Assert.IsAssignableFrom(typeof(PartialViewResult), result);

            mockLogger.VerifyAll();
        }

        [Test]
        public void ReportController_ThrowExceptionDuringSubmittingEngineerReportAfterEditing_ReturnPartialView()
        {
            Mock<IReportLogic> mockLogic = new Mock<IReportLogic>();
            mockLogic.Setup(t => t.Edit(It.IsAny<Report>())).Throws<Exception>();

            Mock<ICustomLogger> mockLogger = new Mock<ICustomLogger>();
            mockLogger.Setup(t => t.RecordError(It.IsAny<Exception>())).Verifiable();

            ReportVM engineerReportVM = ReportProvider.GetCorrectEngineerReportVM();
            ReportController reportCrtl = new ReportController(mockLogic.Object, Mock.Of<IUserLogic>(), Mock.Of<ITaskLogic>(), Mock.Of<IMapper>(), mockLogger.Object);

            ActionResult result = reportCrtl.SubmitReportAfterEditing(engineerReportVM);

            Assert.IsNotNull(result);
            Assert.IsAssignableFrom(typeof(PartialViewResult), result);

            mockLogger.VerifyAll();
        }
    }
}
