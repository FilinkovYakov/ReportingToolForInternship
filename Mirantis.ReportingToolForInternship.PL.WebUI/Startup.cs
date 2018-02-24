using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Mirantis.ReportingTool.PL.WebUI.Startup))]
namespace Mirantis.ReportingTool.PL.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

		}
    }
}
