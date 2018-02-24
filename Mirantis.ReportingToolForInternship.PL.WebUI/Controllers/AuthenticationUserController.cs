namespace Mirantis.ReportingTool.PL.WebUI.Controllers
{
	using AuthorizeAttributes;
	using Entities;
	using BLL.Contracts;
	using Models;
	using Newtonsoft.Json;
	using System;
	using System.Web;
	using System.Web.Mvc;
	using System.Web.Security;
	using Automapper;
	using AutoMapper;

	public class AuthenticationUserController : Controller
    {
        private readonly IAuthenticationUserLogic _authUserLogic;
        private readonly ICustomLogger _customLogger;
		private readonly IMapper _mapper;

        public AuthenticationUserController(IAuthenticationUserLogic authUserLogic, IMapper mapper, ICustomLogger customLogger)
        {
			_authUserLogic = authUserLogic ?? throw new ArgumentNullException(nameof(authUserLogic));
            _customLogger = customLogger ?? throw new ArgumentNullException(nameof(customLogger));
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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
                    User user = _authUserLogic.TryAuthentication(authUserVM.Login, authUserVM.Password);
                    if (user != null)
                    {
                        CookieUser cookieUser = _mapper.Map<CookieUser>(user);

                        var encTicket = FormsAuthentication.Encrypt(
                                new FormsAuthenticationTicket(
                                    1,
                                    "name",
                                    DateTime.Now,
                                    DateTime.Now.Add(FormsAuthentication.Timeout),
                                    false,
                                    JsonConvert.SerializeObject(cookieUser))
                            );
                        HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                        Response.Cookies.Add(faCookie);

                        return RedirectToAction("Search", "Report");
                    }

                    ModelState.AddModelError("Login", "You entered incorrect passord or login doesn't exist");
                }

                return View(authUserVM);
            }
            catch (Exception e)
            {
                _customLogger.RecordError(e);
                return new HttpStatusCodeResult(500);
            }
        }

        [CustomAuthorize]
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