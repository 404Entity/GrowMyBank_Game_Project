using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rts_project_base
{
    class Worker : GameObject
    {
        #region Fields
        private float speed;
        private int workers;

        #endregion

        #region Property
        public Worker()
        {
        }
        public int Workers { get => workers; set => workers = value; }
        public float Speed { get => speed; set => speed = value; }
        
        #endregion

        #region Methods


        #endregion

    }
}
