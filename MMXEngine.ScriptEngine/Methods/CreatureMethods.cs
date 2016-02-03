using System;
using Artemis;
using Artemis.System;
using MMXEngine.Common.Enumerations;
using MMXEngine.ECS.Components;
using MMXEngine.Interfaces.Systems;

namespace MMXEngine.ScriptEngine.Methods
{
    public class CreatureMethods: IScriptMethodGroup
    {
        public static Entity GetPlayer()
        {
            return (Entity)EntitySystem.BlackBoard.GetEntry("Player");
        }

        public static CharacterType GetCharacterType(Entity entity)
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

        public static int GetCurrentHitPoints(Entity entity)
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

        public static int GetMaxHitPoints(Entity entity)
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

        public static int ApplyDamage(Entity entity, int amount)
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
        
        public static bool GetIsHostile(Entity entity)
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
