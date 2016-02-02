using System;
using Artemis;
using MMXEngine.ECS.Components;
using MMXEngine.Interfaces.Systems;

namespace MMXEngine.ScriptEngine.Methods
{
    public class MiscellaneousMethods: IScriptMethodGroup
    {
        public static void Print(string message)
        {
            Console.WriteLine(message);
        }

        public static string GetScriptName(Entity entity)
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
