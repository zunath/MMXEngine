using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using MMXEngine.ECS.Components;

namespace MMXEngine.Systems.Draw
{
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous, 
        GameLoopType = GameLoopType.Draw, 
        Layer = 1)]
    public class HealthRenderSystem : EntityProcessingSystem
    {
        public HealthRenderSystem() 
            : base(Aspect.All(typeof(Health)))
        {
        }

        public override void Process(Entity entity)
        {

        }
    }
}
