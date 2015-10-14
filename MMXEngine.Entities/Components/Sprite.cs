using System.Collections.Generic;
using Artemis.Interface;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.Common.Enumerations;

namespace MMXEngine.ECS.Components
{
    public class Sprite : IComponent
    {
        public Texture2D Texture { get; set; }
        public IDictionary<string, Animation> Animations { get; set; }
        public string CurrentAnimationName { get; set; }
        public float FrameActiveTime { get; set; }
        public Direction Facing { get; set; }

        public Sprite()
        {
            Animations = new Dictionary<string, Animation>();
        }
    }
}
