using Artemis.Interface;
using MMXEngine.Common.Enumerations;

namespace MMXEngine.ECS.Components
{
    public class Script: IComponent
    {
        public string Name { get; set; }
        public ScriptEvent Event { get; set; }
    }
}
