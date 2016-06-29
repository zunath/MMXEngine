using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using MMXEngine.Common.Attributes;
using MMXEngine.ECS.Components;

namespace MMXEngine.Systems.Update
{
    [LoadableSystem(1)]
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Update,
        Layer = 1)]
    public class GravitySystem: EntityProcessingSystem
    {
        public GravitySystem() 
            : base(Aspect.All(typeof(Velocity)))
        {
        }

        public override void Process(Entity entity)
        {
            Velocity velocity = entity.GetComponent<Velocity>();
            velocity.Y += 4.0f;
            if (velocity.Y > 4.0f) velocity.Y = 4.0f;
        }
    }
}
