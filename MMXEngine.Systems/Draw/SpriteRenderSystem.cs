using System;
using System.Linq;
using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.Common.Extensions;
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
        private readonly EntityWorld _world;
        
        public SpriteRenderSystem(SpriteBatch spriteBatch, EntityWorld world)
            : base(Aspect.All(typeof(Sprite), typeof(Position)))
        {
            _spriteBatch = spriteBatch;
            _sourceRectangle = new Rectangle();
            _world = world;
        }

        public override void Process(Entity entity)
        {
            Sprite sprite = entity.GetComponent<Sprite>();
            Position position = entity.GetComponent<Position>();
            var animation = sprite.Animations[sprite.CurrentAnimationID];
            float delta = _world.DeltaSeconds();
            Frame frame = animation.Frames[animation.CurrentFrameID];

            sprite.FrameActiveTime += _world.DeltaSeconds();

            if (sprite.FrameActiveTime > frame.Length)
            {
                animation.CurrentFrameID++;
                sprite.FrameActiveTime = 0;
            }
            
            if (animation.CurrentFrameID + 1 > animation.Frames.Count())
            {
                animation.CurrentFrameID = 0;
            }


            _sourceRectangle.X = frame.X;
            _sourceRectangle.Y = frame.Y;
            _sourceRectangle.Width = frame.Width;
            _sourceRectangle.Height = frame.Height;

            _spriteBatch.Begin();
            _spriteBatch.Draw(sprite.Texture, new Vector2(position.X, position.Y), _sourceRectangle, Color.White);
            _spriteBatch.End();

        }
    }
}
