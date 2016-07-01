using System;
using Artemis;
using MMXEngine.ECS.Components;
using MMXEngine.Interfaces.Systems;

namespace MMXEngine.ScriptEngine.Methods
{
    public class LocalDataMethods: IScriptMethodGroup
    {
        public static void SetLocalValue(Entity entity, string key, string value)
        {
            if (!entity.HasComponent<LocalData>()) return;
            LocalData data = entity.GetComponent<LocalData>();
            data.LocalStrings[key] = value;
        }
        
        public static void SetLocalValue(Entity entity, string key, float value)
        {
            if (!entity.HasComponent<LocalData>()) return;
            LocalData data = entity.GetComponent<LocalData>();
            data.LocalFloats[key] = value;
        }

        public static string GetLocalString(Entity entity, string key)
        {
            if (!entity.HasComponent<LocalData>()) return string.Empty;
            LocalData data = entity.GetComponent<LocalData>();
            return data.LocalStrings.ContainsKey(key) ? data.LocalStrings[key] : string.Empty;
        }
        
        public static float GetLocalNumber(Entity entity, string key)
        {
            if (!entity.HasComponent<LocalData>()) return 0.0f;
            LocalData data = entity.GetComponent<LocalData>();
            return data.LocalFloats.ContainsKey(key) ? data.LocalFloats[key] : 0.0f;
        }
    }
}
