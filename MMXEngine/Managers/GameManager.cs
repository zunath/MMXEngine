using Artemis;
using Microsoft.Xna.Framework;
using MMXEngine.ECS.Entities;
using MMXEngine.ECS.Screens;
using MMXEngine.Interfaces.Entities;
using MMXEngine.Interfaces.Factories;
using MMXEngine.Interfaces.Managers;
using MMXEngine.Interfaces.Systems;

namespace MMXEngine.Windows.Managers
{
    public class GameManager : IGameManager
    {
        private readonly EntityWorld _world;
        private readonly IGraphicsManager _graphicsManager;
        private readonly ISystemLoader _systemLoader;
        private readonly IScreenManager _screenManager;
        private readonly IScreenFactory _screenFactory;

        public GameManager(
            IGraphicsManager graphicsManager,
            EntityWorld world,
            ISystemLoader systemLoader,
            IScreenManager screenManager,
            IScreenFactory screenFactory
            )
        {
            _graphicsManager = graphicsManager;
            _world = world;
            _systemLoader = systemLoader;
            _screenManager = screenManager;
            _screenFactory = screenFactory;
        }
        
        public void Initialize(GraphicsDeviceManager graphics)
        {
            _graphicsManager.Initialize(graphics);
            _systemLoader.Load();

            IScreen initialScreen = _screenFactory.Create<GameScreen>();
            _screenManager.ChangeScreen(initialScreen);
        }
        
        public void Update(GameTime gameTime)
        {
            _world.Update();
            _screenManager.Update();
        }
        
        public void Draw()
        {
            _world.Draw();
            _screenManager.Draw();
        }
        
        public void Exit()
        {
        }
    }
}
