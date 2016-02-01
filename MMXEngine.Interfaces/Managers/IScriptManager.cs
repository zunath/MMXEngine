using MMXEngine.Interfaces.Entities;

namespace MMXEngine.Interfaces.Managers
{
    public interface IScriptManager
    {
        void QueueScript(string scriptName, IGameEntity entity);
        void ExecuteScripts();
    }
}
