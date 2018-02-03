using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Bank()
        {
        }
        #endregion
        #region Methods
        public void Upgrade()
        {

        }

        #endregion
    }
}
