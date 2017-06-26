using System;
using System.IO.Abstractions;
using Microsoft.Xna.Framework.Content;
using MMXEngine.Windows.Editor.Objects;
using MMXEngine.Windows.Editor.ViewModelBases;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;

namespace MMXEngine.Windows.Editor.Views.FileOpenerView
{
    public class FileOpenerViewModel: OpenSaveViewModelBase, IInteractionRequestAware
    {
        private FileOpenerData _data;

        public FileOpenerViewModel(IFileSystem fileSystem, ContentManager content)
            : base(fileSystem, content)
        {
            OpenFileCommand = new DelegateCommand(OpenFile);
            CancelCommand = new DelegateCommand(Cancel);
        }

        private INotification _notification;
        public INotification Notification
        {
            get => _notification;
            set
            {
                CleanModel();
                SetProperty(ref _notification, value);
                _data = (FileOpenerData)_notification.Content;
                LoadFileOpenerData();
            }
        }

        private new void CleanModel()
        {
            base.CleanModel();

            _data = null;
            HeaderText = string.Empty;
            OpenFileButtonText = string.Empty;
        }

        private void LoadFileOpenerData()
        {
            RootDirectory = _data.RootDirectory;
            Extension = _data.Extension;
            HeaderText = $"Please select the {_data.CategorySingle.ToLower()} file to open.";
            OpenFileButtonText = $"Open {_data.CategorySingle}";

            if (_data.WatchDirectory)
            {
                LoadFileWatcher();
            }

            if (_data.ShowNoneOption)
            {
                Files.Add("<NONE>");
            }

            LoadFiles();
        }


        public Action FinishInteraction { get; set; }
        

        private string _headerText;

        public string HeaderText
        {
            get => _headerText;
            set => SetProperty(ref _headerText, value);
        }


        private string _selectedFile;

        public string SelectedFile
        {
            get => _selectedFile;
            set => SetProperty(ref _selectedFile, value);
        }

        public DelegateCommand OpenFileCommand { get; set; }

        private void OpenFile()
        {
            if (string.IsNullOrWhiteSpace(SelectedFile))
                return;

            _data.WasActionCanceled = false;
            _data.OpenedFile = SelectedFile;
            _data.UserSelectedNoneOption = SelectedFile == "<NONE>";

            FinishInteraction();
            CleanModel();
        }

        private string _openFileButtonText;

        public string OpenFileButtonText
        {
            get => _openFileButtonText;
            set => SetProperty(ref _openFileButtonText, value);
        }

        public DelegateCommand CancelCommand { get; set; }

        private void Cancel()
        {
            FinishInteraction();
        }

    }
}
