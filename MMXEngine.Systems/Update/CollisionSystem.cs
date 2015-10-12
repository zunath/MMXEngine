using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using MMXEngine.ECS.Components;
using MMXEngine.ECS.Entities;
using TiledSharp;

namespace MMXEngine.Systems.Update
{
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Update,
        Layer = 1)]
    public class CollisionSystem : EntitySystem
    {
        private readonly EntityWorld _world;

        public CollisionSystem(EntityWorld world)
        {
            _world = world;
        }

        public override void Process()
        {
            Entity level = _world.EntityManager.GetEntities(Aspect.All(typeof (Map)))[0];
            if (level == null) return;

            Map levelMap = level.GetComponent<Map>();
            TmxMap map = levelMap.LevelMap;

            

            base.Process();
        }
    }
}
