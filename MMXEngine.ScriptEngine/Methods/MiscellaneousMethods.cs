using System;
using Artemis;
using MMXEngine.Common.Attributes;
using MMXEngine.Contracts.ScriptMethods;
using MMXEngine.ECS.Components;

namespace MMXEngine.ScriptEngine.Methods
{
    /// <summary>
    /// Miscellaneous methods used in scripts.
    /// </summary>
    [ScriptNamespace("Misc")]
    public class MiscellaneousMethods: IMiscellaneousMethods
    {
        /// <summary>
        /// Prints a string to the console output.
        /// </summary>
        /// <param name="message">The message to print out to the console.</param>
        public void Print(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Retrieves the name of the script file used by an entity.
        /// </summary>
        /// <param name="entity">The entity to retrieve the name of the script from.</param>
        /// <returns>The name of the script used by an entity.</returns>
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
