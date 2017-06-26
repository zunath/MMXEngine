using System;
using Microsoft.Win32;
using MMXEngine.Common.Constants;
using MMXEngine.Contracts.Managers;
using MMXEngine.ECS.Data;
using MMXEngine.Windows.Editor.Objects;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;

namespace MMXEngine.Windows.Editor.Views.ItemEditorView
{
    public class ItemEditorViewModel: BindableBase
    {
        private readonly IDataManager _dataManager;

        private readonly SaveFileDialog _saveFile;

        public ItemEditorViewModel(IDataManager dataManager)
        {
            _dataManager = dataManager;
            _saveFile = new SaveFileDialog();

            NewItemCommand = new DelegateCommand(NewItem);
            OpenItemCommand = new DelegateCommand(OpenItem);
            SaveItemCommand = new DelegateCommand(SaveItem);

            SelectTextureFileCommand = new DelegateCommand(SelectTexture);
            SelectScriptFileCommand = new DelegateCommand(SelectScript);

            SelectFileRequest = new InteractionRequest<INotification>();
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


        public DelegateCommand NewItemCommand { get; set; }

        private void NewItem()
        {
            Name = string.Empty;
            TextureFileName = string.Empty;
            ScriptFileName = string.Empty;
            HeartbeatInterval = 1.0f;
        }

        public DelegateCommand OpenItemCommand { get; set; }

        private void OpenItem()
        {
            FileOpenerData data = new FileOpenerData("json", "Items", "item", "Data\\Items\\", true, false);

            SelectFileRequest.Raise(new Notification
                {
                    Title = "Open Item",
                    Content = data
                },
                notification =>
                {
                    if (data.WasActionCanceled) return;

                    var itemData = _dataManager.Load<ItemData>($"Items\\{data.OpenedFile}");
                    Name = itemData.Name;
                    TextureFileName = itemData.TextureFile;
                    ScriptFileName = itemData.Script;
                    HeartbeatInterval = itemData.HeartbeatInterval;
                });
        }

        public DelegateCommand SaveItemCommand { get; set; }

        private void SaveItem()
        {
            ItemData data = new ItemData
            {
                Name = Name,
                HeartbeatInterval = HeartbeatInterval,
                Script = ScriptFileName,
                TextureFile = TextureFileName
            };

            _dataManager.Save("Items\\" + _saveFile.FileName, data);
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

    }
}
