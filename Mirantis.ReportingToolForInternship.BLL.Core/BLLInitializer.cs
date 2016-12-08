namespace Mirantis.ReportingToolForInternship.BLL.Core
{
    using DAL.DataAccessEF;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;

    public class BLLInitializer
    {
        private DataAccessEFInitializer dataAccessEFInitializer;

        public BLLInitializer()
        {
            dataAccessEFInitializer = new DataAccessEFInitializer();
        }

        public void Initialize(IUnityContainer container)
        {
            dataAccessEFInitializer.Initialize(container);
            container.LoadConfiguration();
        } 
    }
}
