namespace Mirantis.ReportingTool.DAL.DataAccessEF
{
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;

    public class DataEFContainerInitializer
    {
        public void Initialize(IUnityContainer container)
        {
            container.LoadConfiguration();
        }
    }
}
