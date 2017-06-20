using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using MMXEngine.ECS.Components;

namespace MMXEngine.Systems.Update
{
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Update,
        Layer = 1)]
    public class GravitySystem: EntityProcessingSystem
    {
        public GravitySystem() 
            : base(Aspect.All(typeof(Velocity), 
                typeof(Gravity)))
        {
        }

        public override void Process(Entity entity)
        {
            Velocity velocity = entity.GetComponent<Velocity>();
            Gravity gravity = entity.GetComponent<Gravity>();

            velocity.Y += gravity.Speed;

            if (velocity.Y > gravity.Speed)
                velocity.Y = gravity.Speed;
        }
    }
}
