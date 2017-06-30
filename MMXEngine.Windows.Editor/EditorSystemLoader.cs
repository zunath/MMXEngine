using Artemis;
using MMXEngine.Systems.Draw;
using MMXEngine.Systems.Update;
using MMXEngine.Windows.Shared;

namespace MMXEngine.Windows.Editor
{
    public class EditorSystemLoader: SystemLoaderBase
    {

        // Update
        private readonly SpriteSystem _spriteSystem;

        // Draw
        private readonly RenderSystem _renderSystem;
        private readonly RenderLevelSystem _renderLevelSystem;
        private readonly RenderTextSystem _renderTextSystem;
        private readonly RenderStaticGraphicSystem _renderStaticGraphicSystem;

        public EditorSystemLoader(EntityWorld world,
            // Update
            SpriteSystem spriteSystem,
            // Draw
            RenderSystem renderSystem,
            RenderLevelSystem renderLevelSystem,
            RenderTextSystem renderTextSystem,
            RenderStaticGraphicSystem renderStaticGraphicSystem)
            : base(world)
        {
            // Update
            _spriteSystem = spriteSystem;

            // Draw
            _renderSystem = renderSystem;
            _renderLevelSystem = renderLevelSystem;
            _renderTextSystem = renderTextSystem;
            _renderStaticGraphicSystem = renderStaticGraphicSystem;
        }

        public override void Load()
        {
            // Update
            RegisterSystem(_spriteSystem);

            // Draw
            RegisterSystem(_renderStaticGraphicSystem);
            RegisterSystem(_renderSystem);
            RegisterSystem(_renderLevelSystem);
            RegisterSystem(_renderTextSystem);
        }

    }
}
