using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using Artemis.Utils;

namespace MMXEngine.Systems.Update
{
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Update,
        Layer = 1)]
    public class CollisionSystem : EntitySystem
    {
        private EntityWorld _world;

        public CollisionSystem(EntityWorld world)
        {
            _world = world;
        }

        public override void Process()
        {

            base.Process();
        }
    }
}
