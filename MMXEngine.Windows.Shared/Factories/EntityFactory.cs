﻿using Artemis;
using Autofac;
using MMXEngine.Contracts.Entities;
using MMXEngine.Contracts.Factories;

namespace MMXEngine.Windows.Shared.Factories
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

        public Entity Create<T>(params object[] args)
            where T: IGameEntity
        {
            Entity entity = _world.CreateEntity();
            IGameEntity gameObject = _context.ResolveNamed<IGameEntity>(typeof (T).ToString());
            gameObject.BuildEntity(entity, args);
            return entity;
        }
    }
}
