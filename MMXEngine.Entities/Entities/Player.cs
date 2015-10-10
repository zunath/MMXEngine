using System;
using Artemis;
using Artemis.Interface;
using MMXEngine.ECS.Components;
using MMXEngine.Interfaces.Entities;
using MMXEngine.Interfaces.Factories;

namespace MMXEngine.ECS.Entities
{
    public class Player : IPlayer, IEntityTemplate
    {
        private readonly IComponentFactory _factory;

        public Player(IComponentFactory factory)
        {
            _factory = factory;
        }
        
        public Entity BuildEntity(Entity entity, EntityWorld entityWorld, params object[] args)
        {
            _factory.Create<HealthComponent>();

            return entity;
        }
    }
}
