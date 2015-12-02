using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Zelda.Components
{
    class Sprite : Component
    {
        private Texture2D _texture;
        private int _width;
        private int _height;
        private Vector2 _position;


        public override ComponentType ComponentType
        {
            get
            {
                return ComponentType.Sprite;
            }
        }

        public Sprite(Texture2D texture, int width, int height, Vector2 position) {
            _texture = texture;
            _width = width;
            _height = height;
            _position = position;
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(_texture, new Rectangle((int)_position.X, (int)_position.Y, _width, _height), Color.White);
        }

        public override void Update(double gameTime)
        {
        }
    }
}
