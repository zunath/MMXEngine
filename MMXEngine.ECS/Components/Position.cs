using Artemis.Interface;
using MMXEngine.Common.Enumerations;

namespace MMXEngine.ECS.Components
{
    public class Position : IComponent
    {
        public float X { get; set; }
        public float Y { get; set; }
        public Direction Facing { get; set; }
        public bool WasOnGroundLastFrame { get; set; }
        public bool IsOnGround { get; set; }
    }
}
