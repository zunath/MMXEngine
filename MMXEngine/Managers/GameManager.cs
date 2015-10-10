using Artemis;
using Microsoft.Xna.Framework;
using MMXEngine.Interfaces.Managers;

namespace MMXEngine.Windows.Managers
{
    public class GameManager : IGameManager
    {
        private readonly EntityWorld _world;
        private readonly IGraphicsManager _graphicsManager;

        public GameManager(
            IGraphicsManager graphicsManager,
            EntityWorld world
            )
        {
            _graphicsManager = graphicsManager;
            _world = world;
        }
        
        public void Initialize(GraphicsDeviceManager graphics)
        {
            _graphicsManager.Initialize(graphics);
            _world.InitializeAll(true);
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
