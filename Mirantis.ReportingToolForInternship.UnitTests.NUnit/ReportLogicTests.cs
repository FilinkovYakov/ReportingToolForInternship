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
            using (var lifeTimeDAOManager = new ScopedLifetimeManager())
            {
                ReportLogic logic = new ReportLogic();
                Report correctReport = ReportProvider.GetCorrectReport();

                Mock<IReportDAO> mockDAO = new Mock<IReportDAO>();
                mockDAO.Setup(t => t.Add(It.IsAny<Report>())).Verifiable();

                ContainerProvider.Container.RegisterInstance(mockDAO.Object, lifeTimeDAOManager);

                logic.Add(correctReport);

                mockDAO.VerifyAll();
            }
        }

        [Test]
        public void ReportLogic_AddReport_ThrowException()
        {
            using (var lifeTimeDAOManager = new ScopedLifetimeManager())
            {
                using (var lifeTimeLoggerManager = new ScopedLifetimeManager())
                {
                    Report correctReport = ReportProvider.GetCorrectReport();
                    ReportLogic logic = new ReportLogic();

                    Mock<IReportDAO> mockDAO = new Mock<IReportDAO>();
                    mockDAO.Setup(t => t.Add(It.IsAny<Report>())).Throws<Exception>();

                    Mock<ILog> logMock = new Mock<ILog>();
                    logMock.Setup(t => t.Error(It.IsAny<object>())).Verifiable();

                    ContainerProvider.Container.RegisterInstance(mockDAO.Object, lifeTimeDAOManager);
                    ContainerProvider.Container.RegisterInstance(logMock.Object, lifeTimeLoggerManager);

                    try
                    {
                        logic.Add(correctReport);
                    }
                    catch
                    { }

                    logMock.Verify(t => t.Error(It.IsAny<object>()), Times.Once);
                }
            }
        }
    }
}
