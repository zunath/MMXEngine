using System.Windows;
using MMXEngine.Windows.Editor.Events.Application;
using MMXEngine.Windows.Editor.GameWorld;
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

        public ApplicationRoot(IEventAggregator eventAggregator,
            EditorGame game)
        {
            InitializeComponent();

            _eventAggregator = eventAggregator;

            GameGrid.Children.Add(game);

            _eventAggregator.GetEvent<ApplicationClosedEvent>().Subscribe(CloseApplication);

        }

        private void CloseApplication()
        {
            Application.Current.Shutdown();
        }

    }
}
