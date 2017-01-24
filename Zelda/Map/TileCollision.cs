using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zelda.Manager;

namespace Zelda.Map
{
    public class TileCollision
    {
        public int XPos { get; set; }
        public int YPos { get; set; }
        public Rectangle Rectangle { get { return new Rectangle(XPos * 16, YPos * 16, 16, 16); } }

        public ManagerCamera ManagerCamera { get; set; }

        public bool Intersect(Rectangle rectangle)
        {
            var position = ManagerCamera.WorldToScreenPosition(new Vector2 (Rectangle.X, Rectangle.Y));
            return ManagerCamera.InScreenCheck(position) && rectangle.Intersects(new Rectangle((int)position.X, (int)position.Y, 16,16));
        }

        public TileCollision()
        {

        }

        public TileCollision(ManagerCamera managerCamera)
        {
            ManagerCamera = managerCamera;
        }
    }
}
