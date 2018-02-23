namespace Mirantis.ReportingTool.BLL.Core
{
    using DAL.DataAccess;
    using DAL.DataAccessCache;
    using DAL.DataAccessEF;
    using DAL.DataAccessService;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;

    public class BLLContainerInitializer
    {
        private DataEFContainerInitializer dataEFInitializer;
        private DataServiceContainerInitializer dataServiceInitializer;
        private DataContainerInitializer dataInitializer;
        private DataCacheContainerInitializer dataCacheInitializer;

        public BLLContainerInitializer()
        {
            dataEFInitializer = new DataEFContainerInitializer();
            dataServiceInitializer = new DataServiceContainerInitializer();
            dataInitializer = new DataContainerInitializer();
            dataCacheInitializer = new DataCacheContainerInitializer();
        }

        public void Initialize(IUnityContainer container)
        {
            dataEFInitializer.Initialize(container);
            dataServiceInitializer.Initialize(container);
            dataCacheInitializer.Initialize(container);
            dataInitializer.Initialize(container);
            container.LoadConfiguration();
        } 
    }
}
