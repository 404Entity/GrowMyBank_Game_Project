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
        private string name = "GoldMine";
        private string Image = "";
        private int coal = 1;
        private int gold = 2; //Change value




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

        public GoldMine(string name, bool busy, int gold)
        {
            this.busy = busy;
            this.name = name;
            this.gold = gold;
        }

    }
}
