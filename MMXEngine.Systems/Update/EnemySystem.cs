using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using MMXEngine.Common.Enumerations;
using MMXEngine.Common.Extensions;
using MMXEngine.ECS.Components;
using MMXEngine.Interfaces.Managers;

namespace MMXEngine.Systems.Update
{
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Update,
        Layer = 1)]
    public class EnemySystem: EntityProcessingSystem
    {
        private readonly IScriptManager _scriptManager;

        public EnemySystem(IScriptManager scriptManager)
            : base(Aspect.All(typeof(Hostile), 
                typeof(CollisionBox)))
        {
            _scriptManager = scriptManager;
        }

        public override void Process(Entity entity)
        {
            Entity player = (Entity)BlackBoard.GetEntry("Player");
            
            // Player collision
            if (player.GetComponent<CollisionBox>().Bounds.GetCollisionType(
                    entity.GetComponent<CollisionBox>().Bounds) != CollisionType.None)
            {
                if (entity.HasComponent<Script>())
                {
                    Script script = entity.GetComponent<Script>();
                    _scriptManager.QueueScript(script.FilePath, entity, "OnTouch");

                }
            }

        }
    }
}
