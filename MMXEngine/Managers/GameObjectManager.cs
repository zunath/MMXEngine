using Microsoft.Xna.Framework;
using MMXEngine.Interfaces.Entities;
using MMXEngine.Interfaces.Managers;

namespace MMXEngine.Windows.Managers
{
    public class GameObjectManager :IGameObjectManager
    {
        private readonly ICameraManager _cameraManager;
        private readonly IContentManager _contentManager;
        private readonly IPlayer _player;

        public GameObjectManager(ICameraManager cameraManager, 
            IContentManager contentManager,
            IPlayer player)
        {
            _cameraManager = cameraManager;
            _contentManager = contentManager;
            _player = player;
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
