using System;
using System.Windows;
using System.Windows.Resources;
using System.Xml;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;

namespace MMXEngine.Windows.Editor.Views.ScriptEditorView
{
    /// <summary>
    /// Interaction logic for ScriptEditor.xaml
    /// </summary>
    public partial class ScriptEditor
    {
        public ScriptEditor()
        {
            InitializeComponent();
        }
        
        private void ScriptEditor_OnLoaded(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("/AvalonLanguageFiles/lua.xshd", UriKind.Relative);
            StreamResourceInfo resourceInfo = Application.GetResourceStream(uri);
            if (resourceInfo == null)
                throw new Exception("Could not load lua language file for script editor.");

            using (XmlTextReader reader = new XmlTextReader(resourceInfo.Stream))
            {
                var xshd = HighlightingLoader.LoadXshd(reader);
                Editor.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
            }

        }
    }
}
