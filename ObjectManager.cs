using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ProgrammingPractice
{
    public static class ObjectManager
    {
        private static Timer playerBulletCountTimer;
        private static Timer objectHandlerTimer;
        private static Timer spawnWalkerTimer;
        private static Timer updateWalkerDestinationTimer;

        public static List<GameObject> meatParticleList = new List<GameObject>();
        public static List<GameObject> walkerList = new List<GameObject>();
        public static List<GameObject> bulletList = new List<GameObject>();
        public static Player Player;
        private static Random rnd = new Random();
        public static Size walkerWidth = new Size(25, 25);
        public static int meatParticleCountOnExplosion = 10;
        public static int bulletWalkerCollisionRange = 15;
        public static float walkerMoveSpeed = .5f;
        public static float bulletMoveSpeed = 3;

        public static void InitializeWalkers()
        {
            //Create new player
            Player = new Player(new Point(50, 50), new Size(50, 50));

            //Timers
            playerBulletCountTimer = new Timer();
            objectHandlerTimer = new Timer();
            spawnWalkerTimer = new Timer();
            updateWalkerDestinationTimer = new Timer();

            playerBulletCountTimer.Interval = 1000;
            playerBulletCountTimer.Tick += new EventHandler(playerBulletCountTimer_Tick);
            playerBulletCountTimer.Start();

            objectHandlerTimer.Interval = 15;
            objectHandlerTimer.Tick += new EventHandler(objectHandlerTimer_Tick);
            objectHandlerTimer.Start();

            spawnWalkerTimer.Interval = 2500;
            spawnWalkerTimer.Tick += new EventHandler(spawnWalkerTimer_Tick);
            spawnWalkerTimer.Start();

            updateWalkerDestinationTimer.Interval = 500;
            updateWalkerDestinationTimer.Tick += new EventHandler(updateWalkerDestinationTimer_Tick);
            updateWalkerDestinationTimer.Start();

        }

        static void playerBulletCountTimer_Tick(object sender, EventArgs e)
        {
            Player.bulletCount++;
        }

        static void objectHandlerTimer_Tick(object sender, EventArgs e)
        {
            HandleMeatParticles();
            HandleWalkers();
            HandleBullets();
        }
        static void updateWalkerDestinationTimer_Tick(object sender, EventArgs e)
        {
            //Give walkers new destination
            foreach (Walker walker in walkerList)
            {
                walker.Destination = GetRndFloatPoint();
            }
        }
        static void spawnWalkerTimer_Tick(object sender, EventArgs e)
        {
            //Set start location to a random position
            //Set destination to a random position
            walkerList.Add(new Walker(GetRndFloatPoint(), GetRndFloatPoint(), new Size(25, 25))); 
        }

        public static void addMeatExplosion(Walker walker) //at the location the specific walker died
        {
            for (int i = 0; i < meatParticleCountOnExplosion; i++)
            {
                meatParticleList.Add(new MeatParticle(
                                     walker.Location,
                                     new PointF((float)(walker.Location.X + RndMeatParticleLocation(rnd)),
                                     (float)(walker.Location.Y + RndMeatParticleLocation(rnd))),
                                     new Size(5, 5)));
            }
        }

        static void HandleMeatParticles()
        {
            for (int i = 0; i < meatParticleList.Count; i++)
            {
                var meatParticle = meatParticleList[i];

                MoveObject(meatParticle, 1);

                if (meatParticle.Location == meatParticle.Destination)
                {
                    meatParticleList.RemoveAt(i);
                    continue;
                }
            }
        }
        static void HandleWalkers()
        {
            foreach (Walker walker in walkerList)
            {
                MoveObject(walker, walkerMoveSpeed);
            }
        }
        static void HandleBullets()
        {
            for (int i = 0; i < bulletList.Count; i++)
            {
                //get object
                var bullet = bulletList[i];

                //update object location
                MoveObject(bullet, bulletMoveSpeed);
                if (bullet.Location == bullet.Destination)
                {
                    bulletList.RemoveAt(i);
                    continue; //The bullet object doesnt exist at this point, continue with next object & skip the remaining of this scope. :)
                }
                for (int j = 0; j < walkerList.Count; j++)
                {
                    var walker = walkerList[j];
                    if (Collision(bullet.Location, walker.Location))
                    {
                        addMeatExplosion((Walker)walker);
                        walkerList.RemoveAt(j);
                        bulletList.RemoveAt(i);
                    }
                }
            }
        }

        static PointF GetRndFloatPoint()
        {
            int x = rnd.Next(500);
            int y = rnd.Next(500);

            return new PointF(x, y);
        }
        static bool Collision(PointF bulletLocation, PointF walkerLocation)
        {
            double dist = Math.Sqrt(Math.Pow((walkerLocation.X + (walkerWidth.Height / 2)) - bulletLocation.X, 2) + Math.Pow((walkerLocation.Y + (walkerWidth.Height / 2)) - bulletLocation.Y, 2));
            if (dist <= bulletWalkerCollisionRange) //&& dist >= -25)
                return true;
            else
                return false;
        }
        static float RndMeatParticleLocation(Random rnd)
        {
            float rndFloatDecimal = (float)rnd.NextDouble();
            float rndNumber = rnd.Next(-25, 25) * 1 - 1;

            return rndNumber + rndFloatDecimal;
        }
        static void MoveObject(GameObject gameObject, float speed)
        {
            PointF value = new PointF();

            float tx = gameObject.Destination.X - gameObject.Location.X;
            float ty = gameObject.Destination.Y - gameObject.Location.Y;
            double length = Math.Sqrt(tx * tx + ty * ty);

            if (length >= speed)
            {
                // move towards the goal
                value.X = (float)(gameObject.Location.X + speed * tx / length);
                value.Y = (float)(gameObject.Location.Y + speed * ty / length);

                //update location
                gameObject.Location = value;
            }
            else
            {
                //we've reached the goal
                gameObject.Destination = gameObject.Location;
            }
            //http://stackoverflow.com/questions/13345446/make-an-object-move-towards-another-objects-position
        }
    }
}