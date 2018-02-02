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
        public Bank()
        {
        }
        public int CoalCount { get => coalCount; set => coalCount = value; }
        public int GoldCount { get => goldCount; set => goldCount = value; }
        #endregion

        #region Methods
        public void Upgrade()
        {

        }

        #endregion
    }
}
