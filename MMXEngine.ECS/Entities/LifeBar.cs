﻿using Artemis;
using MMXEngine.Contracts.Entities;
using MMXEngine.Contracts.Factories;
using MMXEngine.Contracts.Managers;
using MMXEngine.ECS.Components;

namespace MMXEngine.ECS.Entities
{
    public class LifeBar: IGameEntity
    {
        private readonly IComponentFactory _componentFactory;
        private readonly IContentManager _content;

        public LifeBar(IComponentFactory componentFactory,
            IContentManager content)
        {
            _componentFactory = componentFactory;
            _content = content;
        }

        public void BuildEntity(Entity entity, params object[] args)
        {
            Position position = _componentFactory.Create<Position>();
            entity.AddComponent(position);


        }
    }
}
