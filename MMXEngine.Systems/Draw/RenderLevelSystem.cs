using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.Common.Constants;
using MMXEngine.ECS.Components;
using MMXEngine.ECS.Data;

namespace MMXEngine.Systems.Draw
{
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
            Map map = entity.GetComponent<Map>();
            Vector2 origin = new Vector2(0, 0);

            for (int x = 0; x < map.Width; x++)
            {
                for (int y = 0; y < map.Height; y++)
                {
                    TileData tile = map.Tiles[x, y];
                    if (tile == null) continue;

                    Vector2 position = new Vector2(
                        x * TilesetConstants.TileWidth,
                        y * TilesetConstants.TileHeight);
                    Rectangle source = new Rectangle(
                        tile.X, 
                        tile.Y, 
                        tile.X * TilesetConstants.TileWidth + TilesetConstants.TileWidth, 
                        tile.Y * TilesetConstants.TileHeight + TilesetConstants.TileHeight);
                    _spriteBatch.Draw(map.Spritesheet,   // Texture
                        position,                        // Position
                        source,                          // Source
                        Color.White,                     // Color
                        0.0f,                            // Rotation
                        origin,                          // Origin 
                        1.0f,                            // Scale
                        SpriteEffects.None,              // SpriteEffects
                        0.0f);                           // Layer Depth
                }
            }

        }
    }
}
