namespace Mirantis.ReportingToolForInternship.PL.WebUI.Controllers
{
    using Entities;
    using Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;

    public class AuthenticationUserController : Controller
    {
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(AuthenticationUserVM authUserVM)
        {
            if (ModelState.IsValid)
            {
                //check on Alex service authorize
                                
                var encTicket = FormsAuthentication.Encrypt(
                        new FormsAuthenticationTicket(
                            1,
                            "name",
                            DateTime.Now,
                            DateTime.Now.Add(FormsAuthentication.Timeout),
                            false,
                            JsonConvert.SerializeObject(authUserVM))
                    );
                HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                Response.Cookies.Add(faCookie);

                HttpContext.User = new UserPrincipal(authUserVM.Login, new List<Role>()
                {
                    new Role()
                    {
                        RoleName="Mentor"
                    },
                    new Role()
                    {
                        RoleName="Intern"
                    }
                });

                return RedirectToAction("Search", "Report");
            }

            return View(authUserVM);
        }

        public ActionResult SignOut()
        {
            return View();
        }
    }
}