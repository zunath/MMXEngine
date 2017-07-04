using Artemis;
using Microsoft.Xna.Framework;
using MMXEngine.Common.Constants;
using MMXEngine.Contracts.Entities;
using MMXEngine.Contracts.Factories;
using MMXEngine.Contracts.Managers;
using MMXEngine.ECS.Components;
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
        private readonly IEditorInputManager _input;

        private Entity _activeLevel;
        private Entity _highlightedTile;

        public LevelEditorScreen(IEntityFactory entityFactory,
            ICameraManager camera,
            IEventAggregator eventAggregator,
            IEditorInputManager input)
        {
            _entityFactory = entityFactory;
            _camera = camera;
            _eventAggregator = eventAggregator;
            _input = input;

            _eventAggregator.GetEvent<LevelTextureChangedEvent>().Subscribe(OnLevelTextureChanged);
            _eventAggregator.GetEvent<LevelOpenedEvent>().Subscribe(OnLevelOpened);

	        _eventAggregator.GetEvent<LevelScrollHorizontalEvent>().Subscribe(OnLevelScrollHorizontal);
	        _eventAggregator.GetEvent<LevelScrollVerticalEvent>().Subscribe(OnLevelScrollVertical);
        }

	    private void OnLevelScrollVertical(int verticalPosition)
	    {
		    Vector2 newPosition = new Vector2(
				_camera.Position.X,
				verticalPosition * TilesetConstants.TileHeight);
		    _camera.Position = newPosition;

	        _highlightedTile.GetComponent<RenderableRectangle>().TileOffsetY = verticalPosition;
	    }

	    private void OnLevelScrollHorizontal(int horizontalPosition)
	    {
		    Vector2 newPosition = new Vector2(
				horizontalPosition * TilesetConstants.TileWidth,
				_camera.Position.Y);
		    _camera.Position = newPosition;

	        _highlightedTile.GetComponent<RenderableRectangle>().TileOffsetX = horizontalPosition;
        }


	    public void Initialize()
        {
            _camera.Zoom = 1.0f;
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
            _activeLevel.GetComponent<Map>().ShowEmptyTiles = true;

            _highlightedTile = _entityFactory.Create<HighlightedTile>(
                0,
                0,
                TilesetConstants.TileWidth,
                TilesetConstants.TileHeight,
                Color.Yellow);
        }

        private void CloseLevel()
        {
            if (_activeLevel == null) return;
            _activeLevel.Delete();
            _highlightedTile.Delete();
            _eventAggregator.GetEvent<LevelClosedEvent>().Publish();
        }
    }
}
