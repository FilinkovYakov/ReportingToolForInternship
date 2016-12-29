namespace Mirantis.ReportingToolForInternship.UnitTests.NUnit
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
        public void ReportController_AdditionInternsReportInController_ReturnViewResult()
        {
            ReportController reportCrtl = new ReportController(Mock.Of<IReportLogic>(), Mock.Of<IUserLogic>(), Mock.Of<ICustomLogger>());
            ActionResult result = reportCrtl.AddInternsReport();

            Assert.IsNotNull(result);
            Assert.IsAssignableFrom(typeof(ViewResult), result);
        }

        [Test]
        public void ReportController_AdditionMentorsReportInController_ReturnViewResult()
        {
            ReportController reportCrtl = new ReportController(Mock.Of<IReportLogic>(), Mock.Of<IUserLogic>(), Mock.Of<ICustomLogger>());
            ActionResult result = reportCrtl.AddMentorsReport();

            Assert.IsNotNull(result);
            Assert.IsAssignableFrom(typeof(ViewResult), result);
        }

        //[Test]
        //public void ReportController_SaveMentorsReportAsDraftAfterAddition_ReturnPartiralView()
        //{
        //    int userId = 0;
        //    string[] usersRoles = { "Mentor" };

        //    Mock<IReportLogic> mockLogic = new Mock<IReportLogic>();
        //    mockLogic.Setup(t => t.Add(It.IsAny<Report>())).Verifiable();

        //    ReportVM mentorsReportVM = ReportProvider.GetCorrectMentorsReportVM();
        //    ReportController reportCtrl = new ReportController(mockLogic.Object, Mock.Of<IUserLogic>(), Mock.Of<ICustomLogger>());
        //    reportCtrl.ControllerContext = ControllerContextProvider.GetFakeControllerContext(userId, usersRoles).Object;

        //    ActionResult result = reportCtrl.SaveReportAsDraftAfterAddition(mentorsReportVM);

        //    Assert.IsNotNull(result);
        //    Assert.IsAssignableFrom(typeof(PartialViewResult), result);

        //    mockLogic.Verify(t => t.Add(It.IsAny<Report>()), Times.Once);
        //}

        [Test]
        public void ReportController_ThrowExceptionDuringSavingInternsReportAfterAddition_ReturnHttpStatus()
        {
            Mock<IReportLogic> mockLogic = new Mock<IReportLogic>();
            mockLogic.Setup(t => t.Add(It.IsAny<Report>())).Throws<Exception>();

            Mock<ICustomLogger> mockLogger = new Mock<ICustomLogger>();
            mockLogger.Setup(t => t.RecordError(It.IsAny<Exception>())).Verifiable();

            ReportVM internsReportVM = ReportProvider.GetCorrectInternsReportVM();
            ReportController reportCrtl = new ReportController(mockLogic.Object, Mock.Of<IUserLogic>(), mockLogger.Object);

            ActionResult result = reportCrtl.SaveReportAsDraftAfterAddition(internsReportVM);

            Assert.IsNotNull(result);
            Assert.IsAssignableFrom(typeof(PartialViewResult), result);

            mockLogger.VerifyAll();
        }

        //[Test]
        //public void ReportController_SubmitMentorsReportAfterAddition_ReturnPartiralView()
        //{
        //    int userId = 0;
        //    string[] usersRoles = { "Mentor" };

        //    Mock<IReportLogic> mockLogic = new Mock<IReportLogic>();
        //    mockLogic.Setup(t => t.Add(It.IsAny<Report>())).Verifiable();

        //    ReportVM mentorsReportVM = ReportProvider.GetCorrectMentorsReportVM();
        //    ReportController reportCrtl = new ReportController(mockLogic.Object, Mock.Of<IUserLogic>(), Mock.Of<ICustomLogger>());
        //    reportCrtl.ControllerContext = ControllerContextProvider.GetFakeControllerContext(userId, usersRoles).Object;

        //    ActionResult result = reportCrtl.SubmitReportAfterAddition(mentorsReportVM);

        //    Assert.IsNotNull(result);
        //    Assert.IsAssignableFrom(typeof(PartialViewResult), result);

        //    mockLogic.Verify(t => t.Add(It.IsAny<Report>()), Times.Once);
        //}

        [Test]
        public void ReportController_ThrowExceptionDuringSubmittingInternsReportAfterAddition_ReturnPartialView()
        {
            Mock<IReportLogic> mockLogic = new Mock<IReportLogic>();
            mockLogic.Setup(t => t.Add(It.IsAny<Report>())).Throws<Exception>();

            Mock<ICustomLogger> mockLogger = new Mock<ICustomLogger>();
            mockLogger.Setup(t => t.RecordError(It.IsAny<Exception>())).Verifiable();

            ReportVM internsReportVM = ReportProvider.GetCorrectInternsReportVM();
            ReportController reportCrtl = new ReportController(mockLogic.Object, Mock.Of<IUserLogic>(), mockLogger.Object);

            ActionResult result = reportCrtl.SubmitReportAfterAddition(internsReportVM);

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
