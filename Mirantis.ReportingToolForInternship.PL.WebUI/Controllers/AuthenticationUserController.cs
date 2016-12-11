﻿namespace Mirantis.ReportingToolForInternship.PL.WebUI.Controllers
{
    using AuthorizeAttributes;
    using Entities;
    using BLL.Contracts;
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
        private readonly IAuthenticationUserLogic _authUserLogic;
        private readonly ICustomLogger _customLogger;

        public AuthenticationUserController(IAuthenticationUserLogic authUserLogic, ICustomLogger customLogger)
        {
            _authUserLogic = authUserLogic;
            _customLogger = customLogger;
        }

        [AnonymousOnly]
        public ActionResult SignIn()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                _customLogger.RecordError(e);
                return new HttpStatusCodeResult(500);
            }
        }

        [AnonymousOnly]
        [HttpPost]
        public ActionResult SignIn(AuthenticationUserVM authUserVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //if (_authUserLogic.TryAuthentication(authUserVM.Login, authUserVM.Password))
                    //{
                        //authUserVM.Roles = _authUserLogic.GetRolesByUsersLogin(authUserVM.Login).ToList();
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

                    ModelState.AddModelError("Login", "You entered uncorrect passord or login doesn't exist");
                //}

                return View(authUserVM);
            }
            catch (Exception e)
            {
                _customLogger.RecordError(e);
                return new HttpStatusCodeResult(500);
            }
        }

        [Authorize]
        public ActionResult SignOut()
        {
            try
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Search", "Report");
            }
            catch (Exception e)
            {
                _customLogger.RecordError(e);
                return new HttpStatusCodeResult(500);
            }
        }
    }
}