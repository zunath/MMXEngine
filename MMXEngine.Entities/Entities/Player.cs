using Artemis;
using Artemis.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.Common.Enumerations;
using MMXEngine.ECS.Components;
using MMXEngine.ECS.Data;
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
            entity.AddComponent(_componentFactory.Create<PlayerAction>());
            entity.AddComponent(_componentFactory.Create<Health>());

            Position position = _componentFactory.Create<Position>();
            position.Facing = Direction.Right;
            entity.AddComponent(position);

            entity.AddComponent(_componentFactory.Create<Velocity>());
            entity.AddComponent(_componentFactory.Create<Renderable>());
            entity.AddComponent(BuildCollisionBox());
            PlayerCharacter playerCharacter = _componentFactory.Create<PlayerCharacter>();
            playerCharacter.CharacterType = characterType;
            entity.AddComponent(playerCharacter);

            Nameable nameable = _componentFactory.Create<Nameable>();
            nameable.Name = characterType == CharacterType.X ? "X" : "Zero";
            entity.AddComponent(nameable);

            EntitySystem.BlackBoard.SetEntry("Player", entity);

            return entity;
        }

        private Sprite BuildSprite(CharacterType characterType)
        {
            string dataFile = characterType == CharacterType.X ? "X.json" : "Zero.json";
            CreatureData data = _dataManager.Load<CreatureData>("Creatures/Players/" + dataFile);
            
            Sprite sprite = _componentFactory.Create<Sprite>();
            sprite.Texture = _contentManager.Load<Texture2D>("Graphics/Characters/" + data.TextureFile);
            foreach(Animation animation in data.Animations)
            {
                sprite.Animations.Add(animation.Name, animation);
                if (animation.IsDefaultAnimation)
                {
                    sprite.SetCurrentAnimation(animation.Name);
                }
            }

            return sprite;
        }

        private CollisionBox BuildCollisionBox()
        {
            CollisionBox box = _componentFactory.Create<CollisionBox>();
            box.Bounds = new Rectangle(0, 0, 12, 25);
            box.OffsetX = -5;
            box.OffsetY = -10;
            box.IsVisible = true;

            return box;
        }

    }
}
