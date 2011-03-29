using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KabelWeb.Models;

namespace KabelWeb.Controllers
{
    public class NotificationController : Controller
    {
        // POST: /Notification/
        public JsonResult Create(NotificationModel notification)
        {
            var msg = notification.Message;

            return Json(notification);
        }

    }

}
