using Artemis;

namespace MMXEngine.ECS.Components
{
    public class Health : ComponentPoolable
    {
        public int CurrentHitPoints { get; set; }
        public int MaxHitPoints { get; set; }
    }
}
