using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebSecurityDemo.Controllers
{
    [AllowAnonymous]
    public class MaliciousController : Controller
    {
        public IActionResult Index(string cookie)
        {
            ViewBag.Cookie = cookie;

            return View();
        }
    }
}
