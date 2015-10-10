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
    public class MovementSystem : EntityProcessingSystem
    {
        public MovementSystem() : base(Aspect.All())
        {
        }

        public override void Process(Entity entity)
        {
            
        }
    }
}
