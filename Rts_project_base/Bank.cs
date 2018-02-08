using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;
using System.Threading;

namespace Rts_project_base
{
    class Bank : GameObject
    {
        #region Fields
        private static int coalCount;
        private static int goldCount;
        private static bool upgradeTwo = false;
        #endregion

        #region Property
        public static int CoalCount { get { return coalCount; } set { coalCount = value; } }
        public static int GoldCount { get { return goldCount; } set { goldCount = value; } }
        #endregion

        #region Constructor
        public Bank(Vector2 position,string spritePath, float scaleFactor, string name) : base(position,spritePath,scaleFactor,name)
        {
        }
        #endregion
        #region Methods
        public void Upgrade()
        {
            if (Bank.goldCount >= 500)
            {
                //Adds new worker plus new thread for it
                Worker worker = (new Worker(new System.Numerics.Vector2(300, 200), @"Images\worker_test..png", 0.2f, "Carl"));
                GameWorld.AddGameObject.Add(worker);

                upgradeTwo = true;

                if (upgradeTwo = true && Bank.goldCount >= 750)
                {

                    Thread.Sleep(2000); //Workers sleeper thread too
                }
            }

        #endregion
        }
    }
}
