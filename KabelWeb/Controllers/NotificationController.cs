using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KabelWeb.Models;

namespace KabelWeb.Controllers
{
    public class NotificationController : AsyncController
    {
        // POST: /Notification/
        [HttpPost]
        public ActionResult Create(NotificationModel notification)
        {
            var msg = notification.Message;

            return Json("message: Success");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return Json("Tak, fejlen er indberettet", JsonRequestBehavior.AllowGet);
        } 
    }

}
