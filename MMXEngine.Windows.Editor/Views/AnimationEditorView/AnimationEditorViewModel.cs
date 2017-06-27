using MMXEngine.Common.Observables;
using MMXEngine.ECS.Components;
using Prism.Commands;
using Prism.Mvvm;

namespace MMXEngine.Windows.Editor.Views.AnimationEditorView
{
    public class AnimationEditorViewModel: BindableBase
    {
        public AnimationEditorViewModel()
        {
            AddAnimationCommand = new DelegateCommand(AddAnimation);
            DeleteAnimationCommand = new DelegateCommand(DeleteAnimation);
            AddFrameCommand = new DelegateCommand(AddFrame);
            DeleteFrameCommand = new DelegateCommand(DeleteFrame);
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

    }
}
