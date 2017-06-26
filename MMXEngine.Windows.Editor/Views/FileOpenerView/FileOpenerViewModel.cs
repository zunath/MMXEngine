using System;
using System.IO;
using System.IO.Abstractions;
using System.Windows;
using MMXEngine.Common.Observables;
using MMXEngine.Windows.Editor.Objects;
using MonoGame.Extended.Collections;
using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;

namespace MMXEngine.Windows.Editor.Views.FileOpenerView
{
    public class FileOpenerViewModel: BindableBase, IInteractionRequestAware
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IFileSystem _fileSystem;
        private FileSystemWatcher _fileSystemWatcher;
        private FileOpenerData _data;

        public FileOpenerViewModel(IEventAggregator eventAggregator,
            IFileSystem fileSystem)
        {
            _eventAggregator = eventAggregator;
            _fileSystem = fileSystem;

            Files = new ObservableCollectionEx<string>();

            OpenFileCommand = new DelegateCommand(OpenFile);
            CancelCommand = new DelegateCommand(Cancel);
        }

        private INotification _notification;
        public INotification Notification
        {
            get => _notification;
            set
            {
                SetProperty(ref _notification, value);
                _data = (FileOpenerData)_notification.Content;
                LoadFileOpenerData();
            }
        }

        private void CleanModel()
        {
            _data = null;
            HeaderText = string.Empty;
            OpenFileButtonText = string.Empty;

            if (_fileSystemWatcher != null)
            {
                _fileSystemWatcher.Created -= FileSystemWatcherOnCreated;
                _fileSystemWatcher.Deleted -= FileSystemWatcherOnDeleted;
                _fileSystemWatcher.Renamed -= FileSystemWatcherOnRenamed;
            }

            Files?.Clear();
        }

        private void LoadFileOpenerData()
        {
            _data.RootDirectory = _data.RootDirectory.Replace("/", "\\");
            HeaderText = $"Please select a {_data.CategorySingle.ToLower()} file to open.";
            OpenFileButtonText = $"Open {_data.CategorySingle}";

            if (_data.WatchDirectory)
            {
                _fileSystemWatcher = new FileSystemWatcher(_data.RootDirectory, $"*.{_data.Extension}")
                {
                    IncludeSubdirectories = true
                };
                _fileSystemWatcher.Created += FileSystemWatcherOnCreated;
                _fileSystemWatcher.Deleted += FileSystemWatcherOnDeleted;
                _fileSystemWatcher.Renamed += FileSystemWatcherOnRenamed;
                _fileSystemWatcher.EnableRaisingEvents = true;
            }

            if (_data.ShowNoneOption)
            {
                Files.Add("<NONE>");
            }

            foreach (var file in _fileSystem.Directory.GetFiles(_data.RootDirectory, $"*.{_data.Extension}", SearchOption.AllDirectories))
            {
                Files.Add(FilePathToRelativeToRootDirectory(file));
            }
        }

        private string FilePathToRelativeToRootDirectory(string filePath)
        {
            string directory = _fileSystem.Path.GetDirectoryName(filePath)
                .Replace(_data.RootDirectory, string.Empty);
            return $"{directory}\\{_fileSystem.Path.GetFileName(filePath)}";
        }

        private void FileSystemWatcherOnCreated(object sender, FileSystemEventArgs e)
        {
            string name = FilePathToRelativeToRootDirectory(e.Name);
            if (Path.GetExtension(e.Name) != $".{_data.Extension.ToLower()}") return;

            Application.Current.Dispatcher.Invoke(() =>
            {
                Files.Add(name);
            });
        }

        private void FileSystemWatcherOnDeleted(object sender, FileSystemEventArgs e)
        {
            string name = FilePathToRelativeToRootDirectory(e.Name);
            if (Path.GetExtension(e.Name) != $".{_data.Extension.ToLower()}") return;

            Application.Current.Dispatcher.Invoke(() =>
            {
                Files.Remove(name);
            });
        }

        private void FileSystemWatcherOnRenamed(object sender, RenamedEventArgs e)
        {
            string oldName = FilePathToRelativeToRootDirectory(e.OldName);
            string newName = FilePathToRelativeToRootDirectory(e.Name);
            
            Application.Current.Dispatcher.Invoke(() =>
            {
                if (Path.GetExtension(e.OldName) == $".{_data.Extension.ToLower()}")
                    Files.Remove(oldName);
                if (Path.GetExtension(e.Name) == $".{_data.Extension.ToLower()}")
                    Files.Add(newName);
            });
        }



        public Action FinishInteraction { get; set; }
        

        private string _headerText;

        public string HeaderText
        {
            get => _headerText;
            set => SetProperty(ref _headerText, value);
        }

        private ObservableCollectionEx<string> _files;

        public ObservableCollectionEx<string> Files
        {
            get => _files;
            set => SetProperty(ref _files, value);
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
            _data.OpenedFile = _selectedFile;
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
            CleanModel();
        }
    }
}
