using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using Microsoft.Xna.Framework;
using MMXEngine.Common.Enumerations;
using MMXEngine.Common.Extensions;
using MMXEngine.ECS.Components;

namespace MMXEngine.Systems.Update
{
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Update,
        Layer = 1)]
    public class SpriteSystem: EntityProcessingSystem
    {
        private readonly EntityWorld _world;

        public SpriteSystem(EntityWorld world)
            : base(Aspect.All(
                typeof(Sprite),
                typeof(Renderable),
                typeof(Position)))
        {
            _world = world;
        }

        public override void Process(Entity entity)
        {
            Renderable renderable = entity.GetComponent<Renderable>();
            Sprite sprite = entity.GetComponent<Sprite>();
            Position position = entity.GetComponent<Position>();
            Animation animation = sprite.Animations[sprite.CurrentAnimationName];
            Frame frame = animation.Frames[animation.CurrentFrameID];

            // Determine next frame to use.
            sprite.FrameActiveTime += _world.DeltaSeconds();
            
            if (sprite.FrameActiveTime > frame.Length)
            {
                if (animation.CurrentFrameID == animation.Frames.Count - 1 &&
                    !string.IsNullOrEmpty(animation.NextAnimation))
                {
                    sprite.SetCurrentAnimation(animation.NextAnimation);
                    animation = sprite.Animations[sprite.CurrentAnimationName];
                    frame = animation.Frames[animation.CurrentFrameID];
                }
                else
                {
                    frame.HasRunOnce = true;
                    animation.CurrentFrameID++;
                    sprite.FrameActiveTime = 0;
                    frame = animation.Frames[animation.CurrentFrameID];
                }
            }
            
            while (frame.OnlyRunOnce && frame.HasRunOnce)
            {
                animation.CurrentFrameID++;
                frame = animation.Frames[animation.CurrentFrameID];
            }

            int offsetX = frame.OffsetX;
            int offsetY = frame.OffsetY;
            if (position.Facing == Direction.Left)
            {
                offsetX = -offsetX;
            }
            
            // Update renderable
            renderable.Source = new Rectangle(frame.X, frame.Y, frame.Width, frame.Height);
            renderable.Texture = sprite.Texture;
            renderable.Position = new Vector2(position.X + offsetX, position.Y + offsetY);
            renderable.Facing = position.Facing;
            renderable.ColorOverride = sprite.ColorOverride;
        }
    }
}
