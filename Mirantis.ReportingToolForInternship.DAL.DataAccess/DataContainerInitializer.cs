namespace Mirantis.ReportingTool.DAL.DataAccess
{
	using Microsoft.Practices.Unity;
	using Microsoft.Practices.Unity.Configuration;

	public class DataContainerInitializer
    {
        public void Initialize(IUnityContainer container)
        {
            container.LoadConfiguration();
        }
    }
}
