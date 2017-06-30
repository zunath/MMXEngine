using MMXEngine.ECS.Data;
using MMXEngine.Windows.Editor.Events.LevelEditor;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace MMXEngine.Windows.Editor.Views.LevelSelectorView
{
    public class LevelSelectorViewModel: BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private LevelData _levelData;

        public LevelSelectorViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            NewLevelCommand = new DelegateCommand(NewLevel);
            NewFolderCommand = new DelegateCommand(NewFolder);
            OpenLevelCommand = new DelegateCommand(OpenLevel);
            DeleteLevelCommand = new DelegateCommand(DeleteLevel);
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
            
            _eventAggregator.GetEvent<LevelOpenedEvent>().Publish(_levelData);
        }

        public DelegateCommand DeleteLevelCommand { get; set; }

        private void DeleteLevel()
        {
            
        }
    }
}
