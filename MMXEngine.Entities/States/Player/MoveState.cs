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
            PlayerAction action = player.GetComponent<PlayerAction>();

            if (_input.IsDown(GameButton.MoveLeft))
            {
                map.CurrentState = PlayerState.Move;

                if (!action.IsDashing)
                {
                    position.Facing = Direction.Left;
                }
            }
            else if (_input.IsDown(GameButton.MoveRight))
            {
                map.CurrentState = PlayerState.Move;

                if (!action.IsDashing)
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
            PlayerAction action = player.GetComponent<PlayerAction>();

            if (action.IsDashing) return;

            if (position.Facing == Direction.Left)
            {
                velocity.X = -1.5f;
            }
            else
            {
                velocity.X = 1.5f;
            }
        }
    }
}
