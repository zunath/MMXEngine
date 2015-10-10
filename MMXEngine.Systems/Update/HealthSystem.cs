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
    public class HealthSystem : EntityProcessingSystem
    {
        public HealthSystem(Aspect aspect) 
            : base(Artemis.Aspect.All(typeof(Health)))
        {
        }

        public override void Process(Entity entity)
        {

        }
    }
}
