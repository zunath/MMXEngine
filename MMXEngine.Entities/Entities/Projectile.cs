using Artemis;
using MMXEngine.Contracts.Entities;

namespace MMXEngine.ECS.Entities
{
    public class Projectile : IGameEntity
    {
        public Entity BuildEntity(Entity entity, params object[] args)
        {
            return entity;
        }
    }
}
