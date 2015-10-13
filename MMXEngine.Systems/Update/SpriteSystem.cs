using System.Linq;
using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using Microsoft.Xna.Framework;
using MMXEngine.Common.Enumerations;
using MMXEngine.Common.Extensions;
using MMXEngine.ECS.Components;
using MMXEngine.Interfaces.Managers;

namespace MMXEngine.Systems.Update
{
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Update,
        Layer = 1)]
    public class SpriteSystem: EntityProcessingSystem
    {
        private readonly EntityWorld _world;
        private readonly IInputManager _inputManager;

        public SpriteSystem(EntityWorld world, IInputManager inputManager)
            : base(Aspect.All(
                typeof(Sprite),
                typeof(Renderable),
                typeof(Position)))
        {
            _world = world;
            _inputManager = inputManager;
        }

        public override void Process(Entity entity)
        {
            Renderable renderable = entity.GetComponent<Renderable>();
            Sprite sprite = entity.GetComponent<Sprite>();
            Position position = entity.GetComponent<Position>();
            Animation animation = sprite.Animations[sprite.CurrentAnimationID];
            Frame frame = animation.Frames[animation.CurrentFrameID];

            // Determine next frame to use.
            sprite.FrameActiveTime += _world.DeltaSeconds();

            //if(_inputManager.IsPressed(GameButton.Shoot)) // DEBUGGING
            if (sprite.FrameActiveTime > frame.Length)
            {
                animation.CurrentFrameID++;
                sprite.FrameActiveTime = 0;
                frame.HasRunOnce = true;
            }

            while (frame.OnlyRunOnce && frame.HasRunOnce)
            {
                animation.CurrentFrameID++;
                frame = animation.Frames[animation.CurrentFrameID];
            }

            // Update renderable
            renderable.Source = new Rectangle(frame.X, frame.Y, frame.Width, frame.Height);
            renderable.Texture = sprite.Texture;
            renderable.Position = new Vector2(position.X + frame.OffsetX, position.Y + frame.OffsetY);
        }
    }
}
