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
        public string CurrentAnimationName { get; private set; }
        public float FrameActiveTime { get; set; }
        public Direction Facing { get; set; }

        public Sprite()
        {
            Animations = new Dictionary<string, Animation>();
        }

        public void SetCurrentAnimation(string animationName)
        {
            if (CurrentAnimationName != null && CurrentAnimationName != animationName)
            {
                foreach (Frame frame in Animations[CurrentAnimationName].Frames)
                {
                    frame.HasRunOnce = false;
                }
                Animations[animationName].CurrentFrameID = 0;
            }

            CurrentAnimationName = animationName;
        }
    }
}
