using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using Microsoft.Xna.Framework;
using MMXEngine.Common.Constants;
using MMXEngine.Contracts.Managers;
using MMXEngine.ECS.Components;

namespace MMXEngine.Systems.Update.Editor
{
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Update,
        Layer = 1)]
    public class HighlightedTileSystem: EntityProcessingSystem
    {
        private readonly IEditorInputManager _input;

        public HighlightedTileSystem(IEditorInputManager input) 
            : base(Aspect.All(typeof(RenderableRectangle)))
        {
            _input = input;
        }

        public override void Process(Entity entity)
        {
            RenderableRectangle rect = entity.GetComponent<RenderableRectangle>();
            var mousePosition = _input.GetMousePosition();

            rect.Rect = new Rectangle(
                (int)(mousePosition.X / TilesetConstants.TileWidth  + rect.TileOffsetX) * TilesetConstants.TileWidth ,
                (int)(mousePosition.Y / TilesetConstants.TileHeight + rect.TileOffsetY) * TilesetConstants.TileHeight ,
                rect.Rect.Width,
                rect.Rect.Height);
        }
    }
}
