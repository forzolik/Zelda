using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Zelda.Components
{
    class Animation : Component
    {
        public override ComponentType ComponentType
        {
            get
            {
                return ComponentType.Animation;
            }
        }

        private int _width;
        private int _height;
        public Rectangle TextureRectangle { get; set; }
        public Direction CurrentDirection;
        private State _currentState;
        private double _counter;
        private int _anumationIndex;

        public Animation(int width, int height)
        {
            _width = width;
            _height = height;
            _counter = 0;
            _anumationIndex = 0;
            _currentState = State.Standing;
            TextureRectangle = new Rectangle(_width * _anumationIndex, 0, _width, _height); //My addition draw on load.
        }

        public override void Draw(SpriteBatch spritebatch)
        {

        }

        public override void Update(double gameTime)
        {
            switch (_currentState)
            {
                //case State.Standing:
                //    break;
                case State.Walking:
                    _counter += gameTime;
                    if (_counter > 200)
                    {
                        ChangeState();
                        _counter = 0;
                    }
                    break;
            }
        }

        public void ResetCounter(State state, Direction direction)
        {
            if (CurrentDirection != direction)
            {
                _counter = 1000;
                _anumationIndex = 0;
            }
            _currentState = state;
            CurrentDirection = direction;
        }

        private void ChangeState()
        {
            switch (CurrentDirection)
            {
                case Direction.Left:
                    TextureRectangle = new Rectangle(_width * _anumationIndex, _height * 2, _width, _height);
                    break;
                case Direction.Right:
                    TextureRectangle = new Rectangle(_width * _anumationIndex, _height * 3, _width, _height);
                    break;
                case Direction.Up:
                    TextureRectangle = new Rectangle(_width*_anumationIndex, _height, _width, _height);
                    break;
                case Direction.Down:
                    TextureRectangle = new Rectangle(_width * _anumationIndex, 0, _width, _height);
                    break;
                
            }

            _anumationIndex = _anumationIndex == 0 ? 1 : 0;
            _currentState = State.Standing;
        }
    }
}
