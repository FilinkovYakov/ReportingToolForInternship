namespace Mirantis.ReportingTool.PL.WebUI
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
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            try
            {
                var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie == null || string.IsNullOrEmpty(authCookie.Value))
                    return;

                var user = JsonConvert.DeserializeObject<CookieUser>(FormsAuthentication.Decrypt(authCookie.Value).UserData);
                if (user != null)
                {
                    HttpContext.Current.User = new UserPrincipal(user.Id, user.Roles);
                }
            }
            catch
            {
                FormsAuthentication.SignOut();
            }
        }

        protected void Application_BeginRequest()
        {
            //NOTE: Stopping IE from being a caching whore
            Response.Cache.SetAllowResponseInBrowserHistory(false);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
            Response.Cache.SetValidUntilExpires(false);
        }
    }
}
