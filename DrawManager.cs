using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProgrammingPractice
{
    public class DrawManager
    {
        PointF MousePosition;
        PictureBox picBox;
        Timer drawTimer;
        Timer lblUpdateTimer;

        public DrawManager(PictureBox picBox)
        {
            ObjectManager.InitializeWalkers();

            this.picBox = picBox;

            lblUpdateTimer = new Timer();
            lblUpdateTimer.Interval = 500;
            lblUpdateTimer.Tick += new EventHandler(lblUpdateTimer_Tick);
            lblUpdateTimer.Start();

            drawTimer = new Timer();
            drawTimer.Interval = 15; //something is locking FPS @ ~35, ~65 ... ?
            drawTimer.Tick += new EventHandler(drawTimer_Tick);
            drawTimer.Start();
        }

        void lblUpdateTimer_Tick(object sender, EventArgs e)
        {
            UpdateLabels.lblBulletCount.Text = ObjectManager.Player.bulletCount.ToString();
            UpdateLabels.lblMouseX.Text = MousePos.X.ToString();
            UpdateLabels.lblMouseY.Text = MousePos.Y.ToString();
        }

        void drawTimer_Tick(object sender, EventArgs e)
        {
            //Update mouse position
            MousePosition = new PointF(MousePos.X, MousePos.Y);

            //Refresh picBox
            this.picBox.Invalidate();
        }

        public void draw(Graphics g)
        {
            //Draw particles
            foreach (MeatParticle meatParticle in ObjectManager.meatParticleList)
            {
                g.FillEllipse(new SolidBrush(Color.Orchid), new RectangleF(meatParticle.Location, new Size(5, 5)));
            }

            //Draw walkers
            foreach (Walker walker in ObjectManager.walkerList)
            {
                g.FillEllipse(new SolidBrush(Color.Red), new RectangleF(walker.Location, new Size(25, 25)));
            }

            //Draw bullets
            foreach (Bullet bullet in ObjectManager.bulletList)
            {
                g.FillRectangle(new SolidBrush(Color.Blue), new RectangleF(bullet.Location, bullet.Size));
            }

            //Draw a line between object and mouse //debug
            Pen linePen = new Pen(Color.Blue, 1);
            g.DrawLine(linePen, MousePosition, ObjectManager.Player.Location);

            Pen myPen2 = new Pen(Color.Red, 1);
            PointF rotatePoint = ObjectManager.Player.Location;

            //Create a matrix and gain "rotatablility"(?)
            float angle = (float)GetAngle(MousePosition, ObjectManager.Player.Location);
            Matrix myMatrix = new Matrix();
            myMatrix.RotateAt(angle, rotatePoint, MatrixOrder.Append);

            //Draw the rectangle (player).
            int offsetBoxSizeCenter = 25;
            g.Transform = myMatrix;
            g.DrawRectangle(myPen2, ObjectManager.Player.Location.X - offsetBoxSizeCenter,
                                    ObjectManager.Player.Location.Y - offsetBoxSizeCenter,
                                    50,
                                    50);
        }

        double GetAngle(PointF a, PointF b)
        {
            double xDiff = b.X - a.X;
            double yDiff = b.Y - a.Y;

            return Math.Atan2(yDiff, xDiff) * 180.0 / Math.PI;
            //http://stackoverflow.com/questions/12891516/math-calculation-to-retrieve-angle-between-two-points
        }
    }
}