using MMXEngine.Common.Observables;
using MMXEngine.Windows.Editor.Objects;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;

namespace MMXEngine.Windows.Editor.Views.EnemySelectorView
{
    public class EnemySelectorViewModel: BindableBase
    {
        public EnemySelectorViewModel()
        { 

            NewEnemyCommand = new DelegateCommand(NewEnemy);
            NewFolderCommand = new DelegateCommand(NewFolder);
            EditEnemyCommand = new DelegateCommand(EditEnemy);
            DeleteEnemyCommand = new DelegateCommand(DeleteEnemy);

            EnemyPropertiesRequest = new InteractionRequest<INotification>();
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
