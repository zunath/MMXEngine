using Artemis;
using MMXEngine.Common.Enumerations;
using MMXEngine.ECS.Components;
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
            _entityFactory.Create<Level>("DemoMap");
            _entityFactory.Create<Player>(CharacterType.X, 16, -16);

            Entity enemy = _entityFactory.Create<Enemy>("GunVolt", 100, 0);
            enemy.GetComponent<Position>().Facing = Direction.Left;
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
