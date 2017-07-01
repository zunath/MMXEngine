using System.ComponentModel;

namespace MMXEngine.Windows.Editor.Views.FileDirectoryTreeSelectorView
{
    public partial class FileDirectoryTreeSelector
    {
        private readonly FileDirectoryTreeSelectorViewModel _viewModel;

        public FileDirectoryTreeSelector()
        {
            InitializeComponent();

            if (DesignerProperties.GetIsInDesignMode(this)) return;
            _viewModel = (FileDirectoryTreeSelectorViewModel) DataContext;
        }

        public string DirectorySource
        {
            get
            {
                if(DesignerProperties.GetIsInDesignMode(this)) return string.Empty;
                return _viewModel.DirectorySource;
            }
            set
            {
                if (DesignerProperties.GetIsInDesignMode(this)) return;
                _viewModel.DirectorySource = value;
            } 
        }

        public string Filter
        {
            get
            {
                if (DesignerProperties.GetIsInDesignMode(this)) return string.Empty;
                return _viewModel.Filter;
            }
            set
            {
                if (DesignerProperties.GetIsInDesignMode(this)) return;
                _viewModel.Filter = value;
            }
        }
    }
}
