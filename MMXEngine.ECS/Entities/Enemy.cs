using System.IO.Abstractions;
using Artemis;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.Contracts.Entities;
using MMXEngine.Contracts.Factories;
using MMXEngine.Contracts.Managers;
using MMXEngine.ECS.Components;
using MMXEngine.ECS.Data;

namespace MMXEngine.ECS.Entities
{
    public class Enemy : IGameEntity
    {
        private readonly IComponentFactory _componentFactory;
        private readonly IDataManager _dataManager;
        private readonly IContentManager _contentManager;
        private readonly IFileSystem _fileSystem;

        public Enemy(IComponentFactory componentFactory,
            IDataManager dataManager,
            IContentManager contentManager,
            IFileSystem fileSystem)
        {
            _componentFactory = componentFactory;
            _dataManager = dataManager;
            _contentManager = contentManager;
            _fileSystem = fileSystem;
        }

        public void BuildEntity(Entity entity, params object[] args)
        {
            string enemyResourceFile = args[0] as string;
            string dataFile = "\\Enemies\\" + enemyResourceFile + ".json";
            CreatureData data = _dataManager.Load<CreatureData>(dataFile);

            Sprite sprite = _componentFactory.Create<Sprite>();
            sprite.Texture = _contentManager.Load<Texture2D>(".\\Graphics\\" + _fileSystem.Path.ChangeExtension(data.TextureFile, null));
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
            Position position = _componentFactory.Create<Position>();
            position.X = (int?) args[1] ?? 0;
            position.Y = (int?) args[2] ?? 0;
            entity.AddComponent(position);
            entity.AddComponent(_componentFactory.Create<Renderable>());
            entity.AddComponent(_componentFactory.Create<Velocity>());
            entity.AddComponent(_componentFactory.Create<Hostile>());
            entity.AddComponent(_componentFactory.Create<LocalData>());
            
            Nameable nameable = _componentFactory.Create<Nameable>();
            nameable.Name = data.Name;
            entity.AddComponent(nameable);

            Script script = _componentFactory.Create<Script>();
            script.FilePath = data.Script;
            entity.AddComponent(script);

            CollisionBox box = _componentFactory.Create<CollisionBox>();
            box.Width = data.CollisionWidth;
            box.Height = data.CollisionHeight;
            box.OffsetX = data.CollisionOffsetX;
            box.OffsetY = data.CollisionOffsetY;
            entity.AddComponent(box);

            Heartbeat hb = _componentFactory.Create<Heartbeat>();
            hb.Interval = data.HeartbeatInterval;
            entity.AddComponent(hb);

            Gravity gravity = _componentFactory.Create<Gravity>();
            gravity.Speed = 4.0f;
            entity.AddComponent(gravity);
        }
    }
}
