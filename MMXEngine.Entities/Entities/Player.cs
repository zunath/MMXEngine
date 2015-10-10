using Artemis;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.ECS.Components;
using MMXEngine.Interfaces.Entities;
using MMXEngine.Interfaces.Factories;

namespace MMXEngine.ECS.Entities
{
    public class Player : IGameEntity
    {
        private readonly IComponentFactory _componentFactory;
        private readonly ContentManager _contentManager;

        public Player(IComponentFactory factory,
            ContentManager contentManager)
        {
            _componentFactory = factory;
            _contentManager = contentManager;
        }

        public Entity BuildEntity(Entity entity)
        {
            Sprite sprite = _componentFactory.Create<Sprite>();
            sprite.Texture = _contentManager.Load<Texture2D>("Characters/Zero.png");

            entity.AddComponent(_componentFactory.Create<Health>());
            entity.AddComponent(sprite);

            return entity;
        }
    }
}
