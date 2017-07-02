using MMXEngine.ECS.Data;
using MMXEngine.Windows.Editor.Events.LevelEditor;
using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;

namespace MMXEngine.Windows.Editor.Views.EnemySelectorView
{
    public class EnemySelectorViewModel: BindableBase
    {
        private readonly IEventAggregator _eventAggregator;

        public EnemySelectorViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            NewEnemyCommand = new DelegateCommand(NewEnemy);
            NewFolderCommand = new DelegateCommand(NewFolder);
            EditEnemyCommand = new DelegateCommand(EditEnemy);
            DeleteEnemyCommand = new DelegateCommand(DeleteEnemy);

            EnemyPropertiesRequest = new InteractionRequest<INotification>();

            _eventAggregator.GetEvent<LevelOpenedEvent>().Subscribe(OnLevelOpened);
            _eventAggregator.GetEvent<LevelClosedEvent>().Subscribe(OnLevelClosed);
        }

        private bool _isLevelLoaded;

        public bool IsLevelLoaded
        {
            get => _isLevelLoaded;
            set => SetProperty(ref _isLevelLoaded, value);
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



        private void OnLevelOpened(LevelData levelData)
        {
            IsLevelLoaded = true;
        }

        private void OnLevelClosed()
        {
            IsLevelLoaded = false;
        }

    }
}
