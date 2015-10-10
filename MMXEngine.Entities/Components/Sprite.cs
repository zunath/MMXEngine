using System.Collections.Generic;
using Artemis;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MMXEngine.ECS.Components
{
    public class Sprite : ComponentPoolable
    {
        public Texture2D Texture { get; set; }
        public IEnumerable<Animation> Animations { get; set; }
        public Vector2 Position { get; set; }
    }
}
