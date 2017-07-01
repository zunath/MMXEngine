using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using MMXEngine.Common.Observables;
using MMXEngine.Windows.Editor.Events.Application;
using MMXEngine.Windows.Editor.Objects;
using Prism.Events;
using Prism.Mvvm;

namespace MMXEngine.Windows.Editor.Views.FileDirectoryTreeSelectorView
{
    public class FileDirectoryTreeSelectorViewModel: BindableBase
    {
        private readonly IFileSystem _fileSystem;
        private readonly IEventAggregator _eventAggregator;
        private FileSystemWatcher _watcher;

        public FileDirectoryTreeSelectorViewModel(
            IFileSystem fileSystem,
            IEventAggregator eventAggregator)
        {
            _fileSystem = fileSystem;
            _eventAggregator = eventAggregator;

            Items = new ObservableCollectionEx<PathItem>();
            _eventAggregator.GetEvent<ApplicationWindowLoadedEvent>().Subscribe(OnApplicationWindowLoaded);
        }


        private string _directorySource;

        public string DirectorySource
        {
            get => _directorySource;
            set => SetProperty(ref _directorySource, value);
        }

        private string _filter;

        public string Filter
        {
            get => _filter;
            set => SetProperty(ref _filter, value);
        }

        private ObservableCollectionEx<PathItem> _items;

        public ObservableCollectionEx<PathItem> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }


        private IEnumerable<PathItem> LoadFiles(string path)
        {
            var items = new List<PathItem>();
            var dirInfo = _fileSystem.DirectoryInfo.FromDirectoryName(path);

            foreach (var directory in dirInfo.GetDirectories())
            {
                var item = new DirectoryItem
                {
                    Name = directory.Name,
                    Path = directory.FullName,
                    Items = LoadFiles(directory.FullName).ToList()
                };

                items.Add(item);
            }

            foreach (var file in dirInfo.GetFiles())
            {
                var item = new FileItem
                {
                    Name = file.Name,
                    Path = file.FullName
                };

                items.Add(item);
            }

            return items;
        }

        private void OnApplicationWindowLoaded()
        {
            var items = LoadFiles(DirectorySource);
            foreach (var item in items)
            {
                Items.Add(item);
            }

            LoadFileWatcher();
        }

        private void LoadFileWatcher()
        {
            if (_watcher != null)
            {
                _watcher.Created -= WatcherOnCreated;
                _watcher.Deleted -= WatcherOnDeleted;
                _watcher.Renamed -= WatcherOnRenamed;
            }

            _watcher = new FileSystemWatcher(DirectorySource)
            {
                IncludeSubdirectories = true
            };

            if (!string.IsNullOrWhiteSpace(Filter))
            {
                _watcher.Filter = Filter;
            }

            _watcher.Created += WatcherOnCreated;
            _watcher.Deleted += WatcherOnDeleted;
            _watcher.Renamed += WatcherOnRenamed;
            _watcher.EnableRaisingEvents = true;
        }

        private void WatcherOnCreated(object sender, FileSystemEventArgs e)
        {
            
        }

        private void WatcherOnDeleted(object sender, FileSystemEventArgs e)
        {

        }

        private void WatcherOnRenamed(object sender, RenamedEventArgs e)
        {
            
        }


    }
}
