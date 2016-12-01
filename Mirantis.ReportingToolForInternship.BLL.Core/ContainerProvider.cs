namespace Mirantis.ReportingToolForInternship.BLL.Core
{
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;

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
            get
            {
                return container;
            }
        }
    }
}
