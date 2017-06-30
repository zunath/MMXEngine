using System;
using MMXEngine.Contracts.Entities;
using MMXEngine.Contracts.Factories;
using MMXEngine.Contracts.Managers;
using MMXEngine.Contracts.Systems;
using MMXEngine.ECS.Data;
using MMXEngine.Windows.Editor.Events.LevelEditor;
using Prism.Events;

namespace MMXEngine.Windows.Editor.Screens
{
    public class LevelEditorScreen: IScreen
    {
        private readonly IEntityFactory _entityFactory;
        private readonly ICameraManager _camera;
        private readonly IEventAggregator _eventAggregator;

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

        }
    }
}
