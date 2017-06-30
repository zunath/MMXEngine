using MMXEngine.ECS.Data;
using MMXEngine.Windows.Editor.Events.LevelEditor;
using MMXEngine.Windows.Editor.Objects;
using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;

namespace MMXEngine.Windows.Editor.Views.LevelPropertiesView
{
    public class LevelPropertiesViewModel: BindableBase
    {
        private readonly IEventAggregator _eventAggregator;

        public LevelPropertiesViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            SelectTextureCommand = new DelegateCommand(SelectTexture);
            SelectBGMFileCommand = new DelegateCommand(SelectBGMFile);
            SelectScriptCommand = new DelegateCommand(SelectScript);

            SelectFileRequest = new InteractionRequest<INotification>();

            Width = 100;
            Height = 100;
        }

        private string _name;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private int _width;

        public int Width
        {
            get => _width;
            set => SetProperty(ref _width, value);
        }

        private int _height;

        public int Height
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }

        private string _textureFileName;

        public string TextureFileName
        {
            get => _textureFileName;
            set => SetProperty(ref _textureFileName, value);
        }

        private string _bgmFileName;

        public string BGMFileName
        {
            get => _bgmFileName;
            set => SetProperty(ref _bgmFileName, value);
        }

        private string _scriptFileName;

        public string ScriptFileName
        {
            get => _scriptFileName;
            set => SetProperty(ref _scriptFileName, value);
        }

        public DelegateCommand SelectTextureCommand { get; set; }

        private void SelectTexture()
        {
            FileOpenerData data = new FileOpenerData("xnb", "Textures", "texture", "Graphics\\Tilesets\\", true, true);

            SelectFileRequest.Raise(new Notification
                {
                    Title = "Select Texture",
                    Content = data
                },
                notification =>
                {
                    if (data.WasActionCanceled) return;
                    TextureFileName = data.UserSelectedNoneOption ? string.Empty : data.OpenedFile;
                    _eventAggregator.GetEvent<LevelTextureChangedEvent>().Publish(TextureFileName);
                });
        }

        public DelegateCommand SelectBGMFileCommand { get; set; }

        private void SelectBGMFile()
        {
            FileOpenerData data = new FileOpenerData("xnb", "BGM", "BGM", "Audio\\BGM\\", true, true);

            SelectFileRequest.Raise(new Notification
                {
                    Title = "Select BGM",
                    Content = data
                },
                notification =>
                {
                    if (data.WasActionCanceled) return;
                    BGMFileName = data.UserSelectedNoneOption ? string.Empty : data.OpenedFile;
                });
        }

        public DelegateCommand SelectScriptCommand { get; set; }

        private void SelectScript()
        {
            FileOpenerData data = new FileOpenerData("lua", "Scripts", "script", "Scripts\\", true, true);

            SelectFileRequest.Raise(new Notification
                {
                    Title = "Select Script",
                    Content = data
                },
                notification =>
                {
                    if (data.WasActionCanceled) return;
                    ScriptFileName = data.UserSelectedNoneOption ? string.Empty : data.OpenedFile;
                });
        }

        public InteractionRequest<INotification> SelectFileRequest { get; }
    }
}
