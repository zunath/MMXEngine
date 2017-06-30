using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using MMXEngine.Common.Observables;
using MMXEngine.Windows.Editor.Events.Application;
using MMXEngine.Windows.Editor.Objects;
using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;

namespace MMXEngine.Windows.Editor.Views.EnemySelectorView
{
    public class EnemySelectorViewModel: BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IFileSystem _fileSystem;
        private const string RootFileDirectory = ".\\Content\\Data\\Enemies\\";

        public EnemySelectorViewModel(
            IEventAggregator eventAggregator,
            IFileSystem fileSystem)
        {
            _eventAggregator = eventAggregator;
            _fileSystem = fileSystem;
            Items = new ObservableCollectionEx<PathItem>();

            NewEnemyCommand = new DelegateCommand(NewEnemy);
            NewFolderCommand = new DelegateCommand(NewFolder);
            EditEnemyCommand = new DelegateCommand(EditEnemy);
            DeleteEnemyCommand = new DelegateCommand(DeleteEnemy);

            EnemyPropertiesRequest = new InteractionRequest<INotification>();

            _eventAggregator.GetEvent<ApplicationWindowLoadedEvent>().Subscribe(OnApplicationWindowLoaded);
        }

        private ObservableCollectionEx<PathItem> _items;

        public ObservableCollectionEx<PathItem> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        private void OnApplicationWindowLoaded()
        {
            var items = LoadFiles(RootFileDirectory);
            foreach (var item in items)
            {
                Items.Add(item);
            }

            LoadFileWatcher();
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

        private void LoadFileWatcher()
        {
            
        }

        public DelegateCommand NewEnemyCommand { get; set; }

        private void NewEnemy()
        {
            EnemyPropertiesRequest.Raise(new Notification
            {
                Title = "Enemy Properties",
                Content = ""
            });
        }

        public DelegateCommand NewFolderCommand { get; set; }

        private void NewFolder()
        {
            
        }

        public DelegateCommand EditEnemyCommand { get; set; }

        private void EditEnemy()
        {
            
        }

        public DelegateCommand DeleteEnemyCommand { get; set; }

        private void DeleteEnemy()
        {
            
        }

        public InteractionRequest<INotification> EnemyPropertiesRequest { get; }



    }
}
