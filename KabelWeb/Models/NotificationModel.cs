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
        private double _x;
        private double _y;
        private double _accuracy;

        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public double Accuracy
        {
            get { return _accuracy; }
            set { _accuracy = value; }
        }

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