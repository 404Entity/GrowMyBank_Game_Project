using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Rts_project_base
{
    class Worker : GameObject
    {
        bool carringResource;
        int resourceAmount;

        public Worker()
        {
            Thread workerThread = new Thread(Work);
            workerThread.Start();
        }

        public void Work()
        {

        }
        public void Mine()
        {

        }
    }
}
