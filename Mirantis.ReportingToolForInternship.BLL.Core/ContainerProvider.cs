namespace Mirantis.ReportingToolForInternship.BLL.Core
{
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ContainerProvider
    {
        private static IUnityContainer container;

        static ContainerProvider()
        {
            container = new UnityContainer();
            container.LoadConfiguration();
        }

        public static IUnityContainer Container
        {
            get { return container; }
        }
    }
}
