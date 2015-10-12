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
            Map map = _componentFactory.Create<Map>();
            map.MapName = args[0] as string;
            entity.AddComponent(map);
            return entity;
        }
    }
}
