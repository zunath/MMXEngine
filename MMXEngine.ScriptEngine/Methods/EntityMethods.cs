using System;
using Artemis;
using MMXEngine.ECS.Components;
using MMXEngine.Interfaces.Systems;

namespace MMXEngine.ScriptEngine.Methods
{
    public class EntityMethods: IScriptMethodGroup
    {
        public static string GetName(Entity entity)
        {
            try
            {
                return entity.GetComponent<Nameable>().Name;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
