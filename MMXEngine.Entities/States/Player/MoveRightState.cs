using Artemis;
using MMXEngine.Common.Enumerations;
using MMXEngine.Contracts.States;
using MMXEngine.ECS.Components;

namespace MMXEngine.ECS.States.Player
{
    public class MoveRightState: IPlayerState
    {
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
            velocity.X = 1.5f;
            position.Facing = Direction.Right;
        }
    }
}
