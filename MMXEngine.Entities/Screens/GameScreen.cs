using MMXEngine.Contracts.Entities;
using MMXEngine.Contracts.Factories;
using MMXEngine.Contracts.Systems;
using MMXEngine.ECS.Entities;

namespace MMXEngine.ECS.Screens
{
    public class GameScreen: IScreen
    {
        private readonly ILevelLoader _levelLoader;
        private readonly IEntityFactory _entityFactory;

        public GameScreen(ILevelLoader levelLoader,
            IEntityFactory entityFactory)
        {
            _levelLoader = levelLoader;
            _entityFactory = entityFactory;
        }

        public void Initialize()
        {
            _levelLoader.Load("DemoMap");

            _entityFactory.Create<DebugWindow>();
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
