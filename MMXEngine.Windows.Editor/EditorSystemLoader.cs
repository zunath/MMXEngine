using Artemis;
using MMXEngine.Systems.Draw.Editor;
using MMXEngine.Systems.Draw.Shared;
using MMXEngine.Systems.Update.Editor;
using MMXEngine.Systems.Update.Shared;
using MMXEngine.Windows.Shared;

namespace MMXEngine.Windows.Editor
{
    public class EditorSystemLoader: SystemLoaderBase
    {

        // Update
        private readonly SpriteSystem _spriteSystem;
        private readonly HighlightedTileSystem _highlightedTileSystem;

        // Draw
        private readonly RenderSystem _renderSystem;
        private readonly RenderLevelSystem _renderLevelSystem;
        private readonly RenderTextSystem _renderTextSystem;
        private readonly RenderStaticGraphicSystem _renderStaticGraphicSystem;
        private readonly RenderHighlightedTile _renderHighlightedTile;

        public EditorSystemLoader(EntityWorld world,
            // Update
            SpriteSystem spriteSystem,
            HighlightedTileSystem highlightedTileSystem,
            // Draw
            RenderSystem renderSystem,
            RenderLevelSystem renderLevelSystem,
            RenderTextSystem renderTextSystem,
            RenderStaticGraphicSystem renderStaticGraphicSystem,
            RenderHighlightedTile renderHighlightedTile)
            : base(world)
        {
            // Update
            _spriteSystem = spriteSystem;
            _highlightedTileSystem = highlightedTileSystem;

            // Draw
            _renderSystem = renderSystem;
            _renderLevelSystem = renderLevelSystem;
            _renderTextSystem = renderTextSystem;
            _renderStaticGraphicSystem = renderStaticGraphicSystem;
            _renderHighlightedTile = renderHighlightedTile;
        }

        public override void Load()
        {
            // Update
            RegisterSystem(_spriteSystem);
            RegisterSystem(_highlightedTileSystem);

            // Draw
            RegisterSystem(_renderStaticGraphicSystem);
            RegisterSystem(_renderSystem);
            RegisterSystem(_renderLevelSystem);
            RegisterSystem(_renderTextSystem);
            RegisterSystem(_renderHighlightedTile);
        }

    }
}
