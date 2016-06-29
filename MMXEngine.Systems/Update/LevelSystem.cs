using System.Collections.Generic;
using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.Common.Attributes;
using MMXEngine.ECS.Components;
using MMXEngine.Interfaces.Factories;
using TiledSharp;

namespace MMXEngine.Systems.Update
{
    [LoadableSystem(2)]
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Update,
        Layer = 1)]
    public class LevelSystem : EntityProcessingSystem
    {
        private readonly ContentManager _contentManager;
        private readonly IComponentFactory _componentFactory;

        public LevelSystem(ContentManager contentManager, IComponentFactory componentFactory) 
            : base(Aspect.All(typeof(Map)))
        {
            _contentManager = contentManager;
            _componentFactory = componentFactory;
        }

        public override void Process(Entity entity)
        {
            Map mapComponent = entity.GetComponent<Map>();
            if (mapComponent.LevelMap == null)
            {
                mapComponent.LevelMap = new TmxMap("./Data/Levels/" + entity.GetComponent<Nameable>().Name + ".tmx");
                mapComponent.Tileset = _contentManager.Load<Texture2D>("Graphics/Tilesets/" + mapComponent.LevelMap.Tilesets[0].Name + ".png");

                mapComponent.TileWidth = mapComponent.LevelMap.Tilesets[0].TileWidth;
                mapComponent.TileHeight = mapComponent.LevelMap.Tilesets[0].TileHeight;

                mapComponent.TilesetTilesWide = mapComponent.Tileset.Width / mapComponent.TileWidth;
                mapComponent.TilesetTilesHigh = mapComponent.Tileset.Height / mapComponent.TileHeight;

                mapComponent.Collisions = BuildCollisions(mapComponent);
            }
        }

        private IEnumerable<CollisionBox> BuildCollisions(Map levelMap)
        {
            List<CollisionBox> collisions = new List<CollisionBox>();
            TmxMap map = levelMap.LevelMap;
            
            foreach (var collision in map.ObjectGroups["Collision"].Objects)
            {
                var box = _componentFactory.Create<CollisionBox>();
                box.Bounds = new Rectangle((int)collision.X, (int)collision.Y, (int)collision.Width, (int)collision.Height);
                collisions.Add(box);
            }


            return collisions;
        }
    }
}
