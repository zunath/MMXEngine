﻿using System;
using Artemis;
using MMXEngine.Common.Enumerations;
using MMXEngine.ECS.Components;
using MMXEngine.Interfaces.Systems;

namespace MMXEngine.ScriptEngine.Methods
{
    public class PhysicsMethods: IScriptMethodGroup
    {
        public static float GetVelocityX(Entity entity)
        {
            try
            {
                return entity.GetComponent<Velocity>().X;
            }
            catch (Exception)
            {
                return 0.0f;
            }
        }

        public static float GetVelocityY(Entity entity)
        {
            try
            {
                return entity.GetComponent<Velocity>().Y;
            }
            catch (Exception)
            {
                return 0.0f;
            }
        }

        public static void SetVelocityX(Entity entity, float x)
        {
            if (entity.HasComponent<Velocity>())
            {
                entity.GetComponent<Velocity>().X = x;
            }
        }

        public static void SetVelocityY(Entity entity, float y)
        {
            if (entity.HasComponent<Velocity>())
            {
                entity.GetComponent<Velocity>().Y = y;
            }
        }

        public static float GetPositionX(Entity entity)
        {
            try
            {
                return entity.GetComponent<Position>().X;
            }
            catch (Exception)
            {
                return 0.0f;
            }
        }

        public static float GetPositionY(Entity entity)
        {
            try
            {
                return entity.GetComponent<Position>().Y;
            }
            catch (Exception)
            {
                return 0.0f;
            }
        }

        public static Direction GetFacing(Entity entity)
        {
            try
            {
                return entity.GetComponent<Position>().Facing;
            }
            catch (Exception)
            {
                return Direction.Unknown;
            }
        }

        public static bool GetIsOnGround(Entity entity)
        {
            try
            {
                return entity.GetComponent<Position>().IsOnGround;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
