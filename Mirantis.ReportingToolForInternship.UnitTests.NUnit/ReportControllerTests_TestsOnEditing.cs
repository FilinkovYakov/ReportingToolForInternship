namespace Mirantis.ReportingToolForInternship.UnitTests.NUnit
{
    using BLL.Contracts;
    using Entities;
    using global::NUnit.Framework;
    using Moq;
    using PL.WebUI.Controllers;
    using PL.WebUI.Models;
    using System;
    using System.Web.Mvc;

    [TestFixture]
    public class ReportControllerTests_TestsOnEditing
    {
        [Test]
        public void ReportController_EditingInternsReportInController_ReturnViewResult()
        {
            Guid id = Guid.NewGuid();
            Mock<IReportLogic> mockLogic = new Mock<IReportLogic>();
            mockLogic.Setup(t => t.GetById(id)).Verifiable();

            ReportController reportCrtl = new ReportController(mockLogic.Object, Mock.Of<ICustomLogger>());
            ActionResult result = reportCrtl.EditInternsReport(id);

            Assert.IsNotNull(result);
            Assert.IsAssignableFrom(typeof(ViewResult), result);

            mockLogic.Verify(t => t.GetById(id), Times.Once);
        }

        [Test]
        public void ReportController_EditingMentorsReportInController_ReturnViewResult()
        {
            Guid id = Guid.NewGuid();
            Mock<IReportLogic> mockLogic = new Mock<IReportLogic>();
            mockLogic.Setup(t => t.GetById(id)).Verifiable();

            ReportController reportCrtl = new ReportController(mockLogic.Object, Mock.Of<ICustomLogger>());
            ActionResult result = reportCrtl.EditMentorsReport(id);

            Assert.IsNotNull(result);
            Assert.IsAssignableFrom(typeof(ViewResult), result);

            mockLogic.Verify(t => t.GetById(id), Times.Once);
        }

        [Test]
        public void ReportController_SaveReportAsDraftAfterEditing_ReturnPartiralView()
        {
            Mock<IReportLogic> mockLogic = new Mock<IReportLogic>();
            mockLogic.Setup(t => t.Edit(It.IsAny<Report>())).Verifiable();

            ReportVM correctReportVM = ReportProvider.GetCorrectReportVM();
            ReportController reportCrtl = new ReportController(mockLogic.Object, Mock.Of<ICustomLogger>());

            ActionResult result = reportCrtl.SaveReportAsDraftAfterEditing(correctReportVM);

            Assert.IsNotNull(result);
            Assert.IsAssignableFrom(typeof(PartialViewResult), result);

            mockLogic.Verify(t => t.Edit(It.IsAny<Report>()), Times.Once);
        }

        [Test]
        public void ReportController_ThrowExceptionDuringSavingReportAfterEditing_ReturnHttpStatus()
        {
            Mock<IReportLogic> mockLogic = new Mock<IReportLogic>();
            mockLogic.Setup(t => t.Edit(It.IsAny<Report>())).Throws<Exception>();

            Mock<ICustomLogger> mockLogger = new Mock<ICustomLogger>();
            mockLogger.Setup(t => t.RecordError(It.IsAny<Exception>())).Verifiable();

            ReportVM correctReportVM = ReportProvider.GetCorrectReportVM();
            ReportController reportCrtl = new ReportController(mockLogic.Object, mockLogger.Object);

            ActionResult result = reportCrtl.SaveReportAsDraftAfterEditing(correctReportVM);

            Assert.IsNotNull(result);
            Assert.IsAssignableFrom(typeof(PartialViewResult), result);

            mockLogger.VerifyAll();
        }

        [Test]
        public void ReportController_SubmitReportAfterEditing_ReturnPartiralView()
        {
            Mock<IReportLogic> mockLogic = new Mock<IReportLogic>();
            mockLogic.Setup(t => t.Edit(It.IsAny<Report>())).Verifiable();

            ReportVM correctReportVM = ReportProvider.GetCorrectReportVM();
            ReportController reportCrtl = new ReportController(mockLogic.Object, Mock.Of<ICustomLogger>());

            ActionResult result = reportCrtl.SubmitReportAfterEditing(correctReportVM);

            Assert.IsNotNull(result);
            Assert.IsAssignableFrom(typeof(PartialViewResult), result);

            mockLogic.Verify(t => t.Edit(It.IsAny<Report>()), Times.Once);
        }

        [Test]
        public void ReportController_ThrowExceptionDuringSubmittingReportAfterEditing_ReturnPartialView()
        {
            Mock<IReportLogic> mockLogic = new Mock<IReportLogic>();
            mockLogic.Setup(t => t.Edit(It.IsAny<Report>())).Throws<Exception>();

            Mock<ICustomLogger> mockLogger = new Mock<ICustomLogger>();
            mockLogger.Setup(t => t.RecordError(It.IsAny<Exception>())).Verifiable();

            ReportVM correctReportVM = ReportProvider.GetCorrectReportVM();
            ReportController reportCrtl = new ReportController(mockLogic.Object, mockLogger.Object);

            ActionResult result = reportCrtl.SubmitReportAfterEditing(correctReportVM);

            Assert.IsNotNull(result);
            Assert.IsAssignableFrom(typeof(PartialViewResult), result);

            mockLogger.VerifyAll();
        }
    }
}
