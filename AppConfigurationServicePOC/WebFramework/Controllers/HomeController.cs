using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebFramework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var setting = ConfigurationManager.AppSettings["MyPassword"];

            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
