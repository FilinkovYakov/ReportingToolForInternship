namespace Mirantis.ReportingToolForInternship.UnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using BLL.Contracts;
    using Entities;
    using Microsoft.Practices.Unity;
    using DAL.Contracts;
    using BLL.Core;

    [TestClass]
    public class ReportLogicTests
    {
        [TestMethod]
        public void AddReport()
        {
            using (var lifetimeManager = new ScopedLifetimeManager())
            {
                Mock<IReportDAO> mockLogic = new Mock<IReportDAO>();
                mockLogic.Setup(t => t.Add(It.IsAny<Report>())).Verifiable();

                ContainerProvider.Container.RegisterInstance(mockLogic.Object, lifetimeManager);

                ReportLogic logic = new ReportLogic();
                logic.Add(new Report());

                mockLogic.VerifyAll();
            }
        }

        [TestMethod]
        public void AddReport2()
        {
            using (var lifetimeManager = new ScopedLifetimeManager())
            {
                Mock<IReportDAO> mockLogic = new Mock<IReportDAO>();
                mockLogic.Setup(t => t.Add(It.IsAny<Report>())).Verifiable();

                ContainerProvider.Container.RegisterInstance(mockLogic.Object, lifetimeManager);

                ReportLogic logic = new ReportLogic();
                logic.Add(new Report());

                mockLogic.VerifyAll();
            }
        }
    }

    public class ScopedLifetimeManager : LifetimeManager, IDisposable
    {
        private object _value;
        public void Dispose()
        {
            RemoveValue();
        }

        public override object GetValue()
        {
            return _value;
        }

        public override void RemoveValue()
        {
            _value = null;
        }

        public override void SetValue(object newValue)
        {
            _value = newValue;
        }
    }
}
