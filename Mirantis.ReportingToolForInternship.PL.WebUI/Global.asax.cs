namespace Mirantis.ReportingToolForInternship.PL.WebUI
{
    using BLL.Core;
    using Entities;
    using Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            BLLAutomapperInitializer automapperInitializer = new BLLAutomapperInitializer();
            automapperInitializer.Initialize();
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null || string.IsNullOrEmpty(authCookie.Value))
                return;

            var user = JsonConvert.DeserializeObject<AuthenticationUserVM>(FormsAuthentication.Decrypt(authCookie.Value).UserData);
            if (user != null)
            {
                HttpContext.Current.User = new UserPrincipal(user.Login, user.Roles);
            }
        }
    }
}
