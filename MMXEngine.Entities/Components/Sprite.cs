using System.Collections.Generic;
using Artemis.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MMXEngine.ECS.Components
{
    public class Sprite : IComponent
    {
        public Texture2D Texture { get; set; }
        public IDictionary<int, Animation> Animations { get; set; }
        public Vector2 Position { get; set; }
        public int CurrentAnimationID { get; set; }

        public Sprite()
        {
            Animations = new Dictionary<int, Animation>();
        }
    }
}
