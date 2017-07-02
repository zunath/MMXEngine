using System.IO.Abstractions;
using System.Windows.Controls;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.Common.Observables;
using MMXEngine.ECS.Components;
using MMXEngine.Windows.Editor.Objects;
using MMXEngine.Windows.Editor.Screens;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using Frame = MMXEngine.ECS.Components.Frame;

namespace MMXEngine.Windows.Editor.Views.AnimationEditorView
{
    public class AnimationEditorViewModel: BindableBase
    {
        private readonly IFileSystem _fileSystem;
        private readonly EditorGame _game;

        public AnimationEditorViewModel(IFileSystem fileSystem,
            EditorGame game)
        {
            _fileSystem = fileSystem;
            _game = game;
            //_game.SetInitialScreen<AnimationEditorScreen>();

            SelectSpriteSheetCommand = new DelegateCommand(SelectSpriteSheet);

            AddAnimationCommand = new DelegateCommand(AddAnimation);
            DeleteAnimationCommand = new DelegateCommand(DeleteAnimation);
            AddFrameCommand = new DelegateCommand(AddFrame);
            DeleteFrameCommand = new DelegateCommand(DeleteFrame);

            MoveFrameUpCommand = new DelegateCommand(MoveFrameUp);
            MoveFrameDownCommand = new DelegateCommand(MoveFrameDown);

            SelectFileRequest = new InteractionRequest<INotification>();
        }

        private ObservableCollectionEx<Animation> _animations;

        public ObservableCollectionEx<Animation> Animations
        {
            get => _animations;
            set => SetProperty(ref _animations, value);
        }

        private Animation _selectedAnimation;

        public Animation SelectedAnimation
        {
            get => _selectedAnimation;
            set => SetProperty(ref _selectedAnimation, value);
        }

        private ObservableCollectionEx<Frame> _frames;

        public ObservableCollectionEx<Frame> Frames
        {
            get => _frames;
            set => SetProperty(ref _frames, value);
        }

        private Frame _selectedFrame;

        public Frame SelectedFrame
        {
            get => _selectedFrame;
            set => SetProperty(ref _selectedFrame, value);
        }

        private string _selectedSpriteSheetFile;

        public string SelectedSpriteSheetFile
        {
            get => _selectedSpriteSheetFile;
            set => SetProperty(ref _selectedSpriteSheetFile, value);
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

        public DelegateCommand AddAnimationCommand { get; set; }

        private void AddAnimation()
        {
            
        }

        public DelegateCommand DeleteAnimationCommand { get; set; }

        private void DeleteAnimation()
        {
            
        }

        public DelegateCommand AddFrameCommand { get; set; }

        private void AddFrame()
        {
            
        }

        public DelegateCommand DeleteFrameCommand { get; set; }

        private void DeleteFrame()
        {
            
        }

        public DelegateCommand MoveFrameUpCommand { get; set; }

        private void MoveFrameUp()
        {
            
        }

        public DelegateCommand MoveFrameDownCommand { get; set; }

        private void MoveFrameDown()
        {
            
        }

        public DelegateCommand SelectSpriteSheetCommand { get; set; }

        private void SelectSpriteSheet()
        {
            FileOpenerData data = new FileOpenerData("xnb", "Graphics", "graphic", "Graphics\\", true, false);

            SelectFileRequest.Raise(new Notification
                {
                    Title = "Select Graphic",
                    Content = data
                },
                notification =>
                {
                    if (data.WasActionCanceled) return;

                    string filePath = "Graphics\\" + _fileSystem.Path.ChangeExtension(data.OpenedFile, null);
                    Texture2D texture = _game.Content.Load<Texture2D>(filePath);
                    

                    


                });

        }

        public InteractionRequest<INotification> SelectFileRequest { get; }
    }
}
