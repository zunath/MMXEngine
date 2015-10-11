using System.Linq;
using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.ECS.Components;

namespace MMXEngine.Systems.Draw
{
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Draw,
        Layer = 1)]
    public class SpriteRenderSystem: EntityProcessingSystem
    {
        private readonly SpriteBatch _spriteBatch;
        private Rectangle _sourceRectangle;
        
        public SpriteRenderSystem(SpriteBatch spriteBatch)
            : base(Aspect.All(typeof(Sprite)))
        {
            _spriteBatch = spriteBatch;
            _sourceRectangle = new Rectangle();
        }

        public override void Process(Entity entity)
        {
            Sprite sprite = entity.GetComponent<Sprite>();
            var animation = sprite.Animations[sprite.CurrentAnimationID];
            animation.CurrentFrameID++;

            if (animation.CurrentFrameID + 1 > animation.Frames.Count())
            {
                animation.CurrentFrameID = 0;
            }
            Frame frame = animation.Frames[animation.CurrentFrameID];

            _sourceRectangle.X = frame.X;
            _sourceRectangle.Y = frame.Y;
            _sourceRectangle.Width = frame.Width;
            _sourceRectangle.Height = frame.Height;

            _spriteBatch.Begin();
            _spriteBatch.Draw(sprite.Texture, sprite.Position, _sourceRectangle, Color.White);
            _spriteBatch.End();

        }
    }
}
