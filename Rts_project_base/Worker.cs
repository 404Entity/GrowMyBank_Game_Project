using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace Rts_project_base
{
    class Worker : GameObject
    {
        #region Fields
        private float speed;
        private bool working;
        private bool carryingResource;
        private bool active;
        private bool moving;
        Vector2 destination;
        Mine currentMine;
        #endregion
        #region Property
       
        public float Speed { get { return speed; } set { speed = value; } }
        public bool Working
        {
            get { return working; }
            set { working = value; }
        }
        public bool Active
        {
            get { return active; }
            set { active = value; }
        }
        public bool Moving
        {
            get { return moving; }
            set { moving = value; }
        }
        public Vector2 Destination
        {
            get { return destination; }
            set { destination = value; }
        }
        public Mine CurrentBuilding { get { return currentMine; } set { currentMine = value; } }
        #endregion
        #region Constructor
        public Worker(Vector2 position,string spritePath, float scaleFactor,string name): base(position,spritePath,scaleFactor, name)
        {
            //starts the workers thread
            InitWorkerThread();
        }
        #endregion
        #region Methods

        private void InitWorkerThread()
        {
            // creates a new thread the worker will be useing
            Thread WorkerThread = new Thread(Work);
            //starts the thread
            WorkerThread.Start();
            //sets the state of the worker to be active
            active = true;
        }
        public void Work()
        {
            //as long the worker is on duty he will awit a command Maybe this is bussy working.
            while (active)
            {
                if (carryingResource)
                {

                }
                if (working)
                {
                    MoveTo(destination.X, destination.Y);
                    Mine();
                    working = false;
                }
                else if (moving)
                {
                    MoveTo(destination.X, destination.Y);
                    moving = false;
                }
            }
        }   
        public void Mine()
        {
            // wait until acess to the mine is granted
            currentMine.EnteranceKey.WaitOne();
            GameWorld.RemoveGameObject.Add(this);
            Thread.Sleep(3000);//simulates the worker mining
            carryingResource = true;
            GameWorld.AddGameObject.Add(this);
            // releaser key so ohter members ca acces the mine
            currentMine.EnteranceKey.Release();
        }
        public void MoveTo(float x, float y)
        {
            position.X = x;
            position.Y = y;
        }
        #endregion

    }
}
