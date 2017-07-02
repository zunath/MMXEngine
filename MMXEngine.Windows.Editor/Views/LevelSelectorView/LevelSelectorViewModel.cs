using System;
using MMXEngine.Contracts.Managers;
using MMXEngine.ECS.Data;
using MMXEngine.Windows.Editor.Events.Controls;
using MMXEngine.Windows.Editor.Events.LevelEditor;
using MMXEngine.Windows.Editor.Objects;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace MMXEngine.Windows.Editor.Views.LevelSelectorView
{
    public class LevelSelectorViewModel: BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IDataManager _dataManager;
        private LevelData _levelData;

        public LevelSelectorViewModel(IEventAggregator eventAggregator,
            IDataManager dataManager)
        {
            _eventAggregator = eventAggregator;
            _dataManager = dataManager;

            NewLevelCommand = new DelegateCommand(NewLevel);
            NewFolderCommand = new DelegateCommand(NewFolder);
            OpenLevelCommand = new DelegateCommand(OpenLevel);
            DeleteLevelCommand = new DelegateCommand(DeleteLevel);

            _eventAggregator.GetEvent<FileDirectoryTreeViewSelectedItemEvent>().Subscribe(OnItemSelected);
        }

        private void OnItemSelected(Tuple<string, PathItem> payload)
        {
            // This is a workaround for limitations with UserControls inside UserControls.
            // Custom DependencyProperty was not hooking to consumer objects.
            // Temporary fix until I can get around this limitation.
            if (payload.Item1 == "e43eb036-a702-4c41-b230-a6f0e7842391")
            {
                SelectedItem = payload.Item2;
            }
        }

        private PathItem _selectedItem;

        public PathItem SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        public DelegateCommand NewLevelCommand { get; set; }

        private void NewLevel()
        {
            
        }

        public DelegateCommand NewFolderCommand { get; set; }

        private void NewFolder()
        {
            
        }

        public DelegateCommand OpenLevelCommand { get; set; }

        private void OpenLevel()
        {
            if (SelectedItem != null)
            {
                _levelData = _dataManager.Load<LevelData>("Levels\\" + SelectedItem.Name);
                _eventAggregator.GetEvent<LevelOpenedEvent>().Publish(_levelData);
            }

        }

        public DelegateCommand DeleteLevelCommand { get; set; }

        private void DeleteLevel()
        {
            
        }
    }
}
