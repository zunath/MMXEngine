using System;
using Artemis;
using MMXEngine.ECS.Components;
using MMXEngine.Interfaces.Systems;

namespace MMXEngine.ScriptEngine.Methods
{
    public class LevelMethods: IScriptMethodGroup
    {
        public static int GetMapWidth(Entity entity)
        {
            try
            {
                return entity.GetComponent<Map>().Width;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static int GetMapHeight(Entity entity)
        {
            try
            {
                return entity.GetComponent<Map>().Height;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
