using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;

namespace MMXEngine.Windows.Editor.Views.ItemSelectorView
{
    public class ItemSelectorViewModel: BindableBase
    {
        public ItemSelectorViewModel()
        {
            NewItemCommand = new DelegateCommand(NewItem);
            NewFolderCommand = new DelegateCommand(NewFolder);
            EditItemCommand = new DelegateCommand(EditItem);
            DeleteItemCommand = new DelegateCommand(DeleteItem);

            ItemPropertiesRequest = new InteractionRequest<INotification>();
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


    }
}
