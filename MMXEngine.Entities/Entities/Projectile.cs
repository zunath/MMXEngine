﻿using Artemis;
using Artemis.Interface;
using MMXEngine.Interfaces.Entities;

namespace MMXEngine.ECS.Entities
{
    public class Projectile : IProjectile, IEntityTemplate
    {
        public Entity BuildEntity(Entity entity, EntityWorld entityWorld, params object[] args)
        {
            return entity;
        }
    }
}
