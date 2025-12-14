using Microsoft.AspNetCore.Mvc;

namespace FavBookWebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.sessionId = HttpContext.Session.GetString("id");
            ViewBag.sessionUserName =
           HttpContext.Session.GetString("username");
            return View();
        }

    }
}
