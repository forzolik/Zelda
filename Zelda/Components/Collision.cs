using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Manager;
using Microsoft.Xna.Framework;

namespace Zelda.Components
{
    class Collision : Component
    {
        private ManagerMap _managerMap;

        public Collision(ManagerMap managerMap)
        {
            _managerMap = managerMap;
        }

        public override ComponentType ComponentType
        {
            get
            {
                return ComponentType.Collision;
            }
        }

        public bool CheckCollision(Rectangle rectangle)
        {
           return _managerMap.CheckCollision(rectangle);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
        }

        public override void Update(double gameTime)
        {
        }
    }
}
