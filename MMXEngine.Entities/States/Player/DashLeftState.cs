using Artemis;
using Microsoft.Xna.Framework;
using MMXEngine.Common.Extensions;
using MMXEngine.Contracts.States;
using MMXEngine.ECS.Components;

namespace MMXEngine.ECS.States.Player
{
    public class DashLeftState: IPlayerState
    {
        public float CurrentDashLength { get; private set; }
        private const float MaxDashLength = 0.5f;
        private readonly EntityWorld _world;

        public DashLeftState(EntityWorld world)
        {
            _world = world;
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
        }

        public void ProcessState(Entity player)
        {
            Velocity velocity = player.GetComponent<Velocity>();
            velocity.X = -2.5f;

            CurrentDashLength += _world.DeltaSeconds();
        }
    }
}
