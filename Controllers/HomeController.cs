using System.Diagnostics;
using FavBookWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace FavBookWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult SetCookies(string cookieName, string cookieValue)
        {
            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(15),
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            };
            Response.Cookies.Append(cookieName, cookieValue, options);
            return Ok("Cookies has been set.");
        }

        public void SetSession(string key, string value)
        {
            HttpContext.Session.SetString(key, value);
        }
        public IActionResult Index()
        {
            SetSession("id", Guid.NewGuid().ToString());

            if (User.Identity.IsAuthenticated)
            {
                SetCookies("userName", User.Identity.Name);
                SetSession("username", User.Identity.Name);
            }
            else
            {
                SetCookies("userName", "guest");
                SetSession("username", "guest");
            }
            string userAgent = Request.Headers["User-Agent"].ToString();
            SetCookies("browserName", userAgent);

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
