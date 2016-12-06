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
        public void ReportController_AdditionInternsReportInController_ReturnViewResult()
        {
            ReportController reportCrtl = new ReportController(Mock.Of<IReportLogic>(), Mock.Of<ICustomLogger>());
            ActionResult result = reportCrtl.AddInternsReport();

            Assert.IsNotNull(result);
            Assert.IsAssignableFrom(typeof(ViewResult), result);
        }

        [Test]
        public void ReportController_AdditionMentorsReportInController_ReturnViewResult()
        {
            ReportController reportCrtl = new ReportController(Mock.Of<IReportLogic>(), Mock.Of<ICustomLogger>());
            ActionResult result = reportCrtl.AddMentorsReport();

            Assert.IsNotNull(result);
            Assert.IsAssignableFrom(typeof(ViewResult), result);
        }

        [Test]
        public void ReportController_SaveReportAsDraftAfterAddition_ReturnPartiralView()
        {
            AutoMapper.Mapper.Initialize(c =>
            {
                c.CreateMap<QuestionVM, Question>();
                c.CreateMap<Question, QuestionVM>().ForMember(x => x.Id, x => x.NullSubstitute(Guid.Empty));

                c.CreateMap<ActivityVM, Activity>();
                c.CreateMap<Activity, ActivityVM>().ForMember(x => x.Id, x => x.NullSubstitute(Guid.Empty));

                c.CreateMap<FuturePlanVM, FuturePlan>();
                c.CreateMap<FuturePlan, FuturePlanVM>().ForMember(x => x.Id, x => x.NullSubstitute(Guid.Empty));

                c.CreateMap<ReportVM, Report>();
                c.CreateMap<Report, ReportVM>().ForMember(x => x.Id, x => x.NullSubstitute(Guid.Empty));
            });

            Mock<IReportLogic> mockLogic = new Mock<IReportLogic>();
            mockLogic.Setup(t => t.Add(It.IsAny<Report>())).Verifiable();

            ReportVM correctReportVM = ReportProvider.GetCorrectReportVM();
            ReportController reportCrtl = new ReportController(mockLogic.Object, Mock.Of<ICustomLogger>());

            ActionResult result = reportCrtl.SaveReportAsDraftAfterAddition(correctReportVM);

            Assert.IsNotNull(result);
            Assert.IsAssignableFrom(typeof(PartialViewResult), result);

            mockLogic.Verify(t => t.Add(It.IsAny<Report>()), Times.Once);
        }

        [Test]
        public void ReportController_ThrowExceptionDuringSavingReport_ReturnHttpStatus()
        {
            Mock<IReportLogic> mockLogic = new Mock<IReportLogic>();
            mockLogic.Setup(t => t.Add(It.IsAny<Report>())).Throws<Exception>();

            Mock<ICustomLogger> mockLogger = new Mock<ICustomLogger>();
            mockLogger.Setup(t => t.RecordError(It.IsAny<Exception>())).Verifiable();

            ReportVM correctReportVM = ReportProvider.GetCorrectReportVM();
            ReportController reportCrtl = new ReportController(mockLogic.Object, mockLogger.Object);

            ActionResult result = reportCrtl.SaveReportAsDraftAfterAddition(correctReportVM);

            Assert.IsNotNull(result);
            Assert.IsAssignableFrom(typeof(PartialViewResult), result);

            mockLogger.VerifyAll();
        }

        [Test]
        public void ReportController_SubmitReportAfterAddition_ReturnPartiralView()
        {
            AutoMapper.Mapper.Initialize(c =>
            {
                c.CreateMap<QuestionVM, Question>();
                c.CreateMap<Question, QuestionVM>().ForMember(x => x.Id, x => x.NullSubstitute(Guid.Empty));

                c.CreateMap<ActivityVM, Activity>();
                c.CreateMap<Activity, ActivityVM>().ForMember(x => x.Id, x => x.NullSubstitute(Guid.Empty));

                c.CreateMap<FuturePlanVM, FuturePlan>();
                c.CreateMap<FuturePlan, FuturePlanVM>().ForMember(x => x.Id, x => x.NullSubstitute(Guid.Empty));

                c.CreateMap<ReportVM, Report>();
                c.CreateMap<Report, ReportVM>().ForMember(x => x.Id, x => x.NullSubstitute(Guid.Empty));
            });

            Mock<IReportLogic> mockLogic = new Mock<IReportLogic>();
            mockLogic.Setup(t => t.Add(It.IsAny<Report>())).Verifiable();

            ReportVM correctReportVM = ReportProvider.GetCorrectReportVM();
            ReportController reportCrtl = new ReportController(mockLogic.Object, Mock.Of<ICustomLogger>());

            ActionResult result = reportCrtl.SubmitReportAfterAddition(correctReportVM);

            Assert.IsNotNull(result);
            Assert.IsAssignableFrom(typeof(PartialViewResult), result);

            mockLogic.Verify(t => t.Add(It.IsAny<Report>()), Times.Once);
        }

        [Test]
        public void ReportController_ThrowExceptionDuringSubmittingReport_ReturnPartialView()
        {
            Mock<IReportLogic> mockLogic = new Mock<IReportLogic>();
            mockLogic.Setup(t => t.Add(It.IsAny<Report>())).Throws<Exception>();

            Mock<ICustomLogger> mockLogger = new Mock<ICustomLogger>();
            mockLogger.Setup(t => t.RecordError(It.IsAny<Exception>())).Verifiable();

            ReportVM correctReportVM = ReportProvider.GetCorrectReportVM();
            ReportController reportCrtl = new ReportController(mockLogic.Object, mockLogger.Object);

            ActionResult result = reportCrtl.SubmitReportAfterAddition(correctReportVM);

            Assert.IsNotNull(result);
            Assert.IsAssignableFrom(typeof(PartialViewResult), result);

            mockLogger.VerifyAll();
        }
    }
}
