namespace Mirantis.ReportingToolForInternship.PL.WebUI.Controllers
{
    using AuthorizeAttributes;
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
        [AnonymousOnly]
        public ActionResult SignIn()
        {
            return View();
        }

        [AnonymousOnly]
        [HttpPost]
        public ActionResult SignIn(AuthenticationUserVM authUserVM)
        {
            if (ModelState.IsValid)
            {
                //Check on Alex service authorize

                //Get roles from Alex
                authUserVM.Roles = new List<Role> { new Role { RoleName = "Mentor" }, new Role { RoleName = "Intern" } };

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

                return RedirectToAction("Search", "Report");
            }

            return View(authUserVM);
        }

        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Search", "Report");
        }
    }
}