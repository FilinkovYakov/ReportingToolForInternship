namespace Mirantis.ReportingToolForInternship.UnitTests.NUnit
{
    using BLL.Contracts;
    using BLL.Core;
    using DAL.Contracts;
    using Entities;
    using global::NUnit.Framework;
    using Microsoft.Practices.Unity;
    using Moq;
    using PL.WebUI.Controllers;
    using PL.WebUI.Models;
    using System.Web.Mvc;

    [TestFixture]
    public class ReportControllerTests
    {
        [Test]
        public void ReportController_AddInternsReportToController_ReturnViewResult()
        {
            ReportController reportCrtl = new ReportController(Mock.Of<IReportLogic>());
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
            ReportController reportCrtl = new ReportController(mockLogic.Object);

            ActionResult result = reportCrtl.AddReportAsDraftAfterAddition(correctReportVM);

            Assert.IsNotNull(result);
            Assert.IsAssignableFrom(typeof(PartialViewResult), result);

            mockLogic.VerifyAll();
        }
    }
}
