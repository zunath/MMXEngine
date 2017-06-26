using System.ComponentModel;

namespace MMXEngine.Windows.Editor.Views.LevelEditorView
{
    /// <summary>
    /// Interaction logic for LevelEditor.xaml
    /// </summary>
    public partial class LevelEditor
    {
        public LevelEditor()
        {
            InitializeComponent();

            if (DesignerProperties.GetIsInDesignMode(this)) return;
            ((LevelEditorViewModel) DataContext).GameGrid = GameGrid;
        }
    }
}
