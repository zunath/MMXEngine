using Artemis;
using MMXEngine.Common.Enumerations;
using MMXEngine.Contracts.Managers;
using MMXEngine.Contracts.States;
using MMXEngine.ECS.Components;

namespace MMXEngine.ECS.States.Player
{
    public class IdleState: IPlayerState
    {
        private readonly IInputManager _input;

        public IdleState(IInputManager input)
        {
            _input = input;
        }

        public void HandleInput(Entity player)
        {
            PlayerCharacter character = player.GetComponent<PlayerCharacter>();
            PlayerStateMap map = player.GetComponent<PlayerStateMap>();

            if (_input.IsUp(GameButton.Dash) &&
                _input.IsUp(GameButton.MoveRight) &&
                _input.IsUp(GameButton.MoveLeft) &&
                !character.IsLanding)
            {
                map.CurrentState = PlayerState.Idle;
            }
        }

        public void EnterState(Entity player)
        {
            Sprite sprite = player.GetComponent<Sprite>();
            sprite.SetCurrentAnimation("Idle");
        }

        public void ExitState(Entity player)
        {
            
        }

        public void ProcessState(Entity player)
        {
            Velocity velocity = player.GetComponent<Velocity>();
            velocity.X = 0;
        }
    }
}
