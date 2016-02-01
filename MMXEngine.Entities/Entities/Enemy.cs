using Artemis;
using MMXEngine.Interfaces.Entities;
using MMXEngine.Interfaces.Factories;

namespace MMXEngine.ECS.Entities
{
    public class Enemy : IGameEntity
    {
        private readonly IComponentFactory _componentFactory;

        public Enemy(IComponentFactory componentFactory)
        {
            _componentFactory = componentFactory;
        }

        public Entity BuildEntity(Entity entity, params object[] args)
        {
            return entity;
        }
    }
}
