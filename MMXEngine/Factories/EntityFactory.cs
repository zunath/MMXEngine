using Artemis;
using Autofac;
using MMXEngine.ECS.Entities;
using MMXEngine.Interfaces.Entities;
using MMXEngine.Interfaces.Factories;

namespace MMXEngine.Windows.Factories
{
    public class EntityFactory : IEntityFactory
    {
        private readonly EntityWorld _world;
        private readonly IComponentContext _context;

        public EntityFactory(EntityWorld world, IComponentContext context)
        {
            _world = world;
            _context = context;
        }

        public Entity Create<T>()
            where T: IGameEntity
        {
            Entity entity = _world.CreateEntity();
            IGameEntity gameObject = _context.ResolveNamed<IGameEntity>(typeof (T).ToString());
            return gameObject.BuildEntity(entity);
        }
    }
}
