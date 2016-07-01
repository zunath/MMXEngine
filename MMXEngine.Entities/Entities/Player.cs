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
        private CharacterType _characterType;
        private PlayerData _playerData;

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
            _characterType = args.Length > 0 ? (CharacterType) args[0] : CharacterType.X;
            LoadPlayerDataFile();

            entity.AddComponent(BuildSprite());
            PlayerAction action = _componentFactory.Create<PlayerAction>();
            action.MaxDashLength = _playerData.MaxDashLength;
            entity.AddComponent(action);
            entity.AddComponent(_componentFactory.Create<Health>());

            Position position = _componentFactory.Create<Position>();
            position.Facing = Direction.Right;
            position.X = (int?) args[1] ?? 0;
            position.Y = (int?) args[2] ?? 0;
            entity.AddComponent(position);

            entity.AddComponent(_componentFactory.Create<Velocity>());
            entity.AddComponent(_componentFactory.Create<Renderable>());
            entity.AddComponent(BuildCollisionBox((int)position.X, (int)position.Y));
            PlayerCharacter playerCharacter = _componentFactory.Create<PlayerCharacter>();
            playerCharacter.CharacterType = _characterType;
            entity.AddComponent(playerCharacter);

            Nameable nameable = _componentFactory.Create<Nameable>();
            nameable.Name = _playerData.Name;
            entity.AddComponent(nameable);

            Heartbeat heartbeat = _componentFactory.Create<Heartbeat>();
            heartbeat.Interval = _playerData.HeartbeatInterval;
            entity.AddComponent(heartbeat);

            Script script = _componentFactory.Create<Script>();
            script.FilePath = _playerData.Script;
            entity.AddComponent(script);

            EntitySystem.BlackBoard.SetEntry("Player", entity);

            return entity;
        }

        private void LoadPlayerDataFile()
        {
            string dataFile = _characterType == CharacterType.X ? "X.json" : "Zero.json";
            _playerData = _dataManager.Load<PlayerData>("Creatures/Players/" + dataFile);
        }

        private Sprite BuildSprite()
        {
            Sprite sprite = _componentFactory.Create<Sprite>();
            sprite.Texture = _contentManager.Load<Texture2D>("Graphics/Characters/" + _playerData.TextureFile);
            foreach(Animation animation in _playerData.Animations)
            {
                sprite.Animations.Add(animation.Name, animation);
                if (animation.IsDefaultAnimation)
                {
                    sprite.SetCurrentAnimation(animation.Name);
                }
            }

            return sprite;
        }

        private CollisionBox BuildCollisionBox(int positionX, int positionY)
        {
            CollisionBox box = _componentFactory.Create<CollisionBox>();
            box.Bounds = new Rectangle(positionX, positionY, _playerData.CollisionWidth, _playerData.CollisionHeight);
            box.OffsetX = _playerData.CollisionOffsetX;
            box.OffsetY = _playerData.CollisionOffsetY;
            box.IsVisible = true;

            return box;
        }

    }
}
