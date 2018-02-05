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
    class LevelGenerator
    {
        
        
        const int tileSizeX = 50;
        const int tileSizeY = 30;
        private static int width = 16;
        private static int height = 16;


        int[,] multiArray = new int[width, height];
        
        public void LoadWorld(Graphics draw)
        {
            for (int i = 0; i < width; i++)
            {
                for (int a = 0; a < height; a++)
                {
                    multiArray[i, a] = 0;
                }
            }
            
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    switch (multiArray[x,y])
                    {
                        case 0:
                            draw.DrawImage(Image.FromFile(@"C:\Users\Morten\Documents\GitHub\GrowMyBank_Game_Project\Rts_project_base\Images\Tree.jpg"), new PointF(x * tileSizeX, y * tileSizeY));
                            break;

                        case 1:
                            Console.WriteLine("1");
                            break;

                        case 2:
                            Console.WriteLine("2");
                            break;

                        case 3:
                            Console.WriteLine("3");
                            break;

                        case 4:
                            Console.WriteLine("4");
                            break;

                        case 5:
                            Console.WriteLine("5");
                            break;

                        case 6:
                            Console.WriteLine("6");
                            break;
                    }   
                }
            }
            
            /*
            foreach (int number in multiArray)
            {
                switch (number)
                {
                    case 0:
                        draw.DrawImage(Image.FromFile(@"C:\Users\Morten\Documents\GitHub\GrowMyBank_Game_Project\Rts_project_base\Images\Tree.jpg"), new PointF(x * tileSizeX, y * tileSizeY));
                        break;

                    case 1:
                        Console.WriteLine("1");
                        break;

                    case 2:
                        Console.WriteLine("2");
                        break;

                    case 3:
                        Console.WriteLine("3");
                        break;
                }
            }
            */
        }
    }
}
