﻿using System;
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
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Vector2 Position { get; private set; }


        public override ComponentType ComponentType
        {
            get
            {
                return ComponentType.Sprite;
            }
        }

        public Sprite(Texture2D texture, int width, int height, Vector2 position) {
            _texture = texture;
            Width = width;
            Height = height;
            Position = position;
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            var camera = GetComponent<Camera>(ComponentType.Camera);
            Vector2 position;
            if (!(camera != null && camera.GetPosition(Position, out position)))
                position = Position;

            var animation = GetComponent<Animation>(ComponentType.Animation);
            if (animation != null)
            {
                spritebatch.Draw(_texture, new Rectangle((int)position.X, (int)position.Y, Width, Height),animation.TextureRectangle, Color.White);
            }
        
            else
            {
                spritebatch.Draw(_texture, new Rectangle((int)position.X, (int)position.Y, Width, Height), Color.White);
            }
        }

        public override void Update(double gameTime)
        {
        }

        internal void Move(float x, float y)
        {
            Position = new Vector2(Position.X + x, Position.Y + y);

            var animation = GetComponent<Animation>(ComponentType.Animation);
            if (animation == null)
            {
                return;
            }

            if (x > 0)
            {
                animation.ResetCounter(State.Walking, Direction.Right);
            }
            else if (x < 0)
            {
                animation.ResetCounter(State.Walking, Direction.Left);
            }
            else if (y > 0)
            {
                animation.ResetCounter(State.Walking, Direction.Down);
            }
            else if (y < 0)
            {
                animation.ResetCounter(State.Walking, Direction.Up);
            }
        }
    }
}
