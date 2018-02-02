using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;

namespace Rts_project_base
{
    public partial class Form1 : Form
    {
#region Fields
        private GameWorld gm;
        private Graphics dc;
        #endregion
        public Graphics DC
        {
            get { return dc; }
        }
        public Form1()
        {
            
            InitializeComponent();
            //initialize a new thread to run the Gameloop
 
            //initialize the Gameworld
            gm = GameWorld.Instance;
            
        }
        private void initLoop()
        {
            Thread looperThread = new Thread(gamelooper);
            looperThread.IsBackground = true;
            looperThread.Start();
        }

        static bool runGame = true;
        private void gamelooper()
        {
            ///<remarks>CurrentThread = looperThread</remarks>
            while (runGame)
            {
                MessageBox.Show("Hello from Loop Thread");
                Thread.Sleep(5000);
                gm.Gameloop();
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            if (dc == null)
            {
                dc = CreateGraphics();
            }
            //initialize the game loop
            initLoop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread t1 = new Thread(HelloFromTheOhterSide);
            t1.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = "Whaa";
        }
        private void HelloFromTheOhterSide()
        {
            label1.Invoke((MethodInvoker)delegate{ label1.Text = "Get out off here "; });
        }
    }
}
