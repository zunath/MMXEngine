using System.IO;
using System.IO.Abstractions;
using System.Windows;
using Microsoft.Xna.Framework.Content;
using MMXEngine.Common.Observables;
using Prism.Mvvm;

namespace MMXEngine.Windows.Editor.ViewModelBases
{
    public abstract class OpenSaveViewModelBase: BindableBase
    {
        protected readonly IFileSystem FileSystem;
        private FileSystemWatcher _fileSystemWatcher;
        private readonly ContentManager _content;

        private string _rootDirectory;

        protected string RootDirectory
        {
            get => _rootDirectory;
            set
            {
                string newVal = value.Replace("/", "\\");
                newVal = _content.RootDirectory + "\\" + newVal;
                SetProperty(ref _rootDirectory, newVal);
            }   
        }

        private string _extension;

        protected string Extension
        {
            get => _extension;
            set => SetProperty(ref _extension, value);
        }


        private ObservableCollectionEx<string> _files;

        public ObservableCollectionEx<string> Files
        {
            get => _files;
            set => SetProperty(ref _files, value);
        }

        protected OpenSaveViewModelBase(IFileSystem fileSystem, ContentManager content)
        {
            FileSystem = fileSystem;
            _content = content;

            Files = new ObservableCollectionEx<string>();
        }

        protected void CleanModel()
        {
            if (_fileSystemWatcher != null)
            {
                _fileSystemWatcher.Created -= FileSystemWatcherOnCreated;
                _fileSystemWatcher.Deleted -= FileSystemWatcherOnDeleted;
                _fileSystemWatcher.Renamed -= FileSystemWatcherOnRenamed;
            }

            RootDirectory = string.Empty;
            Extension = string.Empty;
            Files?.Clear();
        }

        protected void LoadFiles()
        {
            foreach (var file in FileSystem.Directory.GetFiles(RootDirectory, $"*.{Extension}", SearchOption.AllDirectories))
            {
                Files.Add(FilePathToRelativeToRootDirectory(file));
            }
        }

        protected void LoadFileWatcher()
        {
            _fileSystemWatcher = new FileSystemWatcher(RootDirectory, $"*.{Extension}")
            {
                IncludeSubdirectories = true
            };
            _fileSystemWatcher.Created += FileSystemWatcherOnCreated;
            _fileSystemWatcher.Deleted += FileSystemWatcherOnDeleted;
            _fileSystemWatcher.Renamed += FileSystemWatcherOnRenamed;
            _fileSystemWatcher.EnableRaisingEvents = true;
        }

        private string FilePathToRelativeToRootDirectory(string filePath)
        {
            var fileName = FileSystem.Path.GetFileName(filePath);
            var directoryName = FileSystem.Path.GetDirectoryName(filePath);
            if (!directoryName.EndsWith("\\"))
                directoryName += "\\";

            string directory = directoryName
                .Replace(RootDirectory, string.Empty);
            return $"{directory}{fileName}";
        }

        private void FileSystemWatcherOnCreated(object sender, FileSystemEventArgs e)
        {
            string name = FilePathToRelativeToRootDirectory(e.Name);
            if (Path.GetExtension(e.Name) != $".{Extension.ToLower()}") return;

            Application.Current.Dispatcher.Invoke(() =>
            {
                Files.Add(name);
            });
        }

        private void FileSystemWatcherOnDeleted(object sender, FileSystemEventArgs e)
        {
            string name = FilePathToRelativeToRootDirectory(e.Name);
            if (Path.GetExtension(e.Name) != $".{Extension.ToLower()}") return;

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
                if (Path.GetExtension(e.OldName) == $".{Extension.ToLower()}")
                    Files.Remove(oldName);
                if (Path.GetExtension(e.Name) == $".{Extension.ToLower()}")
                    Files.Add(newName);
            });
        }


    }
}
