using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Zelda.Components.Enemies
{
    class OctorokBullet
    {
        private Sprite _sprite;
        private BaseObject _player;
        private Direction _direction;
        private float _speed;
        private Collision _collision;
        public bool Dead { get; private set; }

        public OctorokBullet(Sprite sprite, Collision collision, BaseObject player, Direction direction)
        {

            _sprite = sprite;
            _player = player;
            _direction = direction;
            _speed = 1.5f;
            _collision = collision;

        }

        public void Update(double gameTime)
        {
            switch (_direction)
            {
                case Direction.Left:
                    _sprite.Move(-1 * _speed, 0);
                    break;
                case Direction.Right:
                    _sprite.Move(1 * _speed, 0);
                    break;
                case Direction.Up:
                    _sprite.Move(0, -1 * _speed);
                    break;
                case Direction.Down:
                    _sprite.Move(0, 1 * _speed);
                    break;
            }

            if(_collision.CheckCollision(new Rectangle((int)_sprite.Position.X, (int)_sprite.Position.Y, _sprite.Width, _sprite.Height), false))
            {
                Dead = true;
            }

        }


        public void Draw(SpriteBatch spritebatch)
        {
            _sprite.Draw(spritebatch);
        }

        
    }
}
