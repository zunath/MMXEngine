using System.Collections.Generic;
using Artemis.Interface;

namespace MMXEngine.ECS.Components
{
    public class Animation: IComponent
    {
        private int _currentFrameID;

        public string Name { get; set; }
        public IList<Frame> Frames { get; set; }
        public bool IsDefaultAnimation { get; set; }

        public int CurrentFrameID
        {
            get
            {
                return _currentFrameID;
            }
            set
            {
                if (value > Frames.Count - 1)
                {
                    _currentFrameID = 0;
                }
                else if (value < 0)
                {
                    _currentFrameID = Frames.Count - 1;
                }
                else
                {
                    _currentFrameID = value;
                }

            }
        }
    }
}
