using Artemis;

namespace MMXEngine.ECS.Components
{
    public class Frame: ComponentPoolable
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public float Length { get; set; }
    }
}
