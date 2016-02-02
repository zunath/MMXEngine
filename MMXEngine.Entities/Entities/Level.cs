using Artemis;
using MMXEngine.ECS.Components;
using MMXEngine.Interfaces.Entities;
using MMXEngine.Interfaces.Factories;

namespace MMXEngine.ECS.Entities
{
    public class Level : IGameEntity
    {
        private readonly IComponentFactory _componentFactory;

        public Level(IComponentFactory componentFactory)
        {
            _componentFactory = componentFactory;
        }

        public Entity BuildEntity(Entity entity, params object[] args)
        {
            Nameable nameable = _componentFactory.Create<Nameable>();
            Map map = _componentFactory.Create<Map>();
            nameable.Name = args[0] as string;
            entity.AddComponent(map);
            entity.AddComponent(nameable);
            return entity;
        }
    }
}
