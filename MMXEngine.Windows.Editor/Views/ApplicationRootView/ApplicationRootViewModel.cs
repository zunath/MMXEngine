using MMXEngine.Windows.Editor.Events.Application;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace MMXEngine.Windows.Editor.Views.ApplicationRootView
{
    public class ApplicationRootViewModel: BindableBase
    {
        private readonly IEventAggregator _eventAggregator;

        public ApplicationRootViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            WindowLoadedCommand = new DelegateCommand(WindowLoaded);
        }

        public DelegateCommand WindowLoadedCommand { get; set; }

        private void WindowLoaded()
        {
            _eventAggregator.GetEvent<ApplicationWindowLoadedEvent>().Publish();
        }

    }
}
