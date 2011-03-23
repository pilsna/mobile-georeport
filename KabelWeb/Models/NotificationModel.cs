using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KabelWeb.Models
{
    public class NotificationModel
    {
        private Point _point;
        private string _message;
        public Point Point
        {
            get { return _point; }
            set { _point = value; }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

    }
   
}