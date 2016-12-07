namespace Mirantis.ReportingToolForInternship.PL.WebUI
{
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

            AutoMapper.Mapper.Initialize(c =>
            {
                c.CreateMap<Models.SearchVM, Entities.SearchModel>();
                c.CreateMap<Entities.SearchModel, Models.SearchVM>();

                c.CreateMap<Models.QuestionVM, Entities.Question>();
                c.CreateMap<Entities.Question, Models.QuestionVM>().ForMember(x => x.Id, x => x.NullSubstitute(Guid.Empty));

                c.CreateMap<Models.ActivityVM, Entities.Activity>();
                c.CreateMap<Entities.Activity, Models.ActivityVM>().ForMember(x => x.Id, x => x.NullSubstitute(Guid.Empty));

                c.CreateMap<Models.FuturePlanVM, Entities.FuturePlan>();
                c.CreateMap<Entities.FuturePlan, Models.FuturePlanVM>().ForMember(x => x.Id, x => x.NullSubstitute(Guid.Empty));

                c.CreateMap<Models.ReportVM, Entities.Report>();
                c.CreateMap<Entities.Report, Models.ReportVM>().ForMember(x => x.Id, x => x.NullSubstitute(Guid.Empty));

                //c.CreateMap<Entities.Report, Entities.RepresentingReport>()
                //.ForMember(x => x.MentorsFullName, x => x.UseValue(string.Empty))
                //.ForMember(x => x.InternsFullName, x => x.UseValue(string.Empty));

                //c.CreateMap<Entities.RepresentingReport, Models.RepresentingReportVM>();
            });
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null || string.IsNullOrEmpty(authCookie.Value))
                return;

            var user = JsonConvert.DeserializeObject<AuthenticationUserVM>(FormsAuthentication.Decrypt(authCookie.Value).UserData);
            //HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData);
            if (user != null)
                HttpContext.Current.User = new UserPrincipal(user.Login, new List<Role> { new Role { RoleName = "Mentor" } });
        }
    }
}
