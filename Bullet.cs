﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ProgrammingPractice
{
    public class Bullet : GameObject
    {
        public Bullet(PointF Location, PointF Destination, Size size)
            : base(Location, Destination, size)
        {

        }
    }
}
