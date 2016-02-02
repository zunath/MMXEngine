﻿using System.Collections.Generic;
using System.Linq;
using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using Microsoft.Xna.Framework;
using MMXEngine.Common.Enumerations;
using MMXEngine.Common.Extensions;
using MMXEngine.ECS.Components;

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
            base(Aspect.All(typeof(CollisionBox), typeof(Position), typeof(Velocity)))
        {
            _world = world;
        }
        
        public override void Process(Entity entity)
        {
            UpdateCollisionBoxPosition(entity);
            ProcessLevelCollisions(entity);
        }

        private void UpdateCollisionBoxPosition(Entity entity)
        {
            Position position = entity.GetComponent<Position>();
            CollisionBox box = entity.GetComponent<CollisionBox>();

            int offsetX = box.OffsetX;
            if (position.Facing == Direction.Left)
            {
                offsetX = -offsetX;
            }

            box.Bounds = new Rectangle((int)position.X + offsetX, (int)position.Y + box.OffsetY, box.Bounds.Width, box.Bounds.Height);
        }

        private void ProcessLevelCollisions(Entity entity)
        {
            Entity level = _world.EntityManager.GetEntities(Aspect.All(typeof(Map)))[0];
            if (level == null) return;
            CollisionBox box = entity.GetComponent<CollisionBox>();
            Position position = entity.GetComponent<Position>();
            IEnumerable<CollisionBox> levelCollisions = level.GetComponent<Map>().Collisions;
            Velocity velocity = entity.GetComponent<Velocity>();
            
            foreach (CollisionBox collision in levelCollisions)
            {
                CollisionType collisionType = collision.Bounds.GetCollisionType(box.Bounds);

                if (collisionType == CollisionType.Bottom)
                {
                    if (velocity.Y > 0.0f)
                    {
                        entity.GetComponent<Velocity>().Y = 0.0f;
                        position.IsOnGround = true;
                        if (entity.HasComponent<PlayerAction>())
                        {
                            entity.GetComponent<PlayerAction>().HasJumped = false;
                        }
                    }
                }
            }
            
        }
    }
}
