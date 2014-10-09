using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ProgrammingPractice
{
    public class Player : GameObject
    {
        public Player(PointF Location, Size size)
            : base(Location)
        {
            this.Size = size;
        }
    }
}
