using Artemis.Interface;
using Microsoft.Xna.Framework;

namespace MMXEngine.ECS.Components
{
    public class RenderableRectangle: IComponent
    {
        public Rectangle Rect { get; set; }
        public Color Color { get; set; }
        public int TileOffsetX { get; set; }
        public int TileOffsetY { get; set; }

        public RenderableRectangle(int x, int y , int width, int height, Color color)
        {
            Rect = new Rectangle(x, y, width, height);
            Color = color;
        }
    }
}
