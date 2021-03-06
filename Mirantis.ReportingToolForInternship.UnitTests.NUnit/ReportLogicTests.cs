﻿namespace Mirantis.ReportingToolForInternship.UnitTests.NUnit
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

            ReportLogic logic = new ReportLogic(mockDAO.Object, Mock.Of<IUserDAO>(), Mock.Of<ICustomLogger>());
            Report correctReport = ReportProvider.GetCorrectInternsReport();

            logic.Add(correctReport);

            mockDAO.VerifyAll();
        }

        [Test]
        public void ReportLogic_EditReport_SuccessfullDone()
        {
            Mock<IReportDAO> mockDAO = new Mock<IReportDAO>();
            mockDAO.Setup(t => t.Edit(It.IsAny<Report>())).Verifiable();

            ReportLogic logic = new ReportLogic(mockDAO.Object, Mock.Of<IUserDAO>(), Mock.Of<ICustomLogger>());
            Report correctReport = ReportProvider.GetCorrectInternsReport();

            logic.Edit(correctReport);

            mockDAO.VerifyAll();
        }

        [Test]
        public void ReportLogic_SearchReport_ReturnEmptyList()
        {
            Mock<IReportDAO> mockDAO = new Mock<IReportDAO>();
            mockDAO.Setup(t => t.SearchForUser(It.IsAny<SearchModel>())).Verifiable();

            ReportLogic logic = new ReportLogic(mockDAO.Object, Mock.Of<IUserDAO>(), Mock.Of<ICustomLogger>());
            SearchModel searchModel = SearchModelProvider.GetSearchModel();

            IList<RepresentingReport> foundReports = logic.SearchForUser(searchModel);

            Assert.AreEqual(foundReports.Count, 0);
            mockDAO.VerifyAll();
        }

        [Test]
        public void ReportLogic_GetByIdOfReport_ReturnNull()
        {
            Mock<IReportDAO> mockDAO = new Mock<IReportDAO>();
            mockDAO.Setup(t => t.GetById(It.IsAny<Guid>())).Verifiable();

            ReportLogic logic = new ReportLogic(mockDAO.Object, Mock.Of<IUserDAO>(), Mock.Of<ICustomLogger>());
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

            Report correctReport = ReportProvider.GetCorrectInternsReport();
            ReportLogic logic = new ReportLogic(mockDAO.Object, Mock.Of<IUserDAO>(), loggerMock.Object);

            Assert.Throws<Exception>(() => logic.Add(correctReport));

            loggerMock.Verify(t => t.RecordError(It.IsAny<Exception>()), Times.Once);
        }
    }
}
