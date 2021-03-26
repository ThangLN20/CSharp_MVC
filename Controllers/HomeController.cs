using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GettingStarted.Models;
using Microsoft.AspNetCore.Http;

namespace GettingStarted.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

         public static List<User> users = new List<User>(){
            new User(){UserId=1,UserName="Admin",PassWord="123",RoleId=1}
           ,new User(){UserId=1,UserName="User",PassWord="123",RoleId=2}
        };

        public IActionResult Index()
        {
            ViewBag.Username = null;
            if (HttpContext.Session.GetString("UserName")!=null)
            {
                ViewBag.Username = HttpContext.Session.GetString("UserName");
            }
            return View();
        }
        public IActionResult Login()
        {
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

          [HttpPost]
        public IActionResult Login(User user)
        {
            if (user == null)
            {
                return RedirectToAction("Login"); 
            }

            if (CheckLogin(user) == null)
            {
                 return RedirectToAction("Login"); 
            }

            AddUserToSession(CheckLogin(user));

            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserName");
            HttpContext.Session.Remove("RoleId");

            return RedirectToAction("Index");
        }

        void AddUserToSession(User user){
            HttpContext.Session.SetString("UserName",user.UserName);
            HttpContext.Session.SetString("RoleId",user.RoleId.ToString());
        }  

        User CheckLogin(User user){
            foreach (var item in users)
            {
                if (user.UserName == item.UserName && user.PassWord== item.PassWord)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
