using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Numerics;
using System.Drawing;

namespace Rts_project_base
{
    abstract class GameObject
    {
// Create a general base for all objects game.
        #region Fields
        protected Image sprite;
        protected Vector2 position;
        protected Vector2 originPoint;
        protected float scaleFactor;
        protected List<Image> animationFrames;
        #endregion

        #region Property
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        #endregion
        #region Constructor
        public GameObject(Vector2 position, string spritePath, float scaleFactor)
        {
            this.position = position;
            this.scaleFactor = scaleFactor;
            string[] Imagepaths = spritePath.Split(';');

            this.animationFrames = new List<Image>();

            foreach (string path in Imagepaths)
            {
                Image img = Image.FromFile(path);
                animationFrames.Add(img);
            }

            this.sprite = this.animationFrames[0];
        }
        #endregion


        #region Methods
        public virtual void Draw(Graphics dc)
        {
            dc.DrawImage(sprite, position.X, position.Y, sprite.Width * scaleFactor, sprite.Height * scaleFactor);
#if DEBUG
            dc.DrawRectangle(new Pen(Brushes.Green), position.X, position.Y, sprite.Width, sprite.Height);
#endif
        }

        public virtual void Update()
        {
            CalcCenterPoint();
        }
        public void CalcCenterPoint()
        {
            originPoint.X = position.X + (sprite.Width / 2);
            originPoint.Y = position.Y + (sprite.Height / 2);
        }
        #endregion

    }
}

