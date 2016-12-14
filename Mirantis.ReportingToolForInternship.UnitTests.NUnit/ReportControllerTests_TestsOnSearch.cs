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
    public class ReportControllerTests_TestsOnSearch
    {
        [Test]
        public void ReportController_ShowSearchReport_ReturnPartialView()
        {
            int userId = 0;

            Mock<IReportLogic> reportLogic = new Mock<IReportLogic>();
            reportLogic.Setup(t => t.Search(It.IsAny<SearchModel>())).Verifiable();

            ReportController reportCtrl = new ReportController(reportLogic.Object, Mock.Of<IUserLogic>(), Mock.Of<ICustomLogger>());
            reportCtrl.ControllerContext = ControllerContextProvider.GetFakeControllerContext(userId, null).Object;
            
SearchVM searhVM = SearchModelProvider.GetSearchVM();

            ActionResult result = reportCtrl.ShowSearchResult(searhVM);

            Assert.IsAssignableFrom<PartialViewResult>(result);
            reportLogic.VerifyAll();
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
