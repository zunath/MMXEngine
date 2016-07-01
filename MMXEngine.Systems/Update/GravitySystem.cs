using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using MMXEngine.Common.Attributes;
using MMXEngine.Common.Constants;
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
            velocity.Y += WorldConstants.Gravity;
            if (velocity.Y > WorldConstants.Gravity) velocity.Y = WorldConstants.Gravity;
        }
    }
}
