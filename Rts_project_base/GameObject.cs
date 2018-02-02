using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;

namespace Rts_project_base
{
    class GameObject
    {
        Vector2 position;
        Image sprite;
        Vector2 originPoint;
        

        public GameObject()
        {
            originPoint.X = position.X + sprite.Width / 2;
            originPoint.Y = position.Y + sprite.Height / 2;
        }
        public void Update()
        {
            position.X += 2;
        }
        public void Draw()
        {
            
        }
    }
}
