using ETB310_LandlordV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETB310_LandlordV2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LogInViewModel login)
        {
            if (login.UserName == null || login.Password == null)
            {
                ModelState.AddModelError("", "Fill in the forms");
                return View();
            }
            bool validUser = false;

            validUser = System.Web.Security.FormsAuthentication.Authenticate(login.UserName, login.Password);

            if (validUser)
            {
                System.Web.Security.FormsAuthentication.RedirectFromLoginPage(login.UserName, false);
            }
            ModelState.AddModelError("", "Login not accepted");
            return View();
        }
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "This page is a placeholder.";

            return View();
        }
    }
}