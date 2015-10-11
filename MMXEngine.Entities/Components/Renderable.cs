using Artemis.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MMXEngine.ECS.Components
{
    public class Renderable : IComponent
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle Source { get; set; }
    }
}
