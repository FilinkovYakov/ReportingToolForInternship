namespace Mirantis.ReportingToolForInternship.UnitTests.NUnit
{
    using global::NUnit.Framework;
    using DAL.Contracts;
    using Moq;
    using BLL.Core;
    using Entities;
    using System;
    using BLL.Contracts;
    using System.Collections.Generic;

    [TestFixture]
    public class ReportLogicTests
    {
        [Test]
        public void ReportLogic_AddReport_SuccessfullDone()
        {
            Mock<IReportDAO> mockDAO = new Mock<IReportDAO>();
            mockDAO.Setup(t => t.Add(It.IsAny<Report>())).Verifiable();

            ReportLogic logic = new ReportLogic(mockDAO.Object, Mock.Of<ICustomLogger>());
            Report correctReport = ReportProvider.GetCorrectReport();

            logic.Add(correctReport);

            mockDAO.VerifyAll();
        }

        [Test]
        public void ReportLogic_EditReport_SuccessfullDone()
        {
            Mock<IReportDAO> mockDAO = new Mock<IReportDAO>();
            mockDAO.Setup(t => t.Edit(It.IsAny<Report>())).Verifiable();

            ReportLogic logic = new ReportLogic(mockDAO.Object, Mock.Of<ICustomLogger>());
            Report correctReport = ReportProvider.GetCorrectReport();

            logic.Edit(correctReport);

            mockDAO.VerifyAll();
        }

        [Test]
        public void ReportLogic_SearchReport_ReturnNull()
        {
            Mock<IReportDAO> mockDAO = new Mock<IReportDAO>();
            mockDAO.Setup(t => t.Search(It.IsAny<SearchModel>())).Verifiable();

            ReportLogic logic = new ReportLogic(mockDAO.Object, Mock.Of<ICustomLogger>());
            SearchModel searchModel = SearchModelProvider.GetSearchModel();

            IList<Report> foundReports =  logic.Search(searchModel);

            Assert.AreEqual(foundReports, null);
            mockDAO.VerifyAll();
        }

        [Test]
        public void ReportLogic_GetByIdOfReport_ReturnNull()
        {
            Mock<IReportDAO> mockDAO = new Mock<IReportDAO>();
            mockDAO.Setup(t => t.GetById(It.IsAny<Guid>())).Verifiable();

            ReportLogic logic = new ReportLogic(mockDAO.Object, Mock.Of<ICustomLogger>());
            Guid idOfReportThatNotExist = new Guid();

            Report foundReport = logic.GetById(idOfReportThatNotExist);

            Assert.AreEqual(foundReport, null);
            mockDAO.VerifyAll();
        }

        [Test]
        public void ReportLogic_ThrowExceptionDuringAdditionReport_ThrowException()
        {
            Mock<IReportDAO> mockDAO = new Mock<IReportDAO>();
            mockDAO.Setup(t => t.Add(It.IsAny<Report>())).Throws<Exception>();

            Mock<ICustomLogger> loggerMock = new Mock<ICustomLogger>();
            loggerMock.Setup(t => t.RecordError(It.IsAny<Exception>())).Verifiable();

            Report correctReport = ReportProvider.GetCorrectReport();
            ReportLogic logic = new ReportLogic(mockDAO.Object, loggerMock.Object);

            Assert.Throws<Exception>(() => logic.Add(correctReport));

            loggerMock.Verify(t => t.RecordError(It.IsAny<Exception>()), Times.Once);
        }
    }
}
