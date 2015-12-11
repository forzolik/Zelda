using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Manager;
using Microsoft.Xna.Framework;

namespace Zelda.Components.Movement
{
    class AIMovementRandom : Component
    {
        private Direction _currentDirection;
        private double _counter;
        private readonly int _frequency;
        private float _speed;

        public AIMovementRandom(int frequency, float speed = 1.5f)
        {
            _frequency = frequency;
            _speed = speed;
            ChangeDirecion();
        }



        public override ComponentType ComponentType
        {
            get
            {
                return ComponentType.AIMovement;
            }
        }

        public override void Draw(SpriteBatch spritebatch)
        {
        }

        public override void Update(double gameTime)
        {
            var sprite = GetComponent<Sprite>(ComponentType.Sprite);
            if (sprite == null)
            {
                return;
            }
            _counter += gameTime;
            if(_counter > _frequency)
            {

                ChangeDirecion();
            }

            var collision = GetComponent<Collision>(ComponentType.Collision);
            var x = 0f;
            var y = 0f;

            switch (_currentDirection)
            {
                case Direction.Left:
                    x = -1 * _speed;
                    break;
                case Direction.Right:
                    x = 1 * _speed;
                    break;
                case Direction.Up:
                    y = -1 * _speed;
                    break;
                case Direction.Down:
                    y = 1 * _speed;
                    break;
            }
            if (collision.CheckCollision(new Rectangle((int)(sprite.Position.X + x), (int)(sprite.Position.Y + y), sprite.Width, sprite.Height)))
            {
                ChangeDirecion();
                return;
            }
            sprite.Move(x, y);



        }

        private void ChangeDirecion()
        {
            _counter = 0;
            _currentDirection = (Direction)ManagerFunction.Random(0, 3);
        }
    }
}
