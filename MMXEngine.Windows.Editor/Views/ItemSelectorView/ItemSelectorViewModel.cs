using MMXEngine.ECS.Data;
using MMXEngine.Windows.Editor.Events.LevelEditor;
using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;

namespace MMXEngine.Windows.Editor.Views.ItemSelectorView
{
    public class ItemSelectorViewModel: BindableBase
    {
        private readonly IEventAggregator _eventAggregator;

        public ItemSelectorViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            NewItemCommand = new DelegateCommand(NewItem);
            NewFolderCommand = new DelegateCommand(NewFolder);
            EditItemCommand = new DelegateCommand(EditItem);
            DeleteItemCommand = new DelegateCommand(DeleteItem);

            ItemPropertiesRequest = new InteractionRequest<INotification>();

            _eventAggregator.GetEvent<LevelOpenedEvent>().Subscribe(OnLevelOpened);
            _eventAggregator.GetEvent<LevelClosedEvent>().Subscribe(OnLevelClosed);
        }

        private bool _isLevelLoaded;

        public bool IsLevelLoaded
        {
            get => _isLevelLoaded;
            set => SetProperty(ref _isLevelLoaded, value);
        }

        public DelegateCommand NewItemCommand { get; set; }

        private void NewItem()
        {
            ItemPropertiesRequest.Raise(new Notification
            {
                Title = "Item Properties",
                Content = ""
            });
        }

        public DelegateCommand NewFolderCommand { get; set; }

        private void NewFolder()
        {

        }

        public DelegateCommand EditItemCommand { get; set; }

        private void EditItem()
        {

        }

        public DelegateCommand DeleteItemCommand { get; set; }

        private void DeleteItem()
        {

        }

        public InteractionRequest<INotification> ItemPropertiesRequest { get; }


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
