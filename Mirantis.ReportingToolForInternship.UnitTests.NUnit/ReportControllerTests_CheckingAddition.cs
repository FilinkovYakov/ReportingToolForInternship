namespace Mirantis.ReportingTool.UnitTests.NUnit
{
    using BLL.Contracts;
    using Entities;
    using global::NUnit.Framework;
    using Moq;
    using NUnit;
    using PL.WebUI.Controllers;
    using PL.WebUI.Models;
    using System;
    using System.Web.Mvc;

    [TestFixture]
    public class ReportControllerTests_CheckingAddition
    {
        [Test]
        public void ReportController_AdditionEngineerReportInController_ReturnViewResult()
        {
            ReportController reportCrtl = new ReportController(Mock.Of<IReportLogic>(), Mock.Of<IUserLogic>(), Mock.Of<ICustomLogger>());
            ActionResult result = reportCrtl.AddEngineerReport();

            Assert.IsNotNull(result);
            Assert.IsAssignableFrom(typeof(ViewResult), result);
        }

        [Test]
        public void ReportController_AdditionManagerReportInController_ReturnViewResult()
        {
            ReportController reportCrtl = new ReportController(Mock.Of<IReportLogic>(), Mock.Of<IUserLogic>(), Mock.Of<ICustomLogger>());
            ActionResult result = reportCrtl.AddManagerReport();

            Assert.IsNotNull(result);
            Assert.IsAssignableFrom(typeof(ViewResult), result);
        }

        [Test]
        public void ReportController_ThrowExceptionDuringSavingEngineerReportAfterAddition_ReturnHttpStatus()
        {
            Mock<IReportLogic> mockLogic = new Mock<IReportLogic>();
            mockLogic.Setup(t => t.Add(It.IsAny<Report>())).Throws<Exception>();

            Mock<ICustomLogger> mockLogger = new Mock<ICustomLogger>();
            mockLogger.Setup(t => t.RecordError(It.IsAny<Exception>())).Verifiable();

            ReportVM engineerReportVM = ReportProvider.GetCorrectEngineerReportVM();
            ReportController reportCrtl = new ReportController(mockLogic.Object, Mock.Of<IUserLogic>(), mockLogger.Object);

            ActionResult result = reportCrtl.SaveReportAsDraftAfterAddition(engineerReportVM);

            Assert.IsNotNull(result);
            Assert.IsAssignableFrom(typeof(PartialViewResult), result);

            mockLogger.VerifyAll();
        }

        [Test]
        public void ReportController_ThrowExceptionDuringSubmittingEngineerReportAfterAddition_ReturnPartialView()
        {
            Mock<IReportLogic> mockLogic = new Mock<IReportLogic>();
            mockLogic.Setup(t => t.Add(It.IsAny<Report>())).Throws<Exception>();

            Mock<ICustomLogger> mockLogger = new Mock<ICustomLogger>();
            mockLogger.Setup(t => t.RecordError(It.IsAny<Exception>())).Verifiable();

            ReportVM engineerReportVM = ReportProvider.GetCorrectEngineerReportVM();
            ReportController reportCrtl = new ReportController(mockLogic.Object, Mock.Of<IUserLogic>(), mockLogger.Object);

            ActionResult result = reportCrtl.SubmitReportAfterAddition(engineerReportVM);

            Assert.IsNotNull(result);
            Assert.IsAssignableFrom(typeof(PartialViewResult), result);

            mockLogger.VerifyAll();
        }

        [OneTimeSetUp]
        public void InitializeMapper()
        {
            AutoMapper.Mapper.Initialize(c =>
            {
                c.CreateMap<SearchVM, SearchModel>();
                c.CreateMap<SearchModel, SearchVM>();

                c.CreateMap<QuestionVM, Question>();
                c.CreateMap<Question, QuestionVM>().ForMember(x => x.Id, x => x.NullSubstitute(Guid.Empty));

                c.CreateMap<ActivityVM, Activity>();
                c.CreateMap<Activity, ActivityVM>().ForMember(x => x.Id, x => x.NullSubstitute(Guid.Empty));

                c.CreateMap<FuturePlanVM, FuturePlan>();
                c.CreateMap<FuturePlan, FuturePlanVM>().ForMember(x => x.Id, x => x.NullSubstitute(Guid.Empty));

                c.CreateMap<ReportVM, Report>();
                c.CreateMap<Report, ReportVM>().ForMember(x => x.Id, x => x.NullSubstitute(Guid.Empty));
            });
        }
    }
}
