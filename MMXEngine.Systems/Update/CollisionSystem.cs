using System;
using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using Microsoft.Xna.Framework;
using MMXEngine.Common.Constants;
using MMXEngine.Common.Enumerations;
using MMXEngine.Common.Extensions;
using MMXEngine.ECS.Components;
using MMXEngine.ECS.Data;

namespace MMXEngine.Systems.Update
{
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Update,
        Layer = 1)]
    public class CollisionSystem : EntityProcessingSystem
    {
        private readonly EntityWorld _world;

        public CollisionSystem(EntityWorld world):
            base(Aspect.All(typeof(CollisionBox), 
                typeof(Position), 
                typeof(Velocity)))
        {
            _world = world;
        }
        
        public override void Process(Entity entity)
        {
            ResetVariablesForThisFrame(entity);
            ProcessLevelCollisions(entity);
        }

        private void ResetVariablesForThisFrame(Entity entity)
        {
            Position position = entity.GetComponent<Position>();
            position.WasOnGroundLastFrame = position.IsOnGround;
            position.IsOnGround = false;
        }

        private void ProcessLevelCollisions(Entity entity)
        {
            Entity level = _world.EntityManager.GetEntities(Aspect.All(typeof(Map)))[0];
            if (level == null) return;
            Map map = level.GetComponent<Map>();
            CollisionBox box = entity.GetComponent<CollisionBox>();
            Position position = entity.GetComponent<Position>();
            Rectangle bounds = new Rectangle(
                (int)position.X + box.OffsetX,
                (int)position.Y + box.OffsetY,
                box.Width,
                box.Height);

            int leftTile = (int) Math.Floor((float) bounds.Left/TilesetConstants.TileWidth);
            int rightTile = (int)Math.Ceiling(((float)bounds.Right / TilesetConstants.TileWidth)) - 1;
            int topTile = (int) Math.Floor((float) bounds.Top/TilesetConstants.TileHeight);
            int bottomTile = (int) Math.Ceiling(((float) bounds.Bottom/TilesetConstants.TileHeight)) - 1;

            for (int y = topTile; y <= bottomTile; ++y)
            {
                for (int x = leftTile; x <= rightTile; ++x)
                {
                    if (x >= map.Width || x < 0 ||
                        y >= map.Height || y < 0)
                        continue;
                    

                    TileData tile = map.Tiles[x, y];

                    if (tile != null && tile.IsCollidable)
                    {
                        Rectangle tileBounds = new Rectangle(
                            x * TilesetConstants.TileWidth,
                            y * TilesetConstants.TileHeight,
                            TilesetConstants.TileWidth,
                            TilesetConstants.TileHeight);

                        Vector2 depth = bounds.GetIntersectionDepth(tileBounds);
                        var type = bounds.GetCollisionType(tileBounds);

                        // Entity's bottom collided with top of tile.
                        if (type == CollisionType.Top)
                        {
                            position.Y += depth.Y;
                            position.IsOnGround = true;
                            break;
                        }
                        else if (type == CollisionType.Left)
                        {
                            
                        }
                        else if (type == CollisionType.Right)
                        {
                            
                        }
                        else if (type == CollisionType.Bottom)
                        {
                            
                        }

                    }
                }
            }

        }
    }
}
