using Microsoft.Xna.Framework;
using MMXEngine.Interfaces.Managers;

namespace MMXEngine.Windows.Managers
{
    public class ScreenManager : IScreenManager
    {
        private readonly IGameObjectManager _gameObjectManager;
        private readonly IGraphicsManager _graphicsManager;

        public ScreenManager(IGameObjectManager gameObjectManager, IGraphicsManager graphicsManager)
        {
            _gameObjectManager = gameObjectManager;
            _graphicsManager = graphicsManager;
        }

        // Update each game object using GameObjectManager.
        public void Update(GameTime gameTime)
        {
            _gameObjectManager.Update(gameTime);
        }

        // Draw each game object using GameObjectManager.
        public void Draw()
        {
            _graphicsManager.GraphicsDevice.Clear(Color.Black);
            _gameObjectManager.Draw();
        }
    }
}
