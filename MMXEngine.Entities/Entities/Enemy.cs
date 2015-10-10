using Artemis;
using MMXEngine.Interfaces.Entities;

namespace MMXEngine.ECS.Entities
{
    public class Enemy : IEnemy
    {
        public int TestValue { get; set; }

        public Enemy()
        {
            TestValue = 12345;
        }
    }
}
