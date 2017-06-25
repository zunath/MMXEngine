using MMXEngine.Windows.Editor.Events.Application;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace MMXEngine.Windows.Editor.Views.MenuBarView
{
    public class MenuBarViewModel: BindableBase
    {
        private readonly IEventAggregator _eventAggregator;


        public MenuBarViewModel()
        {

        }

        public MenuBarViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            
            ExitCommand = new DelegateCommand(Exit);
            UndoCommand = new DelegateCommand(Undo);
            RedoCommand = new DelegateCommand(Redo);
            CopyCommand = new DelegateCommand(Copy);
            CutCommand = new DelegateCommand(Cut);
            PasteCommand = new DelegateCommand(Paste);
        }


        public DelegateCommand ExitCommand { get; set; }

        private void Exit()
        {
            _eventAggregator.GetEvent<ApplicationClosedEvent>().Publish();
        }


        public DelegateCommand UndoCommand { get; set; }

        private void Undo()
        {

        }

        public DelegateCommand RedoCommand { get; set; }

        private void Redo()
        {

        }

        public DelegateCommand CopyCommand { get; set; }

        private void Copy()
        {

        }

        public DelegateCommand CutCommand { get; set; }

        private void Cut()
        {

        }

        public DelegateCommand PasteCommand { get; set; }

        private void Paste()
        {

        }
    }
}
