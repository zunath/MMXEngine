using System.Collections.Generic;
using Artemis.Interface;

namespace MMXEngine.ECS.Components
{
    public class Animation: IComponent
    {
        public IEnumerable<Frame> Frames { get; set; }
        public int CurrentFrame { get; set; }
    }
}
