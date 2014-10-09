using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ProgrammingPractice
{
    public class Bullet : GameObject
    {
        public PointF Destination { get; set; }
        public Bullet(PointF Location, PointF Destination)
            : base(Location)
        {
            this.Destination = Destination;
        }
    }
}
