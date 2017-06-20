using Artemis;
using MMXEngine.Common.Constants;
using MMXEngine.Common.Enumerations;
using MMXEngine.Common.Extensions;
using MMXEngine.Contracts.Managers;
using MMXEngine.Contracts.States;
using MMXEngine.ECS.Components;

namespace MMXEngine.ECS.States.Player
{
    public class JumpState: IPlayerState
    {
        private readonly EntityWorld _world;
        private readonly IInputManager _input;

        public JumpState(
            EntityWorld world,
            IInputManager input)
        {
            _world = world;
            _input = input;
        }

        public void HandleInput(Entity player)
        {
            PlayerStateMap map = player.GetComponent<PlayerStateMap>();
            PlayerCharacter character = player.GetComponent<PlayerCharacter>();

            if (_input.IsDown(GameButton.Jump))
            {
                map.CurrentState = PlayerState.Jump;
            }
            else if (_input.IsUp(GameButton.Jump))
            {
                character.CurrentJumpLength = 0.0f;
            }

        }

        public void EnterState(Entity player)
        {
            Sprite sprite = player.GetComponent<Sprite>();
            sprite.SetCurrentAnimation("Jump");
        }

        public void ExitState(Entity player)
        {
            PlayerCharacter character = player.GetComponent<PlayerCharacter>();
            character.IsJumping = false;
        }

        public void ProcessState(Entity player)
        {
            Position position = player.GetComponent<Position>();
            Velocity velocity = player.GetComponent<Velocity>();
            PlayerCharacter character = player.GetComponent<PlayerCharacter>();

            character.CurrentJumpLength += _world.DeltaSeconds();

            if (character.CurrentJumpLength > character.MaxJumpLength)
            {
                character.IsJumping = false;
            }
            else
            {
                velocity.Y = -character.JumpSpeed;
                character.IsJumping = true;
                position.IsOnGround = false;
            }
        }
    }
}
