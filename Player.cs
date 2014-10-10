using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ProgrammingPractice
{
    public class Player
    {
        public int bulletCount;
        public Size Size { get; set; }
        public PointF Location { get; set; }
        public Player(PointF location, Size size)
        {
            this.Size = size;
            this.Location = location;
            this.bulletCount = 0;
        }
    }
}
