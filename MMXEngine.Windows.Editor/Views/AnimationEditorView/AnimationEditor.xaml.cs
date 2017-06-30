using System.ComponentModel;

namespace MMXEngine.Windows.Editor.Views.AnimationEditorView
{
    /// <summary>
    /// Interaction logic for AnimationEditor.xaml
    /// </summary>
    public partial class AnimationEditor
    {
        public AnimationEditor()
        {
            InitializeComponent();

            if (DesignerProperties.GetIsInDesignMode(this)) return;
            ((AnimationEditorViewModel)DataContext).GameGrid = GameGrid;
        }
    }
}
