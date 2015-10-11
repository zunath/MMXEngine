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
        private readonly ILevelManager _levelManager;
        private readonly IDataManager _dataManager;

        public GameScreen(IEntityFactory entityFactory,
            ILevelManager levelManager,
            IDataManager dataManager)
        {
            _entityFactory = entityFactory;
            _levelManager = levelManager;
            _dataManager = dataManager;
        }

        public void Initialize()
        {
            _levelManager.ChangeLevel("TestLevel");

            _entityFactory.Create<Player>(CharacterType.Zero);
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
