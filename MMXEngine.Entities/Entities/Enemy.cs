using Artemis;
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
            string dataFile = "./Data/Enemies/" + enemyResourceFile;
            EnemyData data = _dataManager.Load<EnemyData>(dataFile);

            Sprite sprite = _componentFactory.Create<Sprite>();
            sprite.Texture = _contentManager.Load<Texture2D>("./Graphics/" + data.TextureFile);
            entity.AddComponent(sprite);
            entity.AddComponent(_componentFactory.Create<Health>());
            entity.AddComponent(_componentFactory.Create<Position>());
            entity.AddComponent(_componentFactory.Create<Renderable>());
            entity.AddComponent(_componentFactory.Create<Velocity>());

            foreach (Script script in data.Scripts)
            {
                entity.AddComponent(script);
            }

            return entity;
        }
    }
}
