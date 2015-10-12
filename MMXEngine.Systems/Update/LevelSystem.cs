using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.ECS.Components;
using TiledSharp;

namespace MMXEngine.Systems.Update
{
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Update,
        Layer = 1)]
    public class LevelSystem : EntityProcessingSystem
    {
        private readonly ContentManager _contentManager;

        public LevelSystem(ContentManager contentManager) 
            : base(Aspect.All(typeof(Map)))
        {
            _contentManager = contentManager;
        }

        public override void Process(Entity entity)
        {
            Map mapComponent = entity.GetComponent<Map>();
            if (mapComponent.LevelMap == null)
            {
                mapComponent.LevelMap = new TmxMap("./Data/Levels/" + mapComponent.MapName + ".tmx");
                mapComponent.Tileset = _contentManager.Load<Texture2D>("Tilesets/" + mapComponent.LevelMap.Tilesets[0].Name + ".png");

                mapComponent.TileWidth = mapComponent.LevelMap.Tilesets[0].TileWidth;
                mapComponent.TileHeight = mapComponent.LevelMap.Tilesets[0].TileHeight;

                mapComponent.TilesetTilesWide = mapComponent.Tileset.Width / mapComponent.TileWidth;
                mapComponent.TilesetTilesHigh = mapComponent.Tileset.Height / mapComponent.TileHeight;
            }
        }
    }
}
