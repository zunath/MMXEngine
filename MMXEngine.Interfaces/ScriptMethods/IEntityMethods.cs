using Artemis;
using MMXEngine.Common.Enumerations;

namespace MMXEngine.Contracts.ScriptMethods
{
    public interface IEntityMethods
    {
        Entity GetPlayer();
        string GetName(Entity entity);
        Entity CreateEnemy(string name, int x, int y, Direction direction);
        CharacterType GetCharacterType(Entity entity);
        int GetCurrentHitPoints(Entity entity);
        int GetMaxHitPoints(Entity entity);
        int ApplyDamage(Entity entity, int amount);
        bool GetIsHostile(Entity entity);
    }
}
