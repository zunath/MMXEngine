using Artemis;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.ECS.Components;
using MMXEngine.ECS.Data;
using MMXEngine.Interfaces.Entities;
using MMXEngine.Interfaces.Factories;
using MMXEngine.Interfaces.Managers;

namespace MMXEngine.ECS.Entities
{
    public class Enemy : IGameEntity
    {
        private readonly IComponentFactory _componentFactory;
        private readonly IDataManager _dataManager;
        private readonly ContentManager _contentManager;

        public Enemy(IComponentFactory componentFactory,
            IDataManager dataManager,
            ContentManager contentManager)
        {
            _componentFactory = componentFactory;
            _dataManager = dataManager;
            _contentManager = contentManager;
        }

        public Entity BuildEntity(Entity entity, params object[] args)
        {
            string enemyResourceFile = args[0] as string;
            string dataFile = "/Creatures/Enemies/" + enemyResourceFile + ".json";
            CreatureData data = _dataManager.Load<CreatureData>(dataFile);

            Sprite sprite = _componentFactory.Create<Sprite>();
            sprite.Texture = _contentManager.Load<Texture2D>("./Graphics/Enemies/" + data.TextureFile);
            foreach (Animation animation in data.Animations)
            {
                sprite.Animations.Add(animation.Name, animation);
                if (animation.IsDefaultAnimation)
                {
                    sprite.SetCurrentAnimation(animation.Name);
                }
            }

            entity.AddComponent(sprite);
            entity.AddComponent(_componentFactory.Create<Health>());
            entity.AddComponent(_componentFactory.Create<Position>());
            entity.AddComponent(_componentFactory.Create<Renderable>());
            entity.AddComponent(_componentFactory.Create<Velocity>());
            entity.AddComponent(_componentFactory.Create<Hostile>());
            Nameable nameable = _componentFactory.Create<Nameable>();
            nameable.Name = data.Name;
            entity.AddComponent(nameable);

            Script script = _componentFactory.Create<Script>();
            script.FilePath = data.Script;
            entity.AddComponent(script);

            CollisionBox box = _componentFactory.Create<CollisionBox>();
            box.Bounds = new Rectangle(0, 0, 36, 52);
            box.OffsetX = -18;
            box.OffsetY = -25;
            entity.AddComponent(box);

            return entity;
        }
    }
}
