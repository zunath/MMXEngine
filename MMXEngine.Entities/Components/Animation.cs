using System.Collections.Generic;
using Artemis.Interface;

namespace MMXEngine.ECS.Components
{
    public class Animation: IComponent
    {
        private int _currentFrameID;

        public string Name { get; set; }
        public IList<Frame> Frames { get; set; }

        public int CurrentFrameID
        {
            get
            {
                return _currentFrameID;
            }
            set
            {
                _currentFrameID = value > Frames.Count - 1 ? 0 : value;
            }
        }
        
        
    }
}
