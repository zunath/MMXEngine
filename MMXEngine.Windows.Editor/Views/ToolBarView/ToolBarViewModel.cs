using System;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;

namespace MMXEngine.Windows.Editor.Views.ToolBarView
{
    public class ToolBarViewModel: BindableBase
    {
        public ToolBarViewModel()
        {
            OpenScriptEditorCommand = new DelegateCommand(OpenScriptEditor);
            ScriptEditorRequest = new InteractionRequest<INotification>();
        }

        public DelegateCommand OpenScriptEditorCommand { get; set; }

        private void OpenScriptEditor()
        {
            ScriptEditorRequest.Raise(new Notification
            {
                Content = "",
                Title = "Script Editor"
            });
        }

        public InteractionRequest<INotification> ScriptEditorRequest { get; }
    }
}
