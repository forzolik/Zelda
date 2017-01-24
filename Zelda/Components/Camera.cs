using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Manager;
using Microsoft.Xna.Framework;

namespace Zelda.Components
{
    class Camera : Component
    {
        public override ComponentType ComponentType
        {
            get
            {
                return ComponentType.Camera;
            }
        }

        private ManagerCamera _managerCamera;

        public Camera(ManagerCamera managerCamera)
        {
            _managerCamera = managerCamera;
        }

        public bool GetPosition(Vector2 position, out Vector2 newPosition)
        {
            newPosition = _managerCamera.WorldToScreenPosition(position);
            return _managerCamera.InScreenCheck(position); 
        }

        public void MoveCamera(Direction direction)
        {
            _managerCamera.Move(direction);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
        }

        public override void Update(double gameTime)
        {
        }
    }
}
