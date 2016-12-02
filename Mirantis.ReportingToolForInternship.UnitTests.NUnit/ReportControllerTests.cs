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
    public class ReportControllerTests
    {
        [Test]
        public void ReportController_AddInternsReportToController_ReturnViewResult()
        {
            ReportController reportCrtl = new ReportController(Mock.Of<IReportLogic>(), Mock.Of<ICustomLogger>());
            ActionResult result = reportCrtl.AddInternsReport();

            Assert.IsNotNull(result);
            Assert.IsAssignableFrom(typeof(ViewResult), result);
        }

        [Test]
        public void ReportController_AddReportAsDraft_ReturnPartiralView()
        {
            Mock<IReportLogic> mockLogic = new Mock<IReportLogic>();
            mockLogic.Setup(t => t.Add(It.IsAny<Report>())).Verifiable();

            ReportVM correctReportVM = ReportProvider.GetCorrectReportVM();
            ReportController reportCrtl = new ReportController(mockLogic.Object, Mock.Of<ICustomLogger>());

            ActionResult result = reportCrtl.AddReportAsDraftAfterAddition(correctReportVM);

            Assert.IsNotNull(result);
            Assert.IsAssignableFrom(typeof(PartialViewResult), result);

            mockLogic.Verify(t => t.Add(It.IsAny<Report>()), Times.Once);
        }

        [Test]
        public void ReportController_ThrowExceptionDuringAdditionReport_ReturnHttpStatus()
        {
            Mock<IReportLogic> mockLogic = new Mock<IReportLogic>();
            mockLogic.Setup(t => t.Add(It.IsAny<Report>())).Throws<Exception>();

            Mock<ICustomLogger> mockLogger = new Mock<ICustomLogger>();
            mockLogger.Setup(t => t.RecordError(It.IsAny<Exception>())).Verifiable();

            ReportVM correctReportVM = ReportProvider.GetCorrectReportVM();
            ReportController reportCrtl = new ReportController(mockLogic.Object, mockLogger.Object);

            ActionResult result = reportCrtl.AddReportAsDraftAfterAddition(correctReportVM);

            Assert.IsNotNull(result);
            Assert.IsAssignableFrom(typeof(HttpStatusCodeResult), result);

            mockLogger.VerifyAll();
        }
    }
}
