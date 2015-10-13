using Artemis.Interface;
using Microsoft.Xna.Framework;

namespace MMXEngine.ECS.Components
{
    public class CollisionBox : IComponent
    {
        public Rectangle Bounds { get; set; }
        public bool IsVisible { get; set; }
        public Color Color { get; set; }

        public CollisionBox()
        {
            Color = Color.Red;
        }
    }
}
