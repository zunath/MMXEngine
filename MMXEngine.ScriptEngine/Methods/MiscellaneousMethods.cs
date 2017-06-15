using System;
using Artemis;
using MMXEngine.Contracts.ScriptMethods;
using MMXEngine.ECS.Components;

namespace MMXEngine.ScriptEngine.Methods
{
    public class MiscellaneousMethods: IMiscellaneousMethods
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }

        public string GetScriptName(Entity entity)
        {
            try
            {
                return entity.GetComponent<Script>().FilePath;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
