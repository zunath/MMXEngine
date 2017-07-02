using Artemis;
using MMXEngine.Contracts.Entities;
using MMXEngine.Contracts.Factories;
using MMXEngine.Contracts.Managers;
using MMXEngine.ECS.Data;
using MMXEngine.ECS.Entities;
using MMXEngine.Windows.Editor.Events.LevelEditor;
using Prism.Events;

namespace MMXEngine.Windows.Editor.Screens
{
    public class LevelEditorScreen: IScreen
    {
        private readonly IEntityFactory _entityFactory;
        private readonly ICameraManager _camera;
        private readonly IEventAggregator _eventAggregator;

        private Entity _activeLevel;

        public LevelEditorScreen(IEntityFactory entityFactory,
            ICameraManager camera,
            IEventAggregator eventAggregator)
        {
            _entityFactory = entityFactory;
            _camera = camera;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<LevelTextureChangedEvent>().Subscribe(OnLevelTextureChanged);
            _eventAggregator.GetEvent<LevelOpenedEvent>().Subscribe(OnLevelOpened);
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

        private void OnLevelTextureChanged(string levelTexture)
        {
            
        }

        private void OnLevelOpened(LevelData levelData)
        {
            CloseLevel();

            _activeLevel = _entityFactory.Create<EditorLevel>(
                levelData.Width,
                levelData.Height,
                levelData.Name,
                levelData.Spritesheet,
                levelData.Tiles);
        }

        private void CloseLevel()
        {
            if (_activeLevel == null) return;
            _activeLevel.Delete();
            _eventAggregator.GetEvent<LevelClosedEvent>().Publish();
        }
    }
}
