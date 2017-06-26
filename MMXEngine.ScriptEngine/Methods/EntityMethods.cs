using System;
using Artemis;
using Artemis.System;
using MMXEngine.Common.Attributes;
using MMXEngine.Common.Enumerations;
using MMXEngine.Contracts.Factories;
using MMXEngine.Contracts.ScriptMethods;
using MMXEngine.ECS.Components;
using MMXEngine.ECS.Entities;

namespace MMXEngine.ScriptEngine.Methods
{
    /// <summary>
    /// Script methods used for modifying entities.
    /// </summary>
    [ScriptNamespace("Entity")]
    public class EntityMethods: IEntityMethods
    {
        private readonly IEntityFactory _entityFactory;

        /// <summary>
        /// Constructor for the EntityMethods class.
        /// </summary>
        /// <param name="entityFactory">The factory used for creating entities.</param>
        public EntityMethods(IEntityFactory entityFactory)
        {
            _entityFactory = entityFactory;
        }
        
        /// <summary>
        /// Returns the active player entity.
        /// </summary>
        /// <returns>The player entity</returns>
        public Entity GetPlayer()
        {
            if((Entity)EntitySystem.BlackBoard.GetEntry("Player") == null)
                throw new Exception("Player has not been added to the Artemis blackboard.");

            return (Entity)EntitySystem.BlackBoard.GetEntry("Player");
        }

        /// <summary>
        /// Returns the name of a given entity.
        /// </summary>
        /// <param name="entity">The entity to get the name of</param>
        /// <returns>The name of the entity</returns>
        public string GetName(Entity entity)
        {
            try
            {
                return entity.GetComponent<Nameable>().Name;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Creates an enemy entity at a specified position.
        /// </summary>
        /// <param name="name">Name of the enemy file in the Enemies folder.</param>
        /// <param name="x">The X position of the newly created entity.</param>
        /// <param name="y">The Y position of the newly created entity.</param>
        /// <param name="direction">The direction the enemy starts facing.</param>
        /// <returns>The newly created entity, or nil if no file could be found.</returns>
        public Entity CreateEnemy(string name, int x, int y, Direction direction)
        {
            try
            {
                Entity enemy = _entityFactory.Create<Enemy>(name, x, y);
                enemy.GetComponent<Position>().Facing = direction;
                return enemy;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Creates an item at a specified position.
        /// </summary>
        /// <param name="name">Name of the item file in the Items folder.</param>
        /// <param name="x">The X position of the newly created entity.</param>
        /// <param name="y">The Y position of the newly created entity.</param>
        /// <returns>The new created entity, or nil if no file could be found.</returns>
        public Entity CreateItem(string name, int x, int y)
        {
            try
            {
                Entity item = _entityFactory.Create<Item>(name, x, y);
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Returns the type of character currently being played.
        /// </summary>
        /// <param name="entity">The player entity.</param>
        /// <returns>The CharacterType of the character currently being played. Returns CharacterType.Unknown if cannot be determined.</returns>
        public CharacterType GetCharacterType(Entity entity)
        {
            try
            {
                return entity.GetComponent<PlayerCharacter>().CharacterType;
            }
            catch (Exception)
            {
                return CharacterType.Unknown;
            }
            
        }

        /// <summary>
        /// Returns the current hit points of a given entity.
        /// </summary>
        /// <param name="entity">The entity to retrieve the current hit points of.</param>
        /// <returns>The amount of current hit points for the entity.</returns>
        public int GetCurrentHitPoints(Entity entity)
        {
            try
            {
                return entity.GetComponent<Health>().CurrentHitPoints;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// Returns the max hit points of a given entity.
        /// </summary>
        /// <param name="entity">The entity to retrieve the max hit points of.</param>
        /// <returns>The amount of max hit points for the entity.</returns>
        public int GetMaxHitPoints(Entity entity)
        {
            try
            {
                return entity.GetComponent<Health>().MaxHitPoints;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// Sets the current hit points of a given entity.
        /// </summary>
        /// <param name="entity">The entity to set the current hit points of</param>
        /// <param name="value">The amount of hit points to set.</param>
        public void SetCurrentHitPoints(Entity entity, int value)
        {
            if (!entity.HasComponent<Health>()) return;
            Health health = entity.GetComponent<Health>();

            if (value < 0) value = 0;
            else if (value > health.MaxHitPoints) value = health.MaxHitPoints;
            health.CurrentHitPoints = value;
        }

        /// <summary>
        /// Sets the max hit points of a given entity.
        /// </summary>
        /// <param name="entity">The entity to set the max hit points of</param>
        /// <param name="value">The amount of hit points to set.</param>
        public void SetMaxHitPoints(Entity entity, int value)
        {
            if (!entity.HasComponent<Health>()) return;
            Health health = entity.GetComponent<Health>();

            if (value < 1) value = 1;
            health.MaxHitPoints = value;

            if (health.CurrentHitPoints > health.MaxHitPoints) health.CurrentHitPoints = health.MaxHitPoints;
        }

        /// <summary>
        /// Applies damage to a given entity and returns their current hit points.
        /// </summary>
        /// <param name="entity">The entity to apply damage to.</param>
        /// <param name="amount">The amount of damage to apply.</param>
        /// <returns>The current hit points of the entity after damage has been applied.</returns>
        public int ApplyDamage(Entity entity, int amount)
        {
            try
            {
                Health health = entity.GetComponent<Health>();
                health.CurrentHitPoints -= amount;

                return health.CurrentHitPoints;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        
        /// <summary>
        /// Returns true if entity is hostile, otherwise returns false.
        /// </summary>
        /// <param name="entity">The entity to check the hostility of</param>
        /// <returns>True if entity is hostile, False otherwise</returns>
        public bool GetIsHostile(Entity entity)
        {
            try
            {
                return entity.HasComponent<Hostile>();
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Destroys an entity. If a player is targeted, nothing will happen.
        /// </summary>
        /// <param name="entity">The entity to destroy.</param>
        public void DestroyObject(Entity entity)
        {
            if (entity == EntitySystem.BlackBoard.GetEntry("Player")) return;

            entity.Delete();
        }
    }
}
