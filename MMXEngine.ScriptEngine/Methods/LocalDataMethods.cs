using Artemis;
using MMXEngine.Common.Attributes;
using MMXEngine.Contracts.ScriptMethods;
using MMXEngine.ECS.Components;

namespace MMXEngine.ScriptEngine.Methods
{
    /// <summary>
    /// Script methods used for accessing local data stored on entities.
    /// </summary>
    [ScriptNamespace("LocalData")]
    public class LocalDataMethods: ILocalDataMethods
    {
        /// <summary>
        /// Sets a local value on an entity.
        /// </summary>
        /// <param name="entity">The entity to store data on.</param>
        /// <param name="key">The unique key to store the data at.</param>
        /// <param name="value">The data to store on the entity.</param>
        public void SetLocalValue(Entity entity, string key, string value)
        {
            if (!entity.HasComponent<LocalData>()) return;
            LocalData data = entity.GetComponent<LocalData>();
            data.LocalStrings[key] = value;
        }

        /// <summary>
        /// Sets a local value on an entity.
        /// </summary>
        /// <param name="entity">The entity to store data on.</param>
        /// <param name="key">The unique key to store the data at.</param>
        /// <param name="value">The data to store on the entity.</param>
        public void SetLocalValue(Entity entity, string key, float value)
        {
            if (!entity.HasComponent<LocalData>()) return;
            LocalData data = entity.GetComponent<LocalData>();
            data.LocalFloats[key] = value;
        }

        /// <summary>
        /// Returns a local string on an entity.
        /// </summary>
        /// <param name="entity">The entity to retrieve data from.</param>
        /// <param name="key">The key of the data to retrieve.</param>
        /// <returns>The data stored on the entity for the specified key.</returns>
        public string GetLocalString(Entity entity, string key)
        {
            if (!entity.HasComponent<LocalData>()) return string.Empty;
            LocalData data = entity.GetComponent<LocalData>();
            return data.LocalStrings.ContainsKey(key) ? data.LocalStrings[key] : string.Empty;
        }
        
        /// <summary>
        /// Returns a local number on an entity.
        /// </summary>
        /// <param name="entity">The entity to retrieve data from.</param>
        /// <param name="key">The key of the data to retrieve.</param>
        /// <returns>The data stored on the entity for the specified key.</returns>
        public float GetLocalNumber(Entity entity, string key)
        {
            if (!entity.HasComponent<LocalData>()) return 0.0f;
            LocalData data = entity.GetComponent<LocalData>();
            return data.LocalFloats.ContainsKey(key) ? data.LocalFloats[key] : 0.0f;
        }

        /// <summary>
        /// Removes data stored on an entity for a specified key.
        /// </summary>
        /// <param name="entity">The entity to delete data from.</param>
        /// <param name="key">The key of the data to delete.</param>
        public void DeleteLocalString(Entity entity, string key)
        {
            if (!entity.HasComponent<LocalData>()) return;
            LocalData data = entity.GetComponent<LocalData>();
            if (data.LocalStrings.ContainsKey(key))
                data.LocalStrings.Remove(key);
        }

        /// <summary>
        /// Removes data stored on an entity for a specified key.
        /// </summary>
        /// <param name="entity">The entity to delete data from.</param>
        /// <param name="key">The key of the data to delete.</param>
        public void DeleteLocalNumber(Entity entity, string key)
        {
            if (!entity.HasComponent<LocalData>()) return;
            LocalData data = entity.GetComponent<LocalData>();
            if (data.LocalFloats.ContainsKey(key))
                data.LocalFloats.Remove(key);
        }
    }
}
