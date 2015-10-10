using Microsoft.Xna.Framework;
using MMXEngine.Interfaces.Managers;

namespace MMXEngine.Windows.Managers
{
    public class GameObjectManager :IGameObjectManager
    {
        private readonly ICameraManager _cameraManager;

        public GameObjectManager(ICameraManager cameraManager)
        {
            _cameraManager = cameraManager;
        }
        
        public void LoadContent()
        {
        }
        
        public void Update(GameTime gameTime)
        {
        }
        
        public void Draw()
        {
        }
    }
}
