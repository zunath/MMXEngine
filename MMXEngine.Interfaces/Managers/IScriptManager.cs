using System.Collections.Generic;
using Artemis;

namespace MMXEngine.Contracts.Managers
{
    public interface IScriptManager
    {
        void QueueScript(string scriptName, Entity entity, string methodName = "Main");
        void ExecuteScripts();
        IEnumerable<string> GetRegisteredEnumerations();

        string ValidateScript(string scriptText);
    }
}
