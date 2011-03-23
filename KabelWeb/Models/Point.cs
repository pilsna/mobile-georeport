using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KabelWeb.Models
{
    public class Point
    {
        private double _x;
        private double _y;

        public Point(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public double X
        {
            get { return _x; }
        }

        public double Y
        {
            get { return _y; }
        }
    }
}