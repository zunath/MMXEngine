using MMXEngine.Contracts.Managers;
using MMXEngine.ECS.Data;
using MMXEngine.Windows.Editor.Objects;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;

namespace MMXEngine.Windows.Editor.Views.EnemyEditorView
{
    public class EnemyEditorViewModel: BindableBase
    {
        private readonly IDataManager _dataManager;

        public EnemyEditorViewModel(IDataManager dataManager)
        {
            _dataManager = dataManager;
            
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
            SelectScriptFileCommand = new DelegateCommand(SelectScript);

            SelectFileRequest = new InteractionRequest<INotification>();

            HeartbeatInterval = 1.0f;
        }


        private string _name;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _textureFileName;

        public string TextureFileName
        {
            get => _textureFileName;
            set => SetProperty(ref _textureFileName, value);
        }

        private string _scriptFileName;

        public string ScriptFileName
        {
            get => _scriptFileName;
            set => SetProperty(ref _scriptFileName, value);
        }

        private float _heartbeatInterval;

        public float HeartbeatInterval
        {
            get => _heartbeatInterval;
            set => SetProperty(ref _heartbeatInterval, value);
        }
        
        public DelegateCommand SaveCommand { get; set; }

        private void Save()
        {
            
        }

        public DelegateCommand CancelCommand { get; set; }

        private void Cancel()
        {
            
        }

        public DelegateCommand SelectScriptFileCommand { get; set; }

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
