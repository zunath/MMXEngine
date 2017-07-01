using Artemis.Interface;
using Microsoft.Xna.Framework.Graphics;

namespace MMXEngine.ECS.Components
{
    public class StaticGraphic: IComponent
    {
        public Texture2D Texture { get; set; }
        public bool Scrolls { get; set; }
    }
}
