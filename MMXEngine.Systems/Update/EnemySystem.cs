using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using Microsoft.Xna.Framework;
using MMXEngine.Common.Enumerations;
using MMXEngine.Common.Extensions;
using MMXEngine.Contracts.Managers;
using MMXEngine.ECS.Components;

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
                typeof(Position),
                typeof(CollisionBox)))
        {
            _scriptManager = scriptManager;
        }

        public override void Process(Entity entity)
        {
            Entity player = (Entity)BlackBoard.GetEntry("Player");
            CollisionBox playerBox = player.GetComponent<CollisionBox>();
            Position playerPosition = player.GetComponent<Position>();
            Rectangle playerRectangle = new Rectangle(
                (int)playerPosition.X + playerBox.OffsetX,
                (int)playerPosition.Y + playerBox.OffsetY,
                playerBox.Width,
                playerBox.Height);

            CollisionBox enemyBox = entity.GetComponent<CollisionBox>();
            Position enemyPosition = entity.GetComponent<Position>();
            Rectangle enemyRectangle = new Rectangle(
                (int)enemyPosition.X + enemyBox.OffsetX,
                (int)enemyPosition.Y + enemyBox.OffsetY,
                enemyBox.Width,
                enemyBox.Height);

            var type = playerRectangle.GetCollisionType(enemyRectangle);

            if (type == CollisionType.None || !entity.HasComponent<Script>()) return;
            Script script = entity.GetComponent<Script>();
            _scriptManager.QueueScript(script.FilePath, entity, "OnTouch");
        }
        
    }
}
