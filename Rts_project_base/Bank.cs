using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;

namespace Rts_project_base
{
     

    class Bank : GameObject
    {
        #region Fields
        private int coalCount;
        private int goldCount;
        #endregion

        #region Property
        public int CoalCount { get { return coalCount; } set { coalCount = value; } }
        public int GoldCount { get { return goldCount; } set { goldCount = value; } }
        #endregion

        #region Constructor
        public Bank(Vector2 position,string spritePath, float scaleFactor) : base(position,spritePath,scaleFactor)
        {
        }
        #endregion
        #region Methods
        public void Upgrade()
        {
            if(goldCount >= 500)
            {
               GameWorld.gameObjectList.Add(new Worker(new Vector2(10, 10), @"imagehere", 1));
            }

        }

        #endregion
    }
}
