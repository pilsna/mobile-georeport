using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KabelWeb.Models;

namespace KabelWeb.Controllers
{
    public class MobileController : AsyncController
    {
        //
        // GET: /Mobile/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Mobile/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Mobile/Create

        [HttpPost]
        public ActionResult Create(NotificationModel notification)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
       
    }
}
