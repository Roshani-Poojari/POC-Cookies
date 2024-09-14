using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POCCookiesMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult SetCookie()
        {
            HttpCookie cookie = new HttpCookie("MyCookie");
            cookie.Value = "This is my cookie value";
            cookie.Expires = DateTime.Now.AddMinutes(1); // Cookie will expire in 1 minute
            Response.Cookies.Add(cookie);

            return Content("Cookie has been set!");
        }
        public ActionResult GetCookie()
        {
            HttpCookie cookie = Request.Cookies["MyCookie"];
            if (cookie != null)
            {
                string cookieValue = cookie.Value;
                return Content($"Cookie value: {cookieValue}");
            }
            return Content("Cookie not found.");
        }
        public ActionResult DeleteCookie()
        {
            if (Request.Cookies["MyCookie"] != null)
            {
                HttpCookie cookie = new HttpCookie("MyCookie");
                cookie.Expires = DateTime.Now.AddDays(-1); // Set expiration date to past
                Response.Cookies.Add(cookie);
            }

            return Content("Cookie has been deleted!");
        }

    }
}