using Artemis;
using Artemis.Attributes;
using Artemis.Interface;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.ECS.Components;
using MMXEngine.Interfaces.Factories;
using MMXEngine.Interfaces.Managers;

namespace MMXEngine.ECS.Entities
{
    public class Player : IEntityTemplate
    {
        private readonly IComponentFactory _factory;
        private readonly ContentManager _contentManager;

        public Player(IComponentFactory factory, ContentManager contentManager)
        {
            _factory = factory;
            _contentManager = contentManager;
        }
        
        public Entity BuildEntity(Entity entity, EntityWorld entityWorld, params object[] args)
        {
            Health health = entity.AddComponentFromPool<Health>();
            Sprite sprite = entity.AddComponentFromPool<Sprite>();
            sprite.Texture = _contentManager.Load<Texture2D>("./Zero.png");

            return entity;
        }
    }
}
