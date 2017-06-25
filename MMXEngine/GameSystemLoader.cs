using Artemis;
using MMXEngine.Systems.Draw;
using MMXEngine.Systems.Single;
using MMXEngine.Systems.Update;
using MMXEngine.Windows.Shared;

namespace MMXEngine.Windows.Game
{
    public class GameSystemLoader : SystemLoaderBase
    {
        // Single
        private readonly LoadButtonConfigurationSystem _loadButtonConfigurationSystem;

        // Update
        private readonly GravitySystem _gravitySystem; 
        private readonly PhysicsSystem _physicsSystem; 
        private readonly PlayerStateSystem _playerStateSystem; 
        private readonly EntityCollisionSystem _entityCollisionSystem; 
        private readonly LevelCollisionSystem _levelCollisionSystem; 
        private readonly CameraSystem _cameraSystem; 
        private readonly SpriteSystem _spriteSystem; 
        private readonly HeartbeatSystem _heartbeatSystem;
        private readonly DebugSystem _debugSystem;
        private readonly DebugTextSystem _debugTextSystem;

        // Draw
        private readonly RenderSystem _renderSystem;
        private readonly RenderLevelSystem _renderLevelSystem;
        private readonly RenderCollisionBoxSystem _renderCollisionBoxSystem;
        private readonly RenderTextSystem _renderTextSystem;
        private readonly RenderStaticGraphicSystem _renderStaticGraphicSystem;
        private readonly RenderLifeBarSystem _renderLifeBarSystem;

        public GameSystemLoader(EntityWorld world,
            // Single
            LoadButtonConfigurationSystem loadButtonConfigurationSystem,
            // Update
            GravitySystem gravitySystem,
            PhysicsSystem physicsSystem,
            PlayerStateSystem playerStateSystem,
            EntityCollisionSystem entityCollisionSystem,
            LevelCollisionSystem levelCollisionSystem,
            CameraSystem cameraSystem,
            SpriteSystem spriteSystem,
            HeartbeatSystem heartbeatSystem,
            DebugSystem debugSystem,
            DebugTextSystem debugTextSystem,
            // Draw
            RenderSystem renderSystem,
            RenderLevelSystem renderLevelSystem,
            RenderCollisionBoxSystem renderCollisionBoxSystem,
            RenderTextSystem renderTextSystem,
            RenderStaticGraphicSystem renderStaticGraphicSystem,
            RenderLifeBarSystem renderLifeBarSystem)
            : base(world)
        {
            // Single
            _loadButtonConfigurationSystem = loadButtonConfigurationSystem;

            // Update
            _gravitySystem = gravitySystem;
            _physicsSystem = physicsSystem;
            _playerStateSystem = playerStateSystem;
            _entityCollisionSystem = entityCollisionSystem;
            _levelCollisionSystem = levelCollisionSystem;
            _cameraSystem = cameraSystem;
            _spriteSystem = spriteSystem;
            _heartbeatSystem = heartbeatSystem;
            _debugSystem = debugSystem;
            _debugTextSystem = debugTextSystem;

            // Draw
            _renderSystem = renderSystem;
            _renderLevelSystem = renderLevelSystem;
            _renderCollisionBoxSystem = renderCollisionBoxSystem;
            _renderTextSystem = renderTextSystem;
            _renderStaticGraphicSystem = renderStaticGraphicSystem;
            _renderLifeBarSystem = renderLifeBarSystem;
        }

        public override void Load()
        {
            // Single
            RegisterSystem(_loadButtonConfigurationSystem);
            // Update
            RegisterSystem(_gravitySystem);
            RegisterSystem(_physicsSystem);
            RegisterSystem(_playerStateSystem);
            RegisterSystem(_entityCollisionSystem);
            RegisterSystem(_levelCollisionSystem);
            RegisterSystem(_cameraSystem);
            RegisterSystem(_spriteSystem);
            RegisterSystem(_heartbeatSystem);
            RegisterSystem(_debugSystem);
            RegisterSystem(_debugTextSystem);

            // Draw
            RegisterSystem(_renderStaticGraphicSystem);
            RegisterSystem(_renderSystem);
            RegisterSystem(_renderLevelSystem);
            RegisterSystem(_renderCollisionBoxSystem);
            RegisterSystem(_renderTextSystem);
            RegisterSystem(_renderLifeBarSystem);
        }

    }
}
