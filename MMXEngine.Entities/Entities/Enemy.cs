using Artemis;
using Artemis.Interface;
using MMXEngine.Interfaces.Entities;

namespace MMXEngine.ECS.Entities
{
    public class Enemy : IEnemy, IEntityTemplate
    {
        public int TestValue { get; set; }

        public Enemy()
        {
            TestValue = 12345;
        }

        public Entity BuildEntity(Entity entity, EntityWorld entityWorld, params object[] args)
        {


            return entity;
        }
    }
}
