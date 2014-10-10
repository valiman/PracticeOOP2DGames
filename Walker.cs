using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ProgrammingPractice
{
    public class Walker : GameObject
    {
        public int Health { get; set; }
        public Walker(PointF Location, PointF Destination, Size size) : base(Location, Destination, size)
        {
            this.Health = 1;
        }
    }
}
