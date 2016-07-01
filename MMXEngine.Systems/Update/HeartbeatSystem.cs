using System.Xml.Serialization;
using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using MMXEngine.Common.Attributes;
using MMXEngine.Common.Extensions;
using MMXEngine.ECS.Components;
using MMXEngine.Interfaces.Managers;

namespace MMXEngine.Systems.Update
{
    [LoadableSystem(9)]
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Update,
        Layer = 1)]
    public class HeartbeatSystem: EntityProcessingSystem
    {
        private readonly IScriptManager _scriptManager;
        private readonly EntityWorld _world;

        public HeartbeatSystem(IScriptManager scriptManager,
            EntityWorld world)
            :base (Aspect.All(typeof(Heartbeat),
                typeof(Script)))
        {
            _scriptManager = scriptManager;
            _world = world;
        }

        public override void Process(Entity entity)
        {
            if (!entity.HasComponent<Heartbeat>()) return;
            Heartbeat hb = entity.GetComponent<Heartbeat>();
            if (hb.Interval <= 0.0f) return;
            hb.CurrentTimer += _world.DeltaSeconds();
            if (!(hb.CurrentTimer >= hb.Interval)) return;

            if (entity.HasComponent<Script>())
            {
                Script script = entity.GetComponent<Script>();
                _scriptManager.QueueScript(script.FilePath, entity, "OnHeartbeat");
            }

            hb.CurrentTimer = 0.0f;

        }
    }
}
