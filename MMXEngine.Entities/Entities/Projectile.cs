using Artemis;
using Artemis.Interface;

namespace MMXEngine.ECS.Entities
{
    public class Projectile : IEntityTemplate
    {
        public Entity BuildEntity(Entity entity, EntityWorld entityWorld, params object[] args)
        {
            return entity;
        }
    }
}
