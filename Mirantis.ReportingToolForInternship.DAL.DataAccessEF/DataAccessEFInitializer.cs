namespace Mirantis.ReportingToolForInternship.DAL.DataAccessEF
{
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;

    public class DataAccessEFInitializer
    {
        public void Initialize(IUnityContainer container)
        {
            container.LoadConfiguration();
        }
    }
}
