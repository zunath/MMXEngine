using System.Linq;
using MMXEngine.Contracts.Managers;
using MonoGame.Extended.Collections;
using Prism.Mvvm;

namespace MMXEngine.Windows.Editor.Views.ScriptEditorView
{
    public class ScriptEditorViewModel: BindableBase
    {
        private readonly IScriptManager _scriptManager;

        public ScriptEditorViewModel(IScriptManager scriptManager)
        {
            _scriptManager = scriptManager;
            Methods = new ObservableCollection<string>();
            Constants = new ObservableCollection<string>();

            LoadHelperBox();
        }

        private ObservableCollection<string> _methods;

        public ObservableCollection<string> Methods
        {
            get => _methods;
            set => SetProperty(ref _methods, value);
        }

        private ObservableCollection<string> _constants;

        public ObservableCollection<string> Constants
        {
            get => _constants;
            set => SetProperty(ref _constants, value);
        }

        private void LoadHelperBox()
        {
            var methods = _scriptManager.GetRegisteredMethods().ToList();
            foreach (var method in methods)
            {
                Methods.Add(method.Replace("(", string.Empty).Replace(")", string.Empty));
            }

            var constants = _scriptManager.GetRegisteredEnumerations().ToList();

            foreach (var constant in constants)
            {
                Constants.Add(constant);
            }

            
        }

    }
}
