using Artemis;
using MMXEngine.ECS.Components;
using MMXEngine.Interfaces.Entities;
using MMXEngine.Interfaces.Factories;

namespace MMXEngine.ECS.Entities
{
    public class Player : IGameEntity
    {
        private readonly IComponentFactory _componentFactory;

        public Player(IComponentFactory factory)
        {
            _componentFactory = factory;
        }

        public Entity BuildEntity(Entity entity)
        {
            entity.AddComponent(_componentFactory.Create<Health>());
            entity.AddComponent(_componentFactory.Create<Sprite>());

            return entity;
        }
    }
}
