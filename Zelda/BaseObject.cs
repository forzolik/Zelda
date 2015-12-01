﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda
{
    class BaseObject
    {
        public int Id { get; set; }
        private readonly List<Component> _components;

        public BaseObject() {
            _components = new List<Component>();
        }

        public TComponentType GetComponent<TComponentType>(ComponentType componentType) where TComponentType : Component {
            return _components.Find(c => c.ComponentType == componentType) as ComponentType;
        }

        public void RemoveComponent(Component component) {
            _components.Remove(component);
        }

        public void Update(double gameTime) {
            foreach (var component in _components)
            {
                component.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spritebatch) {
            foreach (var component in _components)
            {
                component.Draw(spritebatch);
            }
        }
    }
}