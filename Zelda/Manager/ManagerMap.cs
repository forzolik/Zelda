using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zelda.Map;

namespace Zelda.Manager
{
    class ManagerMap
    {
        private List<Tile> _tiles;
        private List<TileCollision> _tileCollisions;
        private string _mapname;

        public ManagerMap(string mapName)
        {
            _mapname = mapName;
            _tiles = new List<Tile>();
            _tileCollisions = new List<TileCollision>();
        }

        public void LoadContent(ContentManager content)
        {
            var tiles = new List<Tile>();
            XMLSerialization.LoadXML(out tiles, string.Format("Content\\{0}_map.xml", _mapname));
            if (tiles != null)
            {
                _tiles = tiles;
                _tiles.Sort((n, i) =>
                { return n.ZPos > i.ZPos ? 1 : 0; }
                );
                foreach (var tile in _tiles)
                {
                    tile.LoadContent(content);
                }
            }

            var tileCollision = new List<TileCollision>();
            XMLSerialization.LoadXML(out tileCollision, string.Format("Content\\{0}_map_collision.xml", _mapname));
            if (tileCollision != null)
            {
                _tileCollisions = tileCollision;
            }
        }

        public bool CheckCollision(Rectangle rectangle)
        {
            return _tileCollisions.Any(tile => tile.Intersect(rectangle));
        }

        public void Update(double  gametime)
        {
            foreach (var tile in _tiles)
            {
                tile.Update(gametime);
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            foreach (var tile in _tiles)
            {
                tile.Draw(spritebatch);
            }
        }
    }
}
