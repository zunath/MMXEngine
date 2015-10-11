using Artemis;
using Microsoft.Xna.Framework;
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
        private readonly IInputManager _inputManager;
        private readonly ICameraManager _cameraManager;
        private readonly ILevelManager _levelManager;

        public GameManager(
            IGraphicsManager graphicsManager,
            EntityWorld world,
            ISystemLoader systemLoader,
            IScreenManager screenManager,
            IScreenFactory screenFactory,
            IInputManager inputManager,
            ICameraManager cameraManager,
            ILevelManager levelManager
            )
        {
            _graphicsManager = graphicsManager;
            _world = world;
            _systemLoader = systemLoader;
            _screenManager = screenManager;
            _screenFactory = screenFactory;
            _inputManager = inputManager;
            _cameraManager = cameraManager;
            _levelManager = levelManager;
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
            _inputManager.Update();
            _world.Update();
            _screenManager.Update();
            _cameraManager.Update();
        }
        
        public void Draw()
        {
            _world.Draw();
            _levelManager.Draw();
            _screenManager.Draw();
        }
        
        public void Exit()
        {
        }
    }
}
