using Artemis;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using MMXEngine.ECS.Components;
using MMXEngine.ECS.Data;
using MMXEngine.Interfaces.Entities;
using MMXEngine.Interfaces.Factories;
using MMXEngine.Interfaces.Managers;

namespace MMXEngine.ECS.Entities
{
    public class Level : IGameEntity
    {
        private readonly IComponentFactory _componentFactory;
        private readonly IDataManager _dataManager;
        private readonly ContentManager _contentManager;

        public Level(IComponentFactory componentFactory,
            IDataManager dataManager,
            ContentManager contentManager)
        {
            _componentFactory = componentFactory;
            _dataManager = dataManager;
            _contentManager = contentManager;
        }

        public Entity BuildEntity(Entity entity, params object[] args)
        {
            string dataFile = "./Levels/" + args[0] + ".json";
            LevelData levelData = _dataManager.Load<LevelData>(dataFile);
            
            Nameable nameable = _componentFactory.Create<Nameable>();
            nameable.Name = levelData.Name;

            Map map = _componentFactory.Create<Map>();
            map.Width = levelData.Width;
            map.Height = levelData.Height;
            map.Spritesheet = _contentManager.Load<Texture2D>("./Graphics/Tilesets/" + levelData.Spritesheet);
            map.Tiles = levelData.Tiles;
            map.BGM = _contentManager.Load<Song>("./Audio/BGM/" + levelData.BGMFile);

            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(map.BGM);

            entity.AddComponent(nameable);
            entity.AddComponent(map);
            return entity;
        }
    }
}
