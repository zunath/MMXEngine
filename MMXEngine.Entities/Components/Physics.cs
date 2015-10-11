using Artemis.Interface;

namespace MMXEngine.ECS.Components
{
    public class Physics : IComponent
    {
        public float Acceleration { get; set; }
        public float TargetSpeed { get; set; }
        public float CurrentSpeedX { get; set; }
        public float CurrentSpeedY { get; set; }
    }
}
