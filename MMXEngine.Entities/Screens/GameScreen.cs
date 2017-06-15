using MMXEngine.Contracts.Entities;
using MMXEngine.Contracts.Systems;

namespace MMXEngine.ECS.Screens
{
    public class GameScreen: IScreen
    {
        private readonly ILevelLoader _levelLoader;

        public GameScreen(ILevelLoader levelLoader)
        {
            _levelLoader = levelLoader;
        }

        public void Initialize()
        {
            _levelLoader.Load("DemoMap");
        }

        public void Update()
        {
            
        }

        public void Draw()
        {

        }

        public void Close()
        {
            
        }
    }
}
