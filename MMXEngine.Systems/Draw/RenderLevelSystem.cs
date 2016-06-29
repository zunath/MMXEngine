using System;
using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.Common.Attributes;
using MMXEngine.Common.Extensions;
using MMXEngine.ECS.Components;
using TiledSharp;

namespace MMXEngine.Systems.Draw
{
    [LoadableSystem(2)]
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Draw,
        Layer = 1)]
    public class RenderLevelSystem: EntityProcessingSystem
    {
        private readonly SpriteBatch _spriteBatch;

        public RenderLevelSystem(SpriteBatch spriteBatch) 
            : base(Aspect.All(typeof(Map)))
        {
            _spriteBatch = spriteBatch;
        }

        public override void Process(Entity entity)
        {
            Map component = entity.GetComponent<Map>();
            TmxMap map = component.LevelMap;
            
            for (var i = 0; i < map.Layers[0].Tiles.Count; i++)
            {
                int gid = map.Layers[0].Tiles[i].Gid;
                if (gid == 0) continue;

                int tileFrame = gid - 1;
                int column = tileFrame % component.TilesetTilesWide;
                int row = tileFrame + 1 > component.TilesetTilesWide ? tileFrame - column * component.TilesetTilesWide : 0;

                float x = i % map.Width * map.TileWidth;
                float y = (float)Math.Floor(i / (double)map.Width) * map.TileHeight;

                Rectangle tilesetRec = new Rectangle(component.TileWidth * column, component.TileWidth * row, component.TileWidth, component.TileHeight);

                _spriteBatch.Draw(component.Tileset, new Rectangle((int)x, (int)y, component.TileWidth, component.TileHeight), tilesetRec, Color.White);
            }

            foreach (CollisionBox box in component.Collisions)
            {
                if (box.IsVisible)
                {
                    _spriteBatch.DrawRectangle(box.Bounds, box.Color);
                }
            }
        }
    }
}
