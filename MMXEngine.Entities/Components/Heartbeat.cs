using Artemis.Interface;

namespace MMXEngine.ECS.Components
{
    public class Heartbeat: IComponent
    {
        public float Interval { get; set; }
        public float CurrentTimer { get; set; }
    }
}
