using Artemis;

namespace MMXEngine.Interfaces.Managers
{
    public interface IScriptManager
    {
        void QueueScript(string scriptName, Entity entity, string methodName = "Main");
        void ExecuteScripts();
    }
}
