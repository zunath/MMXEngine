using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;

namespace MMXEngine.Systems.Update
{
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Update,
        Layer = 1)]
    public class PhysicsSystem : EntityProcessingSystem
    {
        public PhysicsSystem() 
            : base(Aspect.All())
        {
        }

        public override void Process(Entity entity)
        {
        }
    }
}
