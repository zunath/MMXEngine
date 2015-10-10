using Artemis;
using Microsoft.Xna.Framework;
using MMXEngine.ECS.Entities;
using MMXEngine.Interfaces.Factories;
using MMXEngine.Interfaces.Managers;
using MMXEngine.Interfaces.Systems;

namespace MMXEngine.Windows.Managers
{
    public class GameManager : IGameManager
    {
        private readonly EntityWorld _world;
        private readonly IGraphicsManager _graphicsManager;
        private readonly IEntityFactory _entityFactory;
        private readonly ISystemLoader _systemLoader;

        public GameManager(
            IGraphicsManager graphicsManager,
            EntityWorld world,
            ISystemLoader systemLoader,
            IEntityFactory entityFactory
            )
        {
            _graphicsManager = graphicsManager;
            _world = world;
            _entityFactory = entityFactory;
            _systemLoader = systemLoader;
        }
        
        public void Initialize(GraphicsDeviceManager graphics)
        {
            _graphicsManager.Initialize(graphics);
            _systemLoader.Load();


            _entityFactory.Create<Player>(); // TODO: Testing only
        }
        
        public void Update(GameTime gameTime)
        {
            _world.Update();
        }
        
        public void Draw()
        {
            _world.Draw();
        }
        
        public void Exit()
        {
        }
    }
}
