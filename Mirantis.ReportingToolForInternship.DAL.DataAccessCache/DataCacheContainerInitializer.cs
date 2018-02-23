namespace Mirantis.ReportingTool.DAL.DataAccessCache
{
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;

    public class DataCacheContainerInitializer
    {
        public void Initialize(IUnityContainer container)
        {
            container.LoadConfiguration();
        }
    }
}
