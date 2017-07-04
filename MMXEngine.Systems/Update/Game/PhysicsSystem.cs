using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using MMXEngine.ECS.Components;

namespace MMXEngine.Systems.Update.Game
{
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Update,
        Layer = 1)]
    public class PhysicsSystem : EntityProcessingSystem
    {
        public PhysicsSystem() 
            : base(Aspect.All(typeof(Velocity), typeof(Position)))
        {
        }

        public override void Process(Entity entity)
        {
            Position position = entity.GetComponent<Position>();
            Velocity velocity = entity.GetComponent<Velocity>();

            position.X += velocity.X;
            position.Y += velocity.Y;
        }
    }
}
