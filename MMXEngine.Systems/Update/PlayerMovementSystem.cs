using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using MMXEngine.Common.Enumerations;
using MMXEngine.ECS.Components;
using MMXEngine.Interfaces.Managers;

namespace MMXEngine.Systems.Update
{
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Update,
        Layer = 1)]
    public class PlayerMovementSystem : EntityProcessingSystem
    {
        private readonly IInputManager _inputManager;
        
        public PlayerMovementSystem(IInputManager inputManager) 
            : base(Aspect.All(typeof(Velocity),
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
            
            if (_inputManager.IsDown(GameButton.MoveRight))
            {
                velocity.X = 3;
                sprite.Facing = Direction.Right;
                sprite.CurrentAnimationName = "Move";
            }
            else if (_inputManager.IsDown(GameButton.MoveLeft))
            {
                velocity.X = -3;
                sprite.Facing = Direction.Left;
                sprite.CurrentAnimationName = "Move";
            }
            else
            {
                velocity.X = 0;
                sprite.CurrentAnimationName = "Idle";
            }

            if (_inputManager.IsDown(GameButton.Jump) && 
                !action.HasJumped && 
                !_inputManager.WasDownLastFrame(GameButton.Jump))
            {
                velocity.Y = -22.0f;
                action.HasJumped = true;
            }
            
        }
    }
}
