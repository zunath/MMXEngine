using System.Collections.Generic;
using Artemis;
using MMXEngine.Common.Enumerations;
using MMXEngine.ECS.Components;
using MMXEngine.ECS.Entities;
using MMXEngine.Interfaces.Entities;
using MMXEngine.Interfaces.Factories;
using MMXEngine.Interfaces.Managers;

namespace MMXEngine.ECS.Screens
{
    public class GameScreen: IScreen
    {
        private readonly IEntityFactory _entityFactory;
        private readonly IDataManager _dataManager;

        public GameScreen(IEntityFactory entityFactory,
            IDataManager dataManager)
        {
            _entityFactory = entityFactory;
            _dataManager = dataManager;
        }

        public void Initialize()
        {
            _entityFactory.Create<Level>("TestLevel");
            _entityFactory.Create<Player>(CharacterType.X);
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
