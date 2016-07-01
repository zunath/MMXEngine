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
            Entity player = _entityFactory.Create<Player>(CharacterType.X);
            player.GetComponent<Position>().X = 16;
            player.GetComponent<Position>().Y = -16;

            Entity enemy = _entityFactory.Create<Enemy>("GunVolt");
            enemy.GetComponent<Position>().X += 100;
            enemy.GetComponent<Position>().Facing = Direction.Right;
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
