using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarFi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            log4net.Config.XmlConfigurator.Configure();
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
