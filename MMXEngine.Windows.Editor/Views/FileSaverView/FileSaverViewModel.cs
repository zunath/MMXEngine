﻿using System;
using System.IO.Abstractions;
using MMXEngine.Contracts.Managers;
using MMXEngine.Windows.Editor.Objects;
using MMXEngine.Windows.Editor.ViewModelBases;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;

namespace MMXEngine.Windows.Editor.Views.FileSaverView
{
    public class FileSaverViewModel: OpenSaveViewModelBase, IInteractionRequestAware
    {
        private FileSaverData _data;

        public FileSaverViewModel(IFileSystem fileSystem, IContentManager content)
            : base(fileSystem, content)
        {
            SaveFileCommand = new DelegateCommand(SaveFile);
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
                _data = (FileSaverData) _notification.Content;
                LoadFileSaverData();
            }
        }

        private new void CleanModel()
        {
            base.CleanModel();

            _data = null;
            FileName = string.Empty;
            SaveButtonText = string.Empty;
        }

        private void LoadFileSaverData()
        {
            RootDirectory = _data.RootDirectory;
            Extension = _data.Extension;
            FileName = string.Empty;

            SaveButtonText = $"Save {_data.CategorySingle}";

            LoadFiles();
        }
        
        private string _selectedFile;

        public string SelectedFile
        {
            get => _selectedFile;
            set
            {
                SetProperty(ref _selectedFile, value);
                SetProperty(ref _fileName, SelectedFile);
            }
        }

        private string _fileName;

        public string FileName
        {
            get => _fileName;
            set => SetProperty(ref _fileName, value);
        }

        private string _saveButtonText;

        public string SaveButtonText
        {
            get => _saveButtonText;
            set => SetProperty(ref _saveButtonText, value);
        }

        public DelegateCommand SaveFileCommand { get; set; }

        private void SaveFile()
        {
            if (string.IsNullOrWhiteSpace(FileName))
                return;

            _data.WasActionCanceled = false;
            _data.SavedFile = FileSystem.Path.GetFileNameWithoutExtension(FileName) + ".json";
            FinishInteraction();
            CleanModel();
        }

        public DelegateCommand CancelCommand { get; set; }

        private void Cancel()
        {
            FinishInteraction();
        }

        public Action FinishInteraction { get; set; }
    }
}
