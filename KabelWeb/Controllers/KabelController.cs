using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KabelWeb.Controllers
{
    public class KabelController : Controller
    {
        //
        // GET: /Kabel/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

    }
}
