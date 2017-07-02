using System;
using System.Windows.Controls;
using MMXEngine.ECS.Data;
using MMXEngine.Windows.Editor.Events.LevelEditor;
using MMXEngine.Windows.Editor.Screens;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace MMXEngine.Windows.Editor.Views.LevelEditorView
{
    public class LevelEditorViewModel: BindableBase
    {
        private readonly EditorGame _game;
        private readonly IEventAggregator _eventAggregator;

        public LevelEditorViewModel(EditorGame game,
            IEventAggregator eventAggregator)
        {
            _game = game;
            _game.SetInitialScreen<LevelEditorScreen>();

            _eventAggregator = eventAggregator;

			OnHorizontalScrollCommand = new DelegateCommand(OnHorizontalScroll);
			OnVerticalScrollCommand = new DelegateCommand(OnVerticalScroll);

            _eventAggregator.GetEvent<LevelOpenedEvent>().Subscribe(OnLevelLoaded);
        }
		
	    private Grid _gameGrid;

        public Grid GameGrid
        {
            get => _gameGrid;
            set
            {
                SetProperty(ref _gameGrid, value);
                _gameGrid.Children.Add(_game);
            }
        }

        private int _scrollHorizontal;

        public int ScrollHorizontal
        {
            get => _scrollHorizontal;
            set => SetProperty(ref _scrollHorizontal, value);
        }

        private int _scrollVertical;

        public int ScrollVertical
        {
            get => _scrollVertical;
            set => SetProperty(ref _scrollVertical, value);
        }

        private int _levelWidth;

        public int LevelWidth
        {
            get => _levelWidth;
            set => SetProperty(ref _levelWidth, value);
        }

        private int _levelHeight;

        public int LevelHeight
        {
            get => _levelHeight;
            set => SetProperty(ref _levelHeight, value);
        }

        private void OnLevelLoaded(LevelData levelData)
        {
            LevelWidth = levelData.Width-1;
            LevelHeight = levelData.Height-1;

            ScrollHorizontal = 1;
            ScrollVertical = 1;
        }

		public DelegateCommand OnHorizontalScrollCommand { get; set; }

	    private void OnHorizontalScroll()
	    {
		    _eventAggregator.GetEvent<LevelScrollHorizontalEvent>().Publish(ScrollHorizontal);
	    }

		public DelegateCommand OnVerticalScrollCommand { get; set; }

	    private void OnVerticalScroll()
	    {
		    _eventAggregator.GetEvent<LevelScrollVerticalEvent>().Publish(ScrollVertical);
	    }
    }
}
