using Artemis;

namespace MMXEngine.ScriptEngine
{
    internal class ScriptQueueObject
    {
        internal string FilePath { get; set; }
        internal string MethodName { get; set; }
        internal Entity TargetObject { get; set; }

        public ScriptQueueObject(string filePath,
            string methodName,
            Entity targetObject)
        {
            FilePath = filePath;
            MethodName = methodName;
            TargetObject = targetObject;
        }

    }
}
