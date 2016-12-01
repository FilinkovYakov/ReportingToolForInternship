namespace Mirantis.ReportingToolForInternship.UnitTests.NUnit
{
    using Microsoft.Practices.Unity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class ScopedLifetimeManager : LifetimeManager, IDisposable
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
