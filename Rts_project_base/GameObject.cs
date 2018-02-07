using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Numerics;
using System.Drawing;
using System.Windows.Forms;

namespace Rts_project_base
{
    public abstract class GameObject
    {
        // Create a general base for all objects game.
        #region Fields
        protected Image sprite;
        protected Vector2 position;
        protected Vector2 originPoint;
        protected float scaleFactor;
        protected List<Image> animationFrames;
        string objectName;
        #endregion

        #region Property
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public string ObjectName
        {
            get { return objectName; }
            set { objectName = value; }
        }
        #endregion
        #region Constructor
        public GameObject(Vector2 position, string spritePath, float scaleFactor, string name)
        {
            this.position = position;
            this.scaleFactor = scaleFactor;
            string[] Imagepaths = spritePath.Split(';');
            this.objectName = name;
            this.animationFrames = new List<Image>();

            foreach (string path in Imagepaths)
            {
                Image img = Image.FromFile(path);
                animationFrames.Add(img);
            }

            this.sprite = this.animationFrames[0];
        }

        public RectangleF CollisionBox
        {
            get
            {
                return new RectangleF(position.X, position.Y, sprite.Width * scaleFactor, sprite.Height * scaleFactor);
            }
        }
        #endregion


        #region Methods
        public virtual void Draw(Graphics dc)
        {
            dc.DrawImage(sprite, position.X, position.Y, sprite.Width * scaleFactor, sprite.Height * scaleFactor);
#if DEBUG
            if (ishovered)
            {
                dc.DrawRectangle(new Pen(Brushes.Yellow, 2), position.X, position.Y, sprite.Width * scaleFactor, sprite.Height * scaleFactor);
            }
            dc.DrawRectangle(new Pen(Brushes.Green), position.X, position.Y, sprite.Width * scaleFactor, sprite.Height * scaleFactor);
#endif
        }
        public bool ishovered;
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
        public bool CheckCords(float x, float y)
        {
            if (CollisionBox.Contains(x, y))
            {
                return true;
            }
            return false;
            //return CollisionBox.Contains(x, y);
        }
    }
}

