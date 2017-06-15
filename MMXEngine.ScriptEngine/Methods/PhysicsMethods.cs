using System;
using Artemis;
using MMXEngine.Common.Enumerations;
using MMXEngine.Contracts.ScriptMethods;
using MMXEngine.ECS.Components;

namespace MMXEngine.ScriptEngine.Methods
{
    public class PhysicsMethods: IPhysicsMethods
    {
        public float GetVelocityX(Entity entity)
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

        public float GetVelocityY(Entity entity)
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

        public void SetVelocityX(Entity entity, float x)
        {
            if (entity.HasComponent<Velocity>())
            {
                entity.GetComponent<Velocity>().X = x;
            }
        }

        public void SetVelocityY(Entity entity, float y)
        {
            if (entity.HasComponent<Velocity>())
            {
                entity.GetComponent<Velocity>().Y = y;
            }
        }

        public float GetPositionX(Entity entity)
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

        public float GetPositionY(Entity entity)
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

        public Direction GetFacing(Entity entity)
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

        public void SetFacing(Entity entity, Direction facing)
        {
            if (entity.HasComponent<Position>())
            {
                entity.GetComponent<Position>().Facing = facing;
            }
        }

        public bool GetIsOnGround(Entity entity)
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
