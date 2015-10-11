using System.Linq;
using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using Microsoft.Xna.Framework;
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
            Animation animation = sprite.Animations[sprite.CurrentAnimationID];
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
            
            renderable.Source = new Rectangle(frame.X, frame.Y, frame.Width, frame.Height);
            renderable.Texture = sprite.Texture;
            renderable.Position = new Vector2(position.X, position.Y);
        }
    }
}
