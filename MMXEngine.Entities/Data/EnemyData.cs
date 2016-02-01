using System.Collections.Generic;
using MMXEngine.ECS.Components;

namespace MMXEngine.ECS.Data
{
    public class EnemyData
    {
        public string Name { get; set; }
        public string TextureFile { get; set; }
        public IEnumerable<Animation> Animations { get; set; }
        public IEnumerable<Script> Scripts { get; set; } 
    }
}
