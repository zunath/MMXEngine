using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using MMXEngine.Common.Enumerations;
using MMXEngine.Common.Extensions;
using MMXEngine.Contracts.Managers;
using MMXEngine.Contracts.States;
using MMXEngine.ECS.Components;

namespace MMXEngine.Systems.Update
{
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Update,
        Layer = 1)]
    public class PlayerStateSystem : EntityProcessingSystem
    {
        private readonly IInputManager _inputManager;
        private readonly EntityWorld _world;
        
        public PlayerStateSystem(IInputManager inputManager,
            EntityWorld world) 
            : base(Aspect.All(typeof(PlayerStateMap)))
        {
            _inputManager = inputManager;
            _world = world;
        }

        public override void Process(Entity entity)
        {
            PlayerStateMap stateMap = entity.GetComponent<PlayerStateMap>();
            stateMap.PreviousState = stateMap.CurrentState;

            if (_inputManager.IsDown(GameButton.MoveLeft))
            {
                stateMap.CurrentState = PlayerState.MoveLeft;
            }
            else if (_inputManager.IsDown(GameButton.MoveRight))
            {
                stateMap.CurrentState = PlayerState.MoveRight;
            }
            else
            {
                stateMap.CurrentState = PlayerState.Idle;
            }

            if (stateMap.CurrentState != stateMap.PreviousState)
            {
                stateMap.States[stateMap.PreviousState].ExitState(entity);
                stateMap.States[stateMap.CurrentState].EnterState(entity);
            }
            
            IPlayerState state = stateMap.States[stateMap.CurrentState];
            state.ProcessState(entity);

            //if (_inputManager.IsUp(GameButton.Dash) && action.IsDashing)
            //{
            //    action.IsDashing = false;
            //    action.CurrentDashLength = 0.0f;
            //    if (sprite.CurrentAnimationName != "Idle")
            //        sprite.SetCurrentAnimation("DashEnd");
            //    velocity.X = 0.0f;
            //}

            //if (_inputManager.IsDown(GameButton.Dash) && action.CurrentDashLength < action.MaxDashLength)
            //{
            //    sprite.SetCurrentAnimation("Dash");
            //    action.IsDashing = true;

            //    if (position.Facing == Direction.Right) velocity.X = 2.5f;
            //    else velocity.X = -2.5f;

            //    if (action.IsDashing)
            //    {
            //        action.CurrentDashLength += _world.DeltaSeconds();
            //    }
            //}

            //if (action.IsDashing &&
            //    action.CurrentDashLength >= action.MaxDashLength &&
            //    sprite.CurrentAnimationName == "Dash")
            //{
            //    sprite.SetCurrentAnimation("DashEnd");
            //    velocity.X = 0.0f;
            //}

            //if (action.IsDashing &&
            //    action.CurrentDashLength < action.MaxDashLength) return;

            //if (_inputManager.IsDown(GameButton.MoveRight))
            //{
            //    sprite.SetCurrentAnimation("Move");

            //    velocity.X = 1.5f;
            //    position.Facing = Direction.Right;
            //}
            //else if (_inputManager.IsDown(GameButton.MoveLeft))
            //{
            //    sprite.SetCurrentAnimation("Move");

            //    velocity.X = -1.5f;
            //    position.Facing = Direction.Left;
            //}
            //else if (sprite.CurrentAnimationName != "DashEnd")
            //{
            //    sprite.SetCurrentAnimation("Idle");
            //    velocity.X = 0;
            //}


        }
    }
}
