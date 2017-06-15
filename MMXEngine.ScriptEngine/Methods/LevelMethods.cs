using System;
using Artemis;
using MMXEngine.Contracts.ScriptMethods;
using MMXEngine.ECS.Components;

namespace MMXEngine.ScriptEngine.Methods
{
    public class LevelMethods: ILevelMethods
    {
        public int GetMapWidth(Entity entity)
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

        public int GetMapHeight(Entity entity)
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
