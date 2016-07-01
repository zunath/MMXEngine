using Artemis.Interface;

namespace MMXEngine.ECS.Components
{
    public class PlayerAction : IComponent
    {
        public bool IsDashing { get; set; }
        public float CurrentDashLength { get; set; }
        public float MaxDashLength { get; set; }
        public bool IsShooting { get; set; }
    }
}
