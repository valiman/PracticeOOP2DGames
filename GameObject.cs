using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ProgrammingPractice
{
    public abstract class GameObject
    {
        public PointF Destination { get; set; }
        public PointF Direction { get; set; }
        public PointF Location { get; set; }
        public Size Size { get; set; }

        public GameObject(PointF Location, PointF Destination, Size size)
        {
            this.Location = Location;
            this.Destination = Destination;
            this.Size = size;
        }
    }
}
