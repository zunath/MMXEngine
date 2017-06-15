using Artemis;

namespace MMXEngine.Contracts.Managers
{
    public interface IScriptManager
    {
        void QueueScript(string scriptName, Entity entity, string methodName = "Main");
        void ExecuteScripts();
    }
}
