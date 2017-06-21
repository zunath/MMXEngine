using System;
using Artemis;
using Artemis.System;
using MMXEngine.Common.Enumerations;
using MMXEngine.Contracts.Factories;
using MMXEngine.Contracts.ScriptMethods;
using MMXEngine.ECS.Components;
using MMXEngine.ECS.Entities;

namespace MMXEngine.ScriptEngine.Methods
{
    public class EntityMethods: IEntityMethods
    {
        private readonly IEntityFactory _entityFactory;

        public EntityMethods(IEntityFactory entityFactory)
        {
            _entityFactory = entityFactory;
        }
        
        public Entity GetPlayer()
        {
            if((Entity)EntitySystem.BlackBoard.GetEntry("Player") == null)
                throw new Exception("Player has not been added to the Artemis blackboard.");

            return (Entity)EntitySystem.BlackBoard.GetEntry("Player");
        }

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
    }
}
