using Prism.Mvvm;

namespace MMXEngine.Windows.Editor.Objects
{
    public class PathItem: BindableBase
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _path;

        public string Path
        {
            get => _path;
            set => SetProperty(ref _path, value);
        }
    }
}
