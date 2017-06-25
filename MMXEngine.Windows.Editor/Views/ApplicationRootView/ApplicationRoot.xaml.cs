using System.Windows;
using MMXEngine.Windows.Editor.Events.Application;
using Prism.Events;

namespace MMXEngine.Windows.Editor.Views.ApplicationRootView
{
    public partial class ApplicationRoot
    {
        private readonly IEventAggregator _eventAggregator;

        public ApplicationRoot()
        {
            InitializeComponent();
        }

        public ApplicationRoot(IEventAggregator eventAggregator)
        {
            InitializeComponent();

            _eventAggregator = eventAggregator;


            _eventAggregator.GetEvent<ApplicationClosedEvent>().Subscribe(CloseApplication);

        }

        private void CloseApplication()
        {
            Application.Current.Shutdown();
        }

    }
}
