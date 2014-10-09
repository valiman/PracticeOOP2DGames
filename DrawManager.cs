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
        PictureBox picBox;
        Timer drawTimer;
        Timer lblUpdateTimer;

        public DrawManager(PictureBox picBox)
        {
            ObjectManager.objPlayer = new Player(new Point(50, 50), new Size(50, 50));
            this.picBox = picBox;
            this.lblUpdateTimer = new Timer();
            this.drawTimer = new Timer();
            this.lblUpdateTimer.Interval = 1000;
            this.drawTimer.Interval = 15; //something is locking FPS @ ~35, ~65 ... ?
            this.lblUpdateTimer.Tick += new EventHandler(lblUpdateTimer_Tick);
            this.drawTimer.Tick += new EventHandler(drawTimer_Tick);
            this.lblUpdateTimer.Start();
            this.drawTimer.Start();
        }

        void lblUpdateTimer_Tick(object sender, EventArgs e)
        {
            UpdateLabels.lblBulletCount.Text = ObjectManager.bulletList.Count.ToString();
            UpdateLabels.lblMouseX.Text = MousePos.X.ToString();
            UpdateLabels.lblMouseY.Text = MousePos.Y.ToString();
        }

        void drawTimer_Tick(object sender, EventArgs e)
        {
            //Refresh picBox
            this.picBox.Invalidate();
        }
        
        public void draw(Graphics g)
        {
            //Draw bullets
            foreach (Bullet bullet in ObjectManager.bulletList)
            {
                MoveBullet(bullet);
                
                //Draw bullet if not null < ;D >
                if (bullet != null)
                {
                    g.FillRectangle(new SolidBrush(Color.Blue), new RectangleF(bullet.Location, new Size(5, 5)));
                }
            }

            PointF MousePosition = new PointF(MousePos.X, MousePos.Y);
            PointF PlayerCenterPosition = new PointF(ObjectManager.objPlayer.Location.X, ObjectManager.objPlayer.Location.Y);

            //Draw a line between object and mouse //debug
            Pen linePen = new Pen(Color.Blue, 1);
            g.DrawLine(linePen, MousePosition, PlayerCenterPosition);

            Pen myPen2 = new Pen(Color.Red, 1);
            PointF rotatePoint = PlayerCenterPosition;

            // Create a matrix and gain "rotatablility"(?)
            float angle = (float)GetAngle(MousePosition, PlayerCenterPosition);
            Matrix myMatrix = new Matrix();
            myMatrix.RotateAt(angle, rotatePoint, MatrixOrder.Append);

            // Draw the rectangle (player).
            int offsetBoxSizeCenter = 25;
            g.Transform = myMatrix;
            g.DrawRectangle(myPen2, ObjectManager.objPlayer.Location.X - offsetBoxSizeCenter,
                                    ObjectManager.objPlayer.Location.Y - offsetBoxSizeCenter,
                                    50,
                                    50);
        }

        public static void MoveBullet(Bullet bullet)
        {
            //PointF start, PointF stop, float speed
            //Retun value
            float speed = 1.5f;
            PointF value = new PointF();

            float tx = bullet.Destination.X - bullet.Location.X;
            float ty = bullet.Destination.Y - bullet.Location.Y;
            double length = Math.Sqrt(tx * tx + ty * ty);

            if (length >= speed)
            {
                // move towards the goal
                value.X = (float)(bullet.Location.X + speed * tx / length);
                value.Y = (float)(bullet.Location.Y + speed * ty / length);

                //update location
                bullet.Location = value;
            }
            else
            {
                //we've reached the goal
                value.X = bullet.Location.X;
                value.Y = bullet.Location.Y;
            }
            //http://stackoverflow.com/questions/13345446/make-an-object-move-towards-another-objects-position
        }

        double GetAngle(PointF a, PointF b)
        {
            double xDiff = b.X - a.X;
            double yDiff = b.Y - a.Y;

            return Math.Atan2(yDiff, xDiff) * 180.0 / Math.PI;
            //http://stackoverflow.com/questions/12891516/math-calculation-to-retrieve-angle-between-two-points
        }

        //private void CheckCollisionWithPlayer()
        //{
        //    foreach (Bullet item in bulletList)
        //    {
        //        if (item.Location.X > objPlayer.Location.X + 4 &&)
        //            this.drawTimer.Stop();
        //    }
        //}
    }
}
