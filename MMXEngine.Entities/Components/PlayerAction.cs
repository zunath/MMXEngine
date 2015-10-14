using Artemis.Interface;

namespace MMXEngine.ECS.Components
{
    public class PlayerAction : IComponent
    {
        public bool HasJumped { get; set; }
        public bool IsShooting { get; set; }
    }
}
