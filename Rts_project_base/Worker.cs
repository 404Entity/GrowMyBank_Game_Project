using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using System.Numerics;

namespace Rts_project_base
{
    class Worker : GameObject
    {
        #region Fields
        private float speed;
        private int workers;
        #endregion
        #region Property
        public int Workers { get {return workers;} set { workers = value;} }
        public float Speed { get { return speed; } set { speed = value; } }
        #endregion
        #region Constructor
        public Worker(Vector2 position,string spritePath, float scaleFactor): base(position,spritePath,scaleFactor)
        {
        }
        #endregion
        #region Methods

        private void InitWorkerThread()
        {
            Thread WorkerThread = new Thread(Work);

            WorkerThread.Start();
        }
        public void Work()
        {
            while (true)
            {

            }
        }
        public  void Mine()
        {

        }
        #endregion

    }
}
