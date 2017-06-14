using System;
using Artemis;
using Artemis.Attributes;
using Artemis.System;
using MMXEngine.Interfaces.Systems;
using MMXEngine.Systems.Draw;
using MMXEngine.Systems.Single;
using MMXEngine.Systems.Update;

namespace MMXEngine.Windows.Managers
{
    public class SystemLoader : ISystemLoader
    {
        private readonly EntityWorld _world;

        // Single
        private readonly LoadButtonConfigurationSystem _loadButtonConfigurationSystem;

        // Update
        private readonly GravitySystem _gravitySystem; 
        private readonly PhysicsSystem _physicsSystem; 
        private readonly PlayerMovementSystem _playerMovementSystem; 
        private readonly EnemySystem _enemySystem; 
        private readonly CollisionSystem _collisionSystem; 
        private readonly CameraSystem _cameraSystem; 
        private readonly SpriteSystem _spriteSystem; 
        private readonly HeartbeatSystem _heartbeatSystem; 

        // Draw
        private readonly RenderSystem _renderSystem;
        private readonly RenderLevelSystem _renderLevelSystem;
        private readonly RenderCollisionBoxSystem _renderCollisionBoxSystem;

        public SystemLoader(EntityWorld world,
            // Single
            LoadButtonConfigurationSystem loadButtonConfigurationSystem,
            // Update
            GravitySystem gravitySystem,
            PhysicsSystem physicsSystem,
            PlayerMovementSystem playerMovementSystem,
            EnemySystem enemySystem,
            CollisionSystem collisionSystem,
            CameraSystem cameraSystem,
            SpriteSystem spriteSystem,
            HeartbeatSystem heartbeatSystem,
            // Draw
            RenderSystem renderSystem,
            RenderLevelSystem renderLevelSystem,
            RenderCollisionBoxSystem renderCollisionBoxSystem)
        {
            _world = world;

            // Single
            _loadButtonConfigurationSystem = loadButtonConfigurationSystem;

            // Update
            _gravitySystem = gravitySystem;
            _physicsSystem = physicsSystem;
            _playerMovementSystem = playerMovementSystem;
            _enemySystem = enemySystem;
            _collisionSystem = collisionSystem;
            _cameraSystem = cameraSystem;
            _spriteSystem = spriteSystem;
            _heartbeatSystem = heartbeatSystem;

            // Draw
            _renderSystem = renderSystem;
            _renderLevelSystem = renderLevelSystem;
            _renderCollisionBoxSystem = renderCollisionBoxSystem;
        }

        public void Load()
        {
            // Single
            RegisterSystem(_loadButtonConfigurationSystem);
            // Update
            RegisterSystem(_gravitySystem);
            RegisterSystem(_physicsSystem);
            RegisterSystem(_playerMovementSystem);
            RegisterSystem(_enemySystem);
            RegisterSystem(_collisionSystem);
            RegisterSystem(_cameraSystem);
            RegisterSystem(_spriteSystem);
            RegisterSystem(_heartbeatSystem);

            // Draw
            RegisterSystem(_renderSystem);
            RegisterSystem(_renderLevelSystem);
            RegisterSystem(_renderCollisionBoxSystem);

        }

        private void RegisterSystem(EntitySystem system)
        {
            Type type = system.GetType();
            ArtemisEntitySystem attribute = (ArtemisEntitySystem)type.GetCustomAttributes(typeof(ArtemisEntitySystem), true)[0];
            _world.SystemManager.SetSystem(system, attribute.GameLoopType, attribute.Layer, attribute.ExecutionType);
        }
    }
}
