using Artemis;

namespace MMXEngine.Contracts.ScriptMethods
{
    public interface IMiscellaneousMethods
    {
        void Print(string message);
        string GetScriptName(Entity entity);
    }
}
