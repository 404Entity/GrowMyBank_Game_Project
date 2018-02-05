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
    class Mine : GameObject
    {
        #region Fields
        private int resourceAmount;
        public Mutex EnteranceKey;

        #endregion

        #region Property


        public int ResourceAmount { get { return resourceAmount; } set { resourceAmount = value; } }

        #endregion
        #region Constructor
        public Mine(Vector2 position, string spritePath, float scaleFactor, string name) : base(position, spritePath, scaleFactor, name)
        {

        }
        #endregion

        #region Methods


        #endregion
    }
}
