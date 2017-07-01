using Artemis;
using MMXEngine.Contracts.Entities;
using MMXEngine.Contracts.Factories;
using MMXEngine.ECS.Components;

namespace MMXEngine.ECS.Entities
{
    public class DebugWindow: IGameEntity
    {
        private readonly IComponentFactory _componentFactory;
        
        public DebugWindow(IComponentFactory componentFactory)
        {
            _componentFactory = componentFactory;
        }

        public void BuildEntity(Entity entity, params object[] args)
        {
            entity.AddComponent(_componentFactory.Create<Position>());
            entity.AddComponent(_componentFactory.Create<VisibleText>());
        }
    }
}
