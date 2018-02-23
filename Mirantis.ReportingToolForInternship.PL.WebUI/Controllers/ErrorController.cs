using System.Web.Mvc;

namespace Mirantis.ReportingTool.PL.WebUI.Controllers
{
	public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            Response.StatusCode = 404;
            return View("_Error404");
        }

        public ActionResult Error401()
        {
            Response.StatusCode = 401;
            return View("_Error401");
        }

        public ActionResult Error403()
        {
            Response.StatusCode = 403;
            return View("_Error403");
        }

        public ActionResult Error404()
        {
            Response.StatusCode = 404;
            return View("_Error404");
        }

        public ActionResult Error500()
        {
            Response.StatusCode = 500;
            return View("_Error500");
        }
    }
}