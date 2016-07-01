using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using MMXEngine.Common.Attributes;
using MMXEngine.Common.Enumerations;
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
        
        public PlayerMovementSystem(IInputManager inputManager) 
            : base(Aspect.All(typeof(Velocity),
                typeof(Position),
                typeof(PlayerAction),
                typeof(Sprite)))
        {
            _inputManager = inputManager;
        }

        public override void Process(Entity entity)
        {
            Velocity velocity = entity.GetComponent<Velocity>();
            PlayerAction action = entity.GetComponent<PlayerAction>();
            Sprite sprite = entity.GetComponent<Sprite>();
            Position position = entity.GetComponent<Position>();
            
            if (_inputManager.IsDown(GameButton.Dash))
            {
                sprite.SetCurrentAnimation("Dash");

                if (position.Facing == Direction.Right)
                    velocity.X = 2.5f;
                else
                    velocity.X = -2.5f;
            }
            else if (_inputManager.IsDown(GameButton.MoveRight))
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
            else
            {
                sprite.SetCurrentAnimation("Idle");
                velocity.X = 0;
            }
            
            
        }
    }
}
