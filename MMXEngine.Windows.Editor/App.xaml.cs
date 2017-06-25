using System.Windows;

namespace MMXEngine.Windows.Editor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var bootstrap = new Bootstrapper();
            bootstrap.Run();
        }
    }
}
