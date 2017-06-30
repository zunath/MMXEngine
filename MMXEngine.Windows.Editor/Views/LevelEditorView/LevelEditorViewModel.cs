using System.Windows.Controls;
using MMXEngine.ECS.Screens;
using Prism.Mvvm;

namespace MMXEngine.Windows.Editor.Views.LevelEditorView
{
    public class LevelEditorViewModel: BindableBase
    {
        private readonly EditorGame _game;

        public LevelEditorViewModel(EditorGame game)
        {
            _game = game;
            _game.SetInitialScreen<LevelEditorScreen>();
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

    }
}
