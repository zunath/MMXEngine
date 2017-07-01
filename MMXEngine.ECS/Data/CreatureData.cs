using System.Collections.Generic;
using MMXEngine.ECS.Components;

namespace MMXEngine.ECS.Data
{
    public class CreatureData
    {
        public string Name { get; set; }
        public int CollisionWidth { get; set; }
        public int CollisionHeight { get; set; }
        public int CollisionOffsetX { get; set; }
        public int CollisionOffsetY { get; set; }
        public string TextureFile { get; set; }
        public float HeartbeatInterval { get; set; }
        public string Script { get; set; }
        public IEnumerable<Animation> Animations { get; set; }
        
    }
}
