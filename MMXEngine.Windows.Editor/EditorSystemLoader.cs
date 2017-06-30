using Artemis;
using MMXEngine.Systems.Draw;
using MMXEngine.Systems.Update;
using MMXEngine.Windows.Shared;

namespace MMXEngine.Windows.Editor
{
    public class EditorSystemLoader: SystemLoaderBase
    {

        // Update
        private readonly CameraSystem _cameraSystem;
        private readonly SpriteSystem _spriteSystem;
        private readonly DebugSystem _debugSystem;
        private readonly DebugTextSystem _debugTextSystem;

        // Draw
        private readonly RenderSystem _renderSystem;
        private readonly RenderLevelSystem _renderLevelSystem;
        private readonly RenderTextSystem _renderTextSystem;
        private readonly RenderStaticGraphicSystem _renderStaticGraphicSystem;

        public EditorSystemLoader(EntityWorld world,
            // Update
            CameraSystem cameraSystem,
            SpriteSystem spriteSystem,
            DebugSystem debugSystem,
            DebugTextSystem debugTextSystem,
            // Draw
            RenderSystem renderSystem,
            RenderLevelSystem renderLevelSystem,
            RenderTextSystem renderTextSystem,
            RenderStaticGraphicSystem renderStaticGraphicSystem)
            : base(world)
        {
            // Update
            _cameraSystem = cameraSystem;
            _spriteSystem = spriteSystem;
            _debugSystem = debugSystem;
            _debugTextSystem = debugTextSystem;

            // Draw
            _renderSystem = renderSystem;
            _renderLevelSystem = renderLevelSystem;
            _renderTextSystem = renderTextSystem;
            _renderStaticGraphicSystem = renderStaticGraphicSystem;
        }

        public override void Load()
        {
            // Update
            RegisterSystem(_cameraSystem);
            RegisterSystem(_spriteSystem);
            RegisterSystem(_debugSystem);
            RegisterSystem(_debugTextSystem);

            // Draw
            RegisterSystem(_renderStaticGraphicSystem);
            RegisterSystem(_renderSystem);
            RegisterSystem(_renderLevelSystem);
            RegisterSystem(_renderTextSystem);
        }

    }
}
