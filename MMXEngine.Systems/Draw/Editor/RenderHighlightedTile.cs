using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.Common.Constants;
using MMXEngine.ECS.Components;
using MonoGame.Extended;

namespace MMXEngine.Systems.Draw.Editor
{
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Draw,
        Layer = 1)]
    public class RenderHighlightedTile: EntityProcessingSystem
    {
        private readonly SpriteBatch _spriteBatch;

        public RenderHighlightedTile(SpriteBatch spriteBatch) 
            : base(Aspect.All(typeof(RenderableRectangle)))
        {
            _spriteBatch = spriteBatch;
        }

        public override void Process(Entity entity)
        {
            var rectangle = entity.GetComponent<RenderableRectangle>();
            _spriteBatch.DrawRectangle(rectangle.Rect, rectangle.Color, 5f);
        }
    }
}
