namespace Mirantis.ReportingToolForInternship.BLL.Core
{
    using DAL.DataAccessEF;
    using DAL.DataAccessService;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;

    public class BLLContainerInitializer
    {
        private DataEFContainerInitializer dataEFInitializer;
        private DataServiceContainerInitializer dataServiceInitializer; 

        public BLLContainerInitializer()
        {
            dataEFInitializer = new DataEFContainerInitializer();
            dataServiceInitializer = new DataServiceContainerInitializer();
        }

        public void Initialize(IUnityContainer container)
        {
            dataEFInitializer.Initialize(container);
            dataServiceInitializer.Initialize(container);
            container.LoadConfiguration();
        } 
    }
}
