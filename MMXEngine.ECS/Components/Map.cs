using Artemis.Interface;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using MMXEngine.ECS.Data;

namespace MMXEngine.ECS.Components
{
    public class Map : IComponent
    {
        public Texture2D Spritesheet { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public TileData[,] Tiles { get; set; }
        public Song BGM { get; set; }
    }
}
