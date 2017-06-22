using Artemis;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.Contracts.Entities;
using MMXEngine.Contracts.Factories;
using MMXEngine.ECS.Components;

namespace MMXEngine.ECS.Entities
{
    public class LifeBar: IGameEntity
    {
        private readonly IComponentFactory _componentFactory;
        private readonly ContentManager _content;

        public LifeBar(IComponentFactory componentFactory,
            ContentManager content)
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
