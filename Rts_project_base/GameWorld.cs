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
        public GameWorld(Graphics draws, Rectangle displayRectangle) // change to private to make Simpletom work as intended by for testing purpose leave it public 
        {
            this.backBuffer = BufferedGraphicsManager.Current.Allocate(draws, displayRectangle);
            this.draws = backBuffer.Graphics;
            gameObjectList = new List<GameObject>();
            Setup();
            Draw();
        }
        /*
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
        */
        #endregion

        #region Fields
        private Graphics draws;
        private BufferedGraphics backBuffer;
        private float currentFps;
        private DateTime endTime;
        private List<GameObject> gameObjectList;
        #endregion
        #region Properties
        public List<GameObject> GameObjectList
        {
            get { return gameObjectList; }
            set { gameObjectList = value; }
        }
        #endregion

        private void Setup()
        {
            //intialize the componets of the gameworld
            gameObjectList.Add(new Mine(new Vector2(1, 1), @"Images\Mine_Test1..png", 1));
            gameObjectList.Add(new Worker(new Vector2(10, 10), @"imagehere", 1));
            
            Form1.runGame = true;
        }
        public void Draw()
        {
            DrawContent();
       
        }
        public void DrawContent()
        {
            ///<summary>
            ///Draws the games ui
            /// </summary>
            //Draw the Graphics of the Game
            draws.Clear(Color.White);

            foreach (GameObject drawable in gameObjectList)
            {
                drawable.Draw(draws);
                DrawUi();

            }
            backBuffer.Render();
        }
        public void DrawUi()
        {
            Font f = new Font("Arial", 16);
            draws.DrawString(string.Format("FPS: {0}", currentFps), f, Brushes.Black, 550, 0);
        }
        public void Update()
        {
            ///<summary>
            ///Updates the state of the gameobjects
            /// </summary>
            /*
             foreach(GameObject gO in gameObjectList)
             {
             gO.Update(Fps)
             {

             }
            }
             */

        }
        public void Gameloop()
        {
            DateTime startime = DateTime.Now;
            TimeSpan deltaTime = startime - endTime;
            int miliSecond = deltaTime.Milliseconds > 0 ? deltaTime.Milliseconds : 1;
            currentFps = 1000 / miliSecond;
            endTime = DateTime.Now;
            Draw();
            Update();
        }
    }
}