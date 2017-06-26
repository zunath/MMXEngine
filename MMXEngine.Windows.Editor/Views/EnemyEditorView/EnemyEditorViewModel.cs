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

            NewEnemyCommand = new DelegateCommand(NewEnemy);
            OpenEnemyCommand = new DelegateCommand(OpenEnemy);
            SaveEnemyCommand = new DelegateCommand(SaveEnemy);

            SelectTextureFileCommand = new DelegateCommand(SelectTexture);
            SelectScriptFileCommand = new DelegateCommand(SelectScript);

            SelectFileRequest = new InteractionRequest<INotification>();
            SaveFileRequest = new InteractionRequest<INotification>();

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


        public DelegateCommand NewEnemyCommand { get; set; }

        private void NewEnemy()
        {
            Name = string.Empty;
            TextureFileName = string.Empty;
            ScriptFileName = string.Empty;
            HeartbeatInterval = 1.0f;
        }

        public DelegateCommand OpenEnemyCommand { get; set; }

        private void OpenEnemy()
        {
            FileOpenerData data = new FileOpenerData("json", "Enemies", "enemy", "Data\\Enemies\\", true, false);

            SelectFileRequest.Raise(new Notification
                {
                    Title = "Open Enemy",
                    Content = data
                },
                notification =>
                {
                    if (data.WasActionCanceled) return;

                    var enemyData = _dataManager.Load<CreatureData>($"Enemies\\{data.OpenedFile}");
                    Name = enemyData.Name;
                    TextureFileName = enemyData.TextureFile;
                    ScriptFileName = enemyData.Script;
                    HeartbeatInterval = enemyData.HeartbeatInterval;
                });
        }

        public DelegateCommand SaveEnemyCommand { get; set; }

        private void SaveEnemy()
        {
            FileSaverData data = new FileSaverData("json", "Enemies", "enemy", "Data\\Enemies\\", true);

            SaveFileRequest.Raise(new Notification
                {
                    Title = "Save Enemy",
                    Content = data
                },
                notification =>
                {
                    if (data.WasActionCanceled) return;

                    CreatureData enemyData = new CreatureData
                    {
                        Name = Name,
                        HeartbeatInterval = HeartbeatInterval,
                        Script = ScriptFileName,
                        TextureFile = TextureFileName
                    };

                    _dataManager.Save("Enemies\\Custom\\" + data.SavedFile, enemyData, true);
                });
        }

        public DelegateCommand SelectTextureFileCommand { get; set; }

        private void SelectTexture()
        {
            FileOpenerData data = new FileOpenerData("xnb", "Textures", "texture", "Graphics\\", true, true);

            SelectFileRequest.Raise(new Notification
                {
                    Title = "Select Texture",
                    Content = data
                },
                notification =>
                {
                    if (data.WasActionCanceled) return;
                    TextureFileName = data.UserSelectedNoneOption ? string.Empty : data.OpenedFile;
                });
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
        public InteractionRequest<INotification> SaveFileRequest { get; }

    }
}
