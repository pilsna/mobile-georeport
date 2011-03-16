using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KabelWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Cloud eksperimenter";

            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Teknologi";
            return View("Index");
        }
    }
}
