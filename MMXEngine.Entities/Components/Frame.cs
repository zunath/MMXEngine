using Artemis.Interface;

namespace MMXEngine.ECS.Components
{
    public class Frame: IComponent
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public float Length { get; set; }
    }
}
