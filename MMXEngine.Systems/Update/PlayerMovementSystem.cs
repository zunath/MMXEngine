using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using MMXEngine.Common.Attributes;
using MMXEngine.Common.Enumerations;
using MMXEngine.Common.Extensions;
using MMXEngine.ECS.Components;
using MMXEngine.Interfaces.Managers;

namespace MMXEngine.Systems.Update
{
    [LoadableSystem(4)]
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Update,
        Layer = 1)]
    public class PlayerMovementSystem : EntityProcessingSystem
    {
        private readonly IInputManager _inputManager;
        private readonly EntityWorld _world;
        
        public PlayerMovementSystem(IInputManager inputManager,
            EntityWorld world) 
            : base(Aspect.All(typeof(Velocity),
                typeof(Position),
                typeof(PlayerAction),
                typeof(Sprite)))
        {
            _inputManager = inputManager;
            _world = world;
        }

        public override void Process(Entity entity)
        {
            Velocity velocity = entity.GetComponent<Velocity>();
            PlayerAction action = entity.GetComponent<PlayerAction>();
            Sprite sprite = entity.GetComponent<Sprite>();
            Position position = entity.GetComponent<Position>();
            
            if (_inputManager.IsUp(GameButton.Dash) && action.IsDashing)
            {
                action.IsDashing = false;
                action.CurrentDashLength = 0.0f;
                if(sprite.CurrentAnimationName != "Idle")
                    sprite.SetCurrentAnimation("DashEnd");
                velocity.X = 0.0f;
            }

            if (_inputManager.IsDown(GameButton.Dash) && action.CurrentDashLength < action.MaxDashLength)
            {
                sprite.SetCurrentAnimation("Dash");
                action.IsDashing = true;

                if (position.Facing == Direction.Right) velocity.X = 2.5f;
                else velocity.X = -2.5f;
                
                if (action.IsDashing)
                {
                    action.CurrentDashLength += _world.DeltaSeconds();
                }
            }

            if (action.IsDashing &&
                action.CurrentDashLength >= action.MaxDashLength &&
                sprite.CurrentAnimationName == "Dash")
            {
                sprite.SetCurrentAnimation("DashEnd");
                velocity.X = 0.0f;
            }

            if (action.IsDashing && 
                action.CurrentDashLength < action.MaxDashLength) return;
            
            if (_inputManager.IsDown(GameButton.MoveRight))
            {
                sprite.SetCurrentAnimation("Move");

                velocity.X = 1.5f;
                position.Facing = Direction.Right;
            }
            else if (_inputManager.IsDown(GameButton.MoveLeft))
            {
                sprite.SetCurrentAnimation("Move");

                velocity.X = -1.5f;
                position.Facing = Direction.Left;
            }
            else if(sprite.CurrentAnimationName != "DashEnd")
            {
                sprite.SetCurrentAnimation("Idle");
                velocity.X = 0;
            }
            
            
        }
    }
}
