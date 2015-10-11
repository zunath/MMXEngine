using System.Collections.Generic;
using Artemis;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.Common.Enumerations;
using MMXEngine.ECS.Components;
using MMXEngine.Interfaces.Entities;
using MMXEngine.Interfaces.Factories;
using MMXEngine.Interfaces.Managers;

namespace MMXEngine.ECS.Entities
{
    public class Player : IGameEntity
    {
        private readonly IComponentFactory _componentFactory;
        private readonly IDataManager _dataManager;
        private readonly ContentManager _contentManager;

        public Player(IComponentFactory factory,
            IDataManager dataManager,
            ContentManager contentManager)
        {
            _componentFactory = factory;
            _contentManager = contentManager;
            _dataManager = dataManager;
        }

        public Entity BuildEntity(Entity entity, params object[] args)
        {
            CharacterType characterType = args.Length > 0 ? (CharacterType) args[0] : CharacterType.X;

            entity.AddComponent(BuildSprite(characterType));
            entity.AddComponent(_componentFactory.Create<PlayerPhysics>());
            entity.AddComponent(_componentFactory.Create<Health>());
            entity.AddComponent(_componentFactory.Create<Position>());
            entity.AddComponent(_componentFactory.Create<Velocity>());
            entity.AddComponent(_componentFactory.Create<Renderable>());
            entity.AddComponent(BuildCollisionBox());

            return entity;
        }

        private Sprite BuildSprite(CharacterType characterType)
        {
            string textureFile = "Characters/MMX.png";
            string animationFile = "Animations/MMXAnimations.json";

            if (characterType == CharacterType.Zero)
            {
                textureFile = "Characters/Zero.png";
                animationFile = "Animations/ZeroAnimations.json";
            }

            Sprite sprite = _componentFactory.Create<Sprite>();
            sprite.Texture = _contentManager.Load<Texture2D>(textureFile);
            sprite.Animations = new Dictionary<int, Animation>();
            IList<Animation> animations = _dataManager.Load<IList<Animation>>(animationFile);
            for (int animationID = 0; animationID < animations.Count; animationID++)
            {
                sprite.Animations.Add(animationID, animations[animationID]);
            }
            
            return sprite;
        }

        private CollisionBox BuildCollisionBox()
        {
            CollisionBox box = _componentFactory.Create<CollisionBox>();
            box.Bounds = new Rectangle(0, 0, 60, 60);
            box.IsVisible = true;

            return box;
        }

    }
}
