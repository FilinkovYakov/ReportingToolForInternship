namespace Mirantis.ReportingToolForInternship.BLL.Core
{
    using DAL.DataAccessService;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BLLAutomapperInitializer
    {
        public DataServiceMapperInitializer dataServiceMapperInitializer;

        public BLLAutomapperInitializer()
        {
            dataServiceMapperInitializer = new DataServiceMapperInitializer();
        }

        public void Initialize()
        {
            dataServiceMapperInitializer.Initialize();
        }
    }
}
