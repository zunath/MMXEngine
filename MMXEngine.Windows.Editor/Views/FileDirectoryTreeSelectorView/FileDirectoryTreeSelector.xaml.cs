using System.ComponentModel;
using System.Windows;
using MMXEngine.Windows.Editor.Objects;

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

        public string ConsumerID
        {
            get
            {
                if (DesignerProperties.GetIsInDesignMode(this)) return string.Empty;
                return _viewModel.ConsumerID;
            }
            set
            {
                if (DesignerProperties.GetIsInDesignMode(this)) return;
                _viewModel.ConsumerID = value;
            }
        }
        
        public PathItem SelectedItem
        {
            get
            {
                if (DesignerProperties.GetIsInDesignMode(this)) return null;
                return (PathItem)GetValue(SelectedItemProperty);
            }
            set
            {
                if (DesignerProperties.GetIsInDesignMode(this)) return;
                SetValue(SelectedItemProperty, value);
            }
        }

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(
                "SelectedItem", 
                typeof(PathItem), 
                typeof(FileDirectoryTreeSelector));
        
    }
}
