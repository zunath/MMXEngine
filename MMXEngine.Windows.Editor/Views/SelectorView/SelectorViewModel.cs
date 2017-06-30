using System;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;

namespace MMXEngine.Windows.Editor.Views.SelectorView
{
    public class SelectorViewModel: BindableBase, IInteractionRequestAware
    {


        public INotification Notification { get; set; }
        public Action FinishInteraction { get; set; }
    }
}
