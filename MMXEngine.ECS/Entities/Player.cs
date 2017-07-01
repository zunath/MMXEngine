using System.IO.Abstractions;
using Artemis;
using Artemis.System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.Common.Enumerations;
using MMXEngine.Contracts.Entities;
using MMXEngine.Contracts.Factories;
using MMXEngine.Contracts.Managers;
using MMXEngine.ECS.Components;
using MMXEngine.ECS.Data;
using MMXEngine.ECS.States.Player;

namespace MMXEngine.ECS.Entities
{
    public class Player : IGameEntity
    {
        private readonly IComponentFactory _componentFactory;
        private readonly IDataManager _dataManager;
        private readonly IPlayerStateFactory _playerStateFactory;
        private readonly IContentManager _contentManager;
        private CharacterType _characterType;
        private PlayerData _playerData;
        private readonly IFileSystem _fileSystem;

        public Player(IComponentFactory componentFactory,
            IPlayerStateFactory playerStateFactory,
            IDataManager dataManager,
            IContentManager contentManager,
            IFileSystem fileSystem)
        {
            _componentFactory = componentFactory;
            _playerStateFactory = playerStateFactory;
            _contentManager = contentManager;
            _dataManager = dataManager;
            _fileSystem = fileSystem;
        }

        public void BuildEntity(Entity entity, params object[] args)
        {
            _characterType = args.Length > 0 ? (CharacterType) args[0] : CharacterType.X;
            LoadPlayerDataFile();

            entity.AddComponent(BuildSprite());
            PlayerCharacter character = _componentFactory.Create<PlayerCharacter>();
            character.MaxDashLength = _playerData.MaxDashLength;
            character.MaxJumpLength = _playerData.MaxJumpLength;
            character.MoveSpeed = _playerData.MoveSpeed;
            character.DashSpeed = _playerData.DashSpeed;
            character.JumpSpeed = _playerData.JumpSpeed;
            character.CharacterType = _characterType;
            character.MaxNumberOfJumps = _playerData.MaxNumberOfJumps;

            entity.AddComponent(character);

            Health health = _componentFactory.Create<Health>();
            health.MaxHitPoints = 16;
            health.CurrentHitPoints = 8;
            entity.AddComponent(health);

            Position position = _componentFactory.Create<Position>();
            position.Facing = Direction.Right;
            position.X = (int?) args[1] ?? 0;
            position.Y = (int?) args[2] ?? 0;
            entity.AddComponent(position);

            entity.AddComponent(_componentFactory.Create<LocalData>());
            entity.AddComponent(_componentFactory.Create<Velocity>());
            entity.AddComponent(_componentFactory.Create<Renderable>());
            entity.AddComponent(BuildCollisionBox());

            Nameable nameable = _componentFactory.Create<Nameable>();
            nameable.Name = _playerData.Name;
            entity.AddComponent(nameable);

            Heartbeat heartbeat = _componentFactory.Create<Heartbeat>();
            heartbeat.Interval = _playerData.HeartbeatInterval;
            entity.AddComponent(heartbeat);

            Script script = _componentFactory.Create<Script>();
            script.FilePath = _playerData.Script;
            entity.AddComponent(script);

            PlayerStateMap stateMap = _componentFactory.Create<PlayerStateMap>();
            stateMap.States.Add(PlayerState.Idle, _playerStateFactory.Create<IdleState>());
            stateMap.States.Add(PlayerState.Move, _playerStateFactory.Create<MoveState>());
            stateMap.States.Add(PlayerState.Dash, _playerStateFactory.Create<DashState>());
            stateMap.States.Add(PlayerState.Jump, _playerStateFactory.Create<JumpState>());
            stateMap.States.Add(PlayerState.Fall, _playerStateFactory.Create<FallState>());
            stateMap.States.Add(PlayerState.Land, _playerStateFactory.Create<LandState>());
            stateMap.CurrentState = PlayerState.Idle;
            entity.AddComponent(stateMap);

            Gravity gravity = _componentFactory.Create<Gravity>();
            gravity.Speed = _playerData.GravitySpeed;
            entity.AddComponent(gravity);

            PlayerStats stats = _componentFactory.Create<PlayerStats>();
            stats.Lives = 2;
            entity.AddComponent(stats);

            EntitySystem.BlackBoard.SetEntry("Player", entity);
        }

        private void LoadPlayerDataFile()
        {
            string dataFile = _characterType == CharacterType.X ? "X.json" : "Zero.json";
            _playerData = _dataManager.Load<PlayerData>("Players/" + dataFile);
        }

        private Sprite BuildSprite()
        {
            Sprite sprite = _componentFactory.Create<Sprite>();
            sprite.Texture = _contentManager.Load<Texture2D>(".\\Graphics\\" + _fileSystem.Path.ChangeExtension(_playerData.TextureFile, null));
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

        private CollisionBox BuildCollisionBox()
        {
            CollisionBox box = _componentFactory.Create<CollisionBox>();
            box.Width = _playerData.CollisionWidth;
            box.Height = _playerData.CollisionHeight;
            box.OffsetX = _playerData.CollisionOffsetX;
            box.OffsetY = _playerData.CollisionOffsetY;
            box.IsVisible = false;

            return box;
        }

    }
}
