using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Numerics;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace Rts_project_base
{
    sealed class GameWorld
    {
        //only allow one instance of the gameworld class. useing Simpleton Pattern
        #region Simpleton
        public static object kGameworldInstance = new object();
        private static GameWorld _instance;
        private GameWorld()
        {
            myDelegate = new AddListItem(AddListMethod);
        }
        public static GameWorld Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (kGameworldInstance)
                    {
                        
                        //Creates the Gameworld Instance
                        _instance = new GameWorld();
                    }
                }
                return _instance;
            }
        }
        #endregion

        #region Fields
        private Graphics draws;
        private BufferedGraphics backbuffer;
        private float currentFps;
        private DateTime endTime;
        public delegate void AddListItem();
        public AddListItem myDelegate;
        #endregion
        #region Properties
        #endregion
        public void AddListMethod()
        {

        }
        private void Setup()
        {
            //intialize the componets of the gameworld

            Form1.runGame = true;
        }

        public void DrawContent()
        {
            ///<summary>
            ///Draws the games ui
            /// </summary>
            //Draw the Graphics of the Game
            draws.Clear(Color.White);
            /*
             foreach(GameObject drawable in gameObjectList)
             {
            drawable.Draw(); 
            }
             */
        }
        public void DrawUi()
        {

        }
        public void Update()
        {
            ///<summary>
            ///Updates the state of the gameobjects
            /// </summary>
            /*
             foreach(GameObject gO in gameObjectList)
             {
             
            }
             */
            ///MessageBox.Show("Hello from GameWorld","oH");
        }
        public void Gameloop()
        {
            DateTime startime = DateTime.Now;
            TimeSpan deltaTime = startime - endTime;
            int miliSecond = deltaTime.Milliseconds > 0 ? deltaTime.Milliseconds : 1;
            
               
            Update();
        }
    }
}