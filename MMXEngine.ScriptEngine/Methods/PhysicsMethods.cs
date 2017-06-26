using System;
using Artemis;
using MMXEngine.Common.Attributes;
using MMXEngine.Common.Enumerations;
using MMXEngine.Contracts.ScriptMethods;
using MMXEngine.ECS.Components;

namespace MMXEngine.ScriptEngine.Methods
{
    /// <summary>
    /// Script methods used for physics.
    /// </summary>
    [ScriptNamespace("Physics")]
    public class PhysicsMethods : IPhysicsMethods
    {
        /// <summary>
        /// Returns the current X velocity for an entity.
        /// </summary>
        /// <param name="entity">The entity to retrieve the X velocity from.</param>
        /// <returns>The current X velocity.</returns>
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

        /// <summary>
        /// Returns the current Y velocity for an entity.
        /// </summary>
        /// <param name="entity">The entity to retrieve the Y velocity from.</param>
        /// <returns>The current Y velocity.</returns>
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

        /// <summary>
        /// Sets the current X velocity for an entity to a new value.
        /// </summary>
        /// <param name="entity">The entity to manipulate.</param>
        /// <param name="x">The x velocity to set.</param>
        public void SetVelocityX(Entity entity, float x)
        {
            if (entity.HasComponent<Velocity>())
            {
                entity.GetComponent<Velocity>().X = x;
            }
        }

        /// <summary>
        /// Sets the current Y velocity for an entity to a new value.
        /// </summary>
        /// <param name="entity">The entity to manipulate.</param>
        /// <param name="y">The y velocity to set.</param>
        public void SetVelocityY(Entity entity, float y)
        {
            if (entity.HasComponent<Velocity>())
            {
                entity.GetComponent<Velocity>().Y = y;
            }
        }

        /// <summary>
        /// Returns the current X position for an entity.
        /// </summary>
        /// <param name="entity">The entity to retrieve the X position of.</param>
        /// <returns>The current X position of an entity.</returns>
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

        /// <summary>
        /// Returns the current Y position for an entity.
        /// </summary>
        /// <param name="entity">The entity to retrieve the Y position of.</param>
        /// <returns>The current Y position of an entity.</returns>
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

        /// <summary>
        /// Returns the current facing of an entity.
        /// </summary>
        /// <param name="entity">The entity to manipulate.</param>
        /// <returns>The current facing of an entity.</returns>
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

        /// <summary>
        /// Sets the current facing of an entity to a new value.
        /// </summary>
        /// <param name="entity">The entity to manipulate.</param>
        /// <param name="facing">The new facing to set.</param>
        public void SetFacing(Entity entity, Direction facing)
        {
            if (entity.HasComponent<Position>())
            {
                entity.GetComponent<Position>().Facing = facing;
            }
        }

        /// <summary>
        /// Returns true if entity is on the ground. Otherwise returns false.
        /// </summary>
        /// <param name="entity">The entity to manipulate.</param>
        /// <returns>True if entity is on the ground. Otherwise returns false.</returns>
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

        /// <summary>
        /// Returns the gravity applied to an entity.
        /// </summary>
        /// <param name="entity">The entity to manipulate.</param>
        /// <returns>The gravity being applied to the entity.</returns>
        public float GetGravity(Entity entity)
        {
            try
            {
                return entity.HasComponent<Gravity>() ?
                    entity.GetComponent<Gravity>().Speed :
                    0.0f;
            }
            catch (Exception)
            {
                return -1f;
            }
        }

        /// <summary>
        /// Sets the gravity applied to an entity.
        /// </summary>
        /// <param name="entity">The entity to manipulate.</param>
        /// <param name="value">The new amount of gravity to apply.</param>
        public void SetGravity(Entity entity, float value)
        {
            if (entity.HasComponent<Gravity>())
            {
                entity.GetComponent<Gravity>().Speed = value;
            }
        }
    }
}
