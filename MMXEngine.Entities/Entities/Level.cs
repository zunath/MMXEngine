using Artemis;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using MMXEngine.Contracts.Entities;
using MMXEngine.Contracts.Factories;
using MMXEngine.Contracts.Managers;
using MMXEngine.ECS.Components;
using MMXEngine.ECS.Data;

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

        public void BuildEntity(Entity entity, params object[] args)
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

            Script script = _componentFactory.Create<Script>();
            script.FilePath = "Levels/" + levelData.Script;

            Heartbeat hb = _componentFactory.Create<Heartbeat>();
            hb.Interval = 1.0f;

            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(map.BGM);

            entity.AddComponent(nameable);
            entity.AddComponent(map);
            entity.AddComponent(script);
            entity.AddComponent(hb);
        }
    }
}
