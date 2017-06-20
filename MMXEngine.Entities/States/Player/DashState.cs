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
            PlayerCharacter character = player.GetComponent<PlayerCharacter>();

            if (_input.IsDown(GameButton.Dash) &&
                character.CurrentDashLength <= character.MaxDashLength)
            {
                map.CurrentState = PlayerState.Dash;
            }
            else if(_input.IsDown(GameButton.Dash) &&
                character.CurrentDashLength > character.MaxDashLength)
            {
                if (!_input.IsDown(GameButton.MoveLeft) &&
                    !_input.IsDown(GameButton.MoveRight))
                {
                    map.CurrentState = PlayerState.Idle;
                }

            }
            else if (_input.IsUp(GameButton.Dash))
            {
                character.CurrentDashLength = 0.0f;
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

            PlayerCharacter character = player.GetComponent<PlayerCharacter>();
            character.IsDashing = false;
        }

        public void ProcessState(Entity player)
        {
            Position position = player.GetComponent<Position>();
            Velocity velocity = player.GetComponent<Velocity>();
            PlayerCharacter character = player.GetComponent<PlayerCharacter>();

            if (position.Facing == Direction.Left)
            {
                velocity.X = -character.DashSpeed;
            }
            else
            {
                velocity.X = character.DashSpeed;
            }

            character.CurrentDashLength += _world.DeltaSeconds();

            if (character.CurrentDashLength > character.MaxDashLength)
            {
                velocity.X = 0.0f;
                character.IsDashing = false;
            }
            else
            {
                character.IsDashing = true;
            }
        }
    }
}
