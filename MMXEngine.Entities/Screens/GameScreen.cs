using MMXEngine.ECS.Entities;
using MMXEngine.Interfaces.Entities;
using MMXEngine.Interfaces.Factories;

namespace MMXEngine.ECS.Screens
{
    public class GameScreen: IScreen
    {
        private readonly IEntityFactory _entityFactory;

        public GameScreen(IEntityFactory entityFactory)
        {
            _entityFactory = entityFactory;
        }

        public void Initialize()
        {
            _entityFactory.Create<Player>();
        }

        public void Update()
        {
            
        }

        public void Draw()
        {

        }
    }
}
