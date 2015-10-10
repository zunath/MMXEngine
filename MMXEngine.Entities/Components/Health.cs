using Artemis.Interface;

namespace MMXEngine.ECS.Components
{
    public class Health : IComponent
    {
        public int CurrentHitPoints { get; set; }
        public int MaxHitPoints { get; set; }
    }
}
