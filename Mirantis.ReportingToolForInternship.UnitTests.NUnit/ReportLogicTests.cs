namespace Mirantis.ReportingToolForInternship.UnitTests.NUnit
{
    using global::NUnit.Framework;
    using DAL.Contracts;
    using Moq;
    using BLL.Core;
    using Entities;
    using Microsoft.Practices.Unity;
    using System;
    using System.Collections.Generic;
    using log4net;

    [TestFixture]
    public class ReportLogicTests
    {
        [Test]
        public void ReportLogic_AddReport_SuccessfullDone()
        {
            Mock<IReportDAO> mockDAO = new Mock<IReportDAO>();
            mockDAO.Setup(t => t.Add(It.IsAny<Report>())).Verifiable();

            ReportLogic logic = new ReportLogic(mockDAO.Object);
            Report correctReport = ReportProvider.GetCorrectReport();
            
            logic.Add(correctReport);

            mockDAO.VerifyAll();
        }

        [Test]
        public void ReportLogic_AddReport_ThrowException()
        {
            using (var lifeTimeLoggerManager = new ScopedLifetimeManager())
            {
                Mock<IReportDAO> mockDAO = new Mock<IReportDAO>();
                mockDAO.Setup(t => t.Add(It.IsAny<Report>())).Throws<Exception>();

                Report correctReport = ReportProvider.GetCorrectReport();
                ReportLogic logic = new ReportLogic(mockDAO.Object);
                
                Mock<ILog> logMock = new Mock<ILog>();
                logMock.Setup(t => t.Error(It.IsAny<object>())).Verifiable();
                
                ContainerProvider.Container.RegisterInstance(logMock.Object, lifeTimeLoggerManager);

                Assert.Throws<Exception>(() => logic.Add(correctReport));

                logMock.Verify(t => t.Error(It.IsAny<object>()), Times.Once);
            }
        }
    }
}
