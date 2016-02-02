using System.Collections.Generic;
using Artemis.Interface;
using Microsoft.Xna.Framework.Graphics;
using TiledSharp;

namespace MMXEngine.ECS.Components
{
    public class Map : IComponent
    {
        public int TileWidth { get; set; }
        public int TileHeight { get; set; }
        public int TilesetTilesWide { get; set; }
        public int TilesetTilesHigh { get; set; }

        public TmxMap LevelMap { get; set; }
        public Texture2D Tileset { get; set; }
        public IEnumerable<CollisionBox> Collisions { get; set; }
    }
}
