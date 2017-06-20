using Artemis;
using MMXEngine.Common.Enumerations;
using MMXEngine.Common.Extensions;
using MMXEngine.Contracts.Managers;
using MMXEngine.Contracts.States;
using MMXEngine.ECS.Components;

namespace MMXEngine.ECS.States.Player
{
    public class DashState: IPlayerState
    {
        private readonly EntityWorld _world;
        private readonly IInputManager _input;

        public DashState(EntityWorld world,
            IInputManager input)
        {
            _world = world;
            _input = input;
        }

        public void HandleInput(Entity player)
        {
            PlayerStateMap map = player.GetComponent<PlayerStateMap>();
            PlayerAction action = player.GetComponent<PlayerAction>();

            if (_input.IsDown(GameButton.Dash) &&
                action.CurrentDashLength <= action.MaxDashLength)
            {
                map.CurrentState = PlayerState.Dash;
            }
            else if(_input.IsDown(GameButton.Dash) &&
                action.CurrentDashLength > action.MaxDashLength)
            {
                if (!_input.IsDown(GameButton.MoveLeft) &&
                    !_input.IsDown(GameButton.MoveRight))
                {
                    map.CurrentState = PlayerState.Idle;
                }

            }
            else if (_input.IsUp(GameButton.Dash))
            {
                action.CurrentDashLength = 0.0f;
            }
        }

        public void EnterState(Entity player)
        {
            Sprite sprite = player.GetComponent<Sprite>();
            sprite.SetCurrentAnimation("Dash");
        }

        public void ExitState(Entity player)
        {
            Sprite sprite = player.GetComponent<Sprite>();
            sprite.SetCurrentAnimation("DashEnd");

            PlayerAction action = player.GetComponent<PlayerAction>();
            action.IsDashing = false;
        }

        public void ProcessState(Entity player)
        {
            Position position = player.GetComponent<Position>();
            Velocity velocity = player.GetComponent<Velocity>();
            PlayerAction action = player.GetComponent<PlayerAction>();

            if (position.Facing == Direction.Left)
            {
                velocity.X = -2.5f;
            }
            else
            {
                velocity.X = 2.5f;
            }

            action.CurrentDashLength += _world.DeltaSeconds();

            if (action.CurrentDashLength > action.MaxDashLength)
            {
                velocity.X = 0.0f;
                action.IsDashing = false;
            }
            else
            {
                action.IsDashing = true;
            }
        }
    }
}
