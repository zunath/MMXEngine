using MMXEngine.Contracts.Entities;
using MMXEngine.Contracts.Factories;
using MMXEngine.Contracts.Managers;
using MMXEngine.Contracts.Systems;
using MMXEngine.ECS.Entities;

namespace MMXEngine.ECS.Screens
{
    public class LevelEditorScreen: IScreen
    {
        private readonly ILevelLoader _levelLoader;
        private readonly IEntityFactory _entityFactory;
        private readonly ICameraManager _camera;

        public LevelEditorScreen(ILevelLoader levelLoader,
            IEntityFactory entityFactory,
            ICameraManager camera)
        {
            _levelLoader = levelLoader;
            _entityFactory = entityFactory;
            _camera = camera;
        }

        public void Initialize()
        {
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
