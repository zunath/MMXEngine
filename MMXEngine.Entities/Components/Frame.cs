using Artemis.Interface;

namespace MMXEngine.ECS.Components
{
    public class Frame: IComponent
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public float Length { get; set; }
    }
}
