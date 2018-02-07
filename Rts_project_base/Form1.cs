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
using System.Numerics;

namespace Rts_project_base
{
    public partial class Form1 : Form
    {
        #region Fields
        private GameWorld gm;
        private Graphics dc;
        private Rectangle displayRectangle = new Rectangle(0,0,960,540);
        private static bool upgradeTwo = false;
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
            
            
        }
        private void initLoop()
        {
            Thread looperThread = new Thread(gamelooper);
            looperThread.IsBackground = true;
            looperThread.Start();
        }

        public static bool runGame = true;
        private void gamelooper()
        {
            ///<remarks>CurrentThread = looperThread</remarks>
            while (runGame)
            {
                //MessageBox.Show("Hello from Loop Thread");
                //Thread.Sleep(5);
                gm.Gameloop();
            }
        }
        
        private void Form1_Load_1(object sender, EventArgs e)
        {

            if (dc == null)
            {
                dc = CreateGraphics();
            }
            //gm = GameWorld.Instance;
            gm = new GameWorld(CreateGraphics(), displayRectangle);
            //initialize the game loop
            initLoop();
        }
        private void SetupUi()
        {
            button1.Text = "Show text";
            button2.Text = "Buy Worker";
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
            //test code
            label1.Invoke((MethodInvoker)delegate{ label1.Text = "Get out off here "; });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //buy worker Button

            //Worker = new Worker()
        }

        private void Upgrade_Click(object sender, EventArgs e)
        {
            if(Bank.goldCount >= 500)
            {
                Upgrade.Visible = true;
                GameWorld.gameObjectList.Add(new Worker(new Vector2(10, 10), @"imagehere", 1,"john"));
                Worker.workerAmount = 3;
                upgradeTwo = true; 

                if(upgradeTwo = true && Bank.goldCount >= 750)
                {
                    Upgrade.Visible = true;
                    Thread.Sleep(2000);
                }
            }
            
            else
            {
                Upgrade.Visible = false;
            }
            Upgrade.Visible = false;
        }
    }
}
