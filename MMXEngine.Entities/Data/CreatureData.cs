using System.Collections.Generic;
using MMXEngine.ECS.Components;

namespace MMXEngine.ECS.Data
{
    public class CreatureData
    {
        public string Name { get; set; }
        public string TextureFile { get; set; }
        public string Script { get; set; }
        public IEnumerable<Animation> Animations { get; set; }
        
    }
}
