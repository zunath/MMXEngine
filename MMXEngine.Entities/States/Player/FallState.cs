using Artemis;
using MMXEngine.Common.Enumerations;
using MMXEngine.Contracts.Managers;
using MMXEngine.Contracts.States;
using MMXEngine.ECS.Components;

namespace MMXEngine.ECS.States.Player
{
    public class FallState: IPlayerState
    {
        private readonly IInputManager _input;

        public FallState(IInputManager input)
        {
            _input = input;
        }

        public void HandleInput(Entity player)
        {
            PlayerCharacter character = player.GetComponent<PlayerCharacter>();
            Position position = player.GetComponent<Position>();
            PlayerStateMap map = player.GetComponent<PlayerStateMap>();

            if (!position.IsOnGround && !character.IsJumping)
            {
                map.CurrentState = PlayerState.Fall;
            }
        }

        public void EnterState(Entity player)
        {
            Sprite sprite = player.GetComponent<Sprite>();
            sprite.SetCurrentAnimation("Falling");
        }

        public void ExitState(Entity player)
        {
            
        }

        public void ProcessState(Entity player)
        {
            PlayerCharacter character = player.GetComponent<PlayerCharacter>();
            Velocity velocity = player.GetComponent<Velocity>();

            if (_input.IsDown(GameButton.MoveLeft))
            {
                velocity.X = -character.MoveSpeed;
            }
            else if (_input.IsDown(GameButton.MoveRight))
            {
                velocity.X = character.MoveSpeed;
            }
            else
            {
                velocity.X = 0;
            }
        }
    }
}
