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
    public partial class GameForm : Form
    {
        #region Fields
        private GameWorld gm;
        private Graphics dc;
        private Rectangle displayRectangle;
        #endregion
        public Graphics DC
        {
            get { return dc; }
        }

        internal GameObject SelectedObject { get { return selectedObject; } set { selectedObject = value; } }

        public GameForm()
        {
            InitializeComponent();
            //initialize a new thread to run the Gameloop

            //initialize the Gameworld
            displayRectangle = new Rectangle(0, 0, 1300, 900);


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
                Cursormovement();
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            if (dc == null)
            {
                dc = CreateGraphics();
            }
            //gm = GameWorld.Instance;
            SetupUi();
            gm = new GameWorld(CreateGraphics(), displayRectangle);
            //initialize the game loop
            initLoop();
        }

        private void ActiveForm_MouseClick(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
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
            label1.Invoke((MethodInvoker)delegate { label1.Text = "Get out off here "; });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //buy worker Button

            Worker worker = (new Worker(new System.Numerics.Vector2(300, 200), @"C:\Users\MIKZ\Source\Repos\GrowMyBank_Game_Project\Rts_project_base\Images\worker_test..png", 0.2f, "john"));
            gm.AddGameObject.Add(worker);
        }

        public void Cursormovement()
        {
            label1.Invoke((MethodInvoker)delegate { label1.Text = Cursor.Position.X.ToString(); });
            label2.Invoke((MethodInvoker)delegate { label2.Text = Cursor.Position.Y.ToString(); });

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private GameObject destinationObject;
        private GameObject selectedObject;
        private void GameForm_MouseClick(object sender, MouseEventArgs e)
        {
            label3.Invoke((MethodInvoker)delegate { label3.Text = GameForm.MousePosition.X.ToString(); });
            label4.Invoke((MethodInvoker)delegate { label4.Text = GameForm.MousePosition.Y.ToString(); });

            string showString = "X" + Cursor.Position.X + " : " + "Y" + Cursor.Position.Y;
            //MessageBox.Show(showString);
            // If a worker is selected check if the new mouse click is on a building.
            if (selectedObject != null)
            {
                if (selectedObject is Worker)
                {
                    foreach (GameObject item in gm.GameObjectList)
                    {
                        if (item.CheckCords(Cursor.Position.X, Cursor.Position.Y))
                        {
                            if (item is Mine || item is Bank)
                            {
                                destinationObject = item;
                                MessageBox.Show(selectedObject.ObjectName + " go to" + destinationObject.ObjectName);
                            }

                        }
                        else if (item is Worker)
                        {

                        }
                        {
                            HandleWorker(selectedObject as Worker, Cursor.Position.X, Cursor.Position.Y);
                            break;
                        }
                    }
                }
            }
            foreach (GameObject item in gm.GameObjectList)
            {
                if (item.CheckCords(Cursor.Position.X, Cursor.Position.Y))
                {
                    if (item is Worker)
                    {

                        selectedObject = item;
                        //MessageBox.Show(selectedObject.ObjectName);
                    }


                }
            }
        }
        private void HandleWorker(Worker worker, float x, float y)
        {
            //Moves worker to location when no building is given
            worker.MoveTo(x, y);
            //bugged
            SelectedObject = null;

        }
        private void GameForm_MouseHover(object sender, EventArgs e)
        {
            foreach (GameObject item in gm.GameObjectList)
            {
                if (item.CheckCords(Cursor.Position.X, Cursor.Position.Y))
                {
                    item.ishovered = true;
                }
                else
                {
                    item.ishovered = false;
                }
            }
        }
    }
}
