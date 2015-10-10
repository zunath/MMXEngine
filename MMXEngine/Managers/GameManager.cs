using Artemis;
using Microsoft.Xna.Framework;
using MMXEngine.Interfaces.Managers;
using XnaContentManager = Microsoft.Xna.Framework.Content.ContentManager;

namespace MMXEngine.Windows.Managers
{
    public class GameManager : IGameManager
    {
        private readonly EntityWorld _world;
        private readonly ICameraManager _cameraManager;
        private readonly IGraphicsManager _graphicsManager;
        private readonly IScreenManager _screenManager;

        public GameManager(
            ICameraManager cameraManager,
            IGraphicsManager graphicsManager,
            IScreenManager screenManager,
            EntityWorld world
            )
        {
            _cameraManager = cameraManager;
            _graphicsManager = graphicsManager;
            _screenManager = screenManager;
            _world = world;
        }
        
        public void Initialize(GraphicsDeviceManager graphics)
        {
            _graphicsManager.Initialize(graphics);
            _cameraManager.Initialize(new Vector3(0.0f, 50.0f, 5000.0f));
            
            
            
        }
        
        public void LoadContent(XnaContentManager content)
        {
        }
        
        public void UnloadContent()
        {
        }
        
        public void Update(GameTime gameTime)
        {
            _world.Update();
            _screenManager.Update(gameTime);
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
