using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rts_project_base
{
    class Mine : GameObject
    {
        private bool busy = false;
        private string name = "Mine";
        private string Image = "";




        //key 
        public void Busy(bool busy)
        {
            if(busy == true)
            {

            }
            else
            {

            }
        }

        public Mine(string name, bool busy)
        {
            this.busy = busy;
            this.name = name;
        }

    }
}
