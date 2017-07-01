using Artemis.Interface;

namespace MMXEngine.ECS.Components
{
    public class VisibleText: IComponent
    {
        public string Message { get; set; }
        public int Size { get; set; }
    }
}
