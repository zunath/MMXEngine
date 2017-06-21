using Artemis;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.Contracts.Entities;
using MMXEngine.Contracts.Factories;
using MMXEngine.Contracts.Managers;
using MMXEngine.ECS.Components;
using MMXEngine.ECS.Data;

namespace MMXEngine.ECS.Entities
{
    public class Item: IGameEntity
    {
        private readonly IComponentFactory _componentFactory;
        private readonly IDataManager _dataManager;
        private readonly ContentManager _contentManager;

        public Item(IComponentFactory componentFactory,
            IDataManager dataManager,
            ContentManager contentManager)
        {
            _componentFactory = componentFactory;
            _dataManager = dataManager;
            _contentManager = contentManager;
        }

        public void BuildEntity(Entity entity, params object[] args)
        {
            string itemResourceFile = args[0] as string;
            string dataFile = "/Items/" + itemResourceFile + ".json";
            ItemData data = _dataManager.Load<ItemData>(dataFile);

            Sprite sprite = _componentFactory.Create<Sprite>();
            sprite.Texture = _contentManager.Load<Texture2D>("./Graphics/Items/" + data.TextureFile);
            foreach (Animation animation in data.Animations)
            {
                sprite.Animations.Add(animation.Name, animation);
                if (animation.IsDefaultAnimation)
                {
                    sprite.SetCurrentAnimation(animation.Name);
                }
            }

            entity.AddComponent(sprite);
            Position position = _componentFactory.Create<Position>();
            position.X = (int?) args[1] ?? 0;
            position.Y = (int?) args[2] ?? 0;
            entity.AddComponent(position);
            entity.AddComponent(_componentFactory.Create<Renderable>());
            entity.AddComponent(_componentFactory.Create<Velocity>());
            entity.AddComponent(_componentFactory.Create<LocalData>());

            Nameable nameable = _componentFactory.Create<Nameable>();
            nameable.Name = data.Name;
            entity.AddComponent(nameable);

            Script script = _componentFactory.Create<Script>();
            script.FilePath = "Items/" + data.Script;
            entity.AddComponent(script);

            CollisionBox box = _componentFactory.Create<CollisionBox>();
            box.Width = data.CollisionWidth;
            box.Height = data.CollisionHeight;
            box.OffsetX = data.CollisionOffsetX;
            box.OffsetY = data.CollisionOffsetY;
            entity.AddComponent(box);

            Gravity gravity = _componentFactory.Create<Gravity>();
            gravity.Speed = 4.0f;
            entity.AddComponent(gravity);
        }
    }
}
