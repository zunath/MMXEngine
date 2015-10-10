using System.Collections.Generic;
using Artemis;

namespace MMXEngine.ECS.Components
{
    public class Animation: ComponentPoolable
    {
        public IEnumerable<Frame> Frames { get; set; }
        public int CurrentFrame { get; set; }
    }
}
