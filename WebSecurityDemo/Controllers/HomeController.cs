using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebSecurityDemo.Models;

namespace WebSecurityDemo.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private static readonly IList<User> _users = null;

        static HomeController() => _users = Models.User.CreateList(20);

        public IActionResult Index([FromQuery]string searchText)
        {
            IList<User> list;

            if (!string.IsNullOrEmpty(searchText))
                list = _users.Where(item => item.FullName.ToLower().Contains(searchText.ToLower())).OrderBy(item => item.Id).ToList();
            else
                list = _users.OrderBy(item => item.Id).ToList();

            HttpContext.Response.Cookies.Append("session-cookies-user", "username");
            HttpContext.Response.Cookies.Append("session-cookies-psw", "password");

            return View(new SearchViewModel { SearchResult = list, SearchText = searchText });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Add(string userName)
        {
            //var newUserName = userName.Replace("script", "");
            //var newUserName = userName.ToLower().Replace("script", "");

            _users.Add(new User(0) { FirstName = "Michael", LastName = "Reynosa", Email = "devmikemir@gmail.com", Gender = GenderUser.Male, UserName = userName });

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
