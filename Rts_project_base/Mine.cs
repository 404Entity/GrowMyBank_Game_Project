using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rts_project_base
{
    class Mine : GameObject
    {
        #region Fields
        private int coalAmount;
        

        #endregion

        #region Property
        public Mine()
        {
        }

        public int CoalAmount { get { return coalAmount; } set {coalAmount = value; } }

        #endregion

        #region Methods


        #endregion
    }
}
