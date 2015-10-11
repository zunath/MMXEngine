using Artemis.Interface;

namespace MMXEngine.ECS.Components
{
    public class Tile: IComponent
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int TextureX { get; set; }
        public int TextureY { get; set; }
    }
}
