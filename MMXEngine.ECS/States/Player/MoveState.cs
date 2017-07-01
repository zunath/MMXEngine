using Artemis;
using MMXEngine.Common.Enumerations;
using MMXEngine.Contracts.Managers;
using MMXEngine.Contracts.States;
using MMXEngine.ECS.Components;

namespace MMXEngine.ECS.States.Player
{
    public class MoveState: IPlayerState
    {
        private readonly IInputManager _input;

        public MoveState(IInputManager input)
        {
            _input = input;
        }

        public void HandleInput(Entity player)
        {
            PlayerStateMap map = player.GetComponent<PlayerStateMap>();
            Position position = player.GetComponent<Position>();
            PlayerCharacter character = player.GetComponent<PlayerCharacter>();

            if (_input.IsDown(GameButton.MoveLeft))
            {
                map.CurrentState = PlayerState.Move;

                if (!character.IsDashing)
                {
                    position.Facing = Direction.Left;
                }
            }
            else if (_input.IsDown(GameButton.MoveRight))
            {
                map.CurrentState = PlayerState.Move;

                if (!character.IsDashing)
                {
                    position.Facing = Direction.Right;
                }
            }
        }

        public void EnterState(Entity player)
        {
            Sprite sprite = player.GetComponent<Sprite>();
            sprite.SetCurrentAnimation("Move");
        }

        public void ExitState(Entity player)
        {
            
        }

        public void ProcessState(Entity player)
        {
            Position position = player.GetComponent<Position>();
            Velocity velocity = player.GetComponent<Velocity>();
            PlayerCharacter character = player.GetComponent<PlayerCharacter>();

            if (character.IsDashing) return;

            if (position.Facing == Direction.Left)
            {
                velocity.X = -character.MoveSpeed;
            }
            else
            {
                velocity.X = character.MoveSpeed;
            }
        }
    }
}
