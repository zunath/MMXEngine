using System.Collections.Generic;
using Artemis.Interface;

namespace MMXEngine.ECS.Components
{
    public class Animation: IComponent
    {
        public string Name { get; set; }
        public IList<Frame> Frames { get; set; }
        public int CurrentFrameID { get; set; }
        
        
    }
}
