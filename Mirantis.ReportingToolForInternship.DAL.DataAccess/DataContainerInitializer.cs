namespace Mirantis.ReportingToolForInternship.DAL.DataAccess
{
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DataContainerInitializer
    {
        public void Initialize(IUnityContainer container)
        {
            container.LoadConfiguration();
        }
    }
}
