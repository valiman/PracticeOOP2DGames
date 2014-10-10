using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace ProgrammingPractice
{
    public partial class Form1 : Form
    {
        float speecIncrement = 5.5f;
        int fps = 0;
        Stopwatch sw = new Stopwatch();
        DrawManager drawMgr;
        Timer shootBulletsTimer = new Timer();
        public Form1()
        {
            InitializeComponent();
            drawMgr = new DrawManager(pictureBox1);
            UpdateLabels.lblMouseX = lblMouseX;
            UpdateLabels.lblMouseY = lblMouseY;
            UpdateLabels.lblMouseAngleToObj = lblMouseAngleToObj;
            UpdateLabels.lblBulletCount = lblBulletCount;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //hm.. not sure about this ó_Ò
            if (!sw.IsRunning)
            {
                sw.Start();
            }

            if (sw.Elapsed.Seconds < 1)
            {
                fps++;
            }
            else //time is greater than 1 second
            {
                lblFps.Text = fps.ToString() + " fps";
                fps = 0;
                sw.Reset();
            }

            //send e.Graphics object to draw class
            drawMgr.draw(e.Graphics);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            MousePos.X = e.X;
            MousePos.Y = e.Y;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (ObjectManager.Player.bulletCount > 0)
            {
                ObjectManager.Player.bulletCount--;
                ObjectManager.bulletList.Add(new Bullet(ObjectManager.Player.Location, new PointF(MousePos.X, MousePos.Y), new Size(5,5)));   
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    ObjectManager.Player.Location = new PointF(ObjectManager.Player.Location.X,
                                                                  ObjectManager.Player.Location.Y - speecIncrement);
                    break;
                case Keys.S:
                    ObjectManager.Player.Location = new PointF(ObjectManager.Player.Location.X,
                                                                  ObjectManager.Player.Location.Y + speecIncrement);
                    break;
                case Keys.D:
                    ObjectManager.Player.Location = new PointF(ObjectManager.Player.Location.X + speecIncrement,
                                                                  ObjectManager.Player.Location.Y);
                    break;
                case Keys.A:
                    ObjectManager.Player.Location = new PointF(ObjectManager.Player.Location.X - speecIncrement,
                                                                  ObjectManager.Player.Location.Y);
                    break;
                default:
                    break;
            }
        }
    }
}
