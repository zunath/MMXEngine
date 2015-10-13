using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.Common.Extensions;
using MMXEngine.ECS.Components;

namespace MMXEngine.Systems.Draw
{
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Draw,
        Layer = 1)]
    public class RenderCollisionBoxSystem : EntityProcessingSystem
    {
        private readonly SpriteBatch _spriteBatch;

        public RenderCollisionBoxSystem(SpriteBatch spriteBatch) : 
            base(Aspect.All(typeof(CollisionBox), typeof(Renderable)))
        {
            _spriteBatch = spriteBatch;
        }

        public override void Process(Entity entity)
        {
            CollisionBox box = entity.GetComponent<CollisionBox>();

            if (box.IsVisible)
            {
                _spriteBatch.DrawRectangle(box.Bounds, box.Color);
            }

        }
    }
}
