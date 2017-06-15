using Artemis;

namespace MMXEngine.Contracts.Entities
{
    public interface IGameEntity
    {
        Entity BuildEntity(Entity entity, params object[] args);
    }
}
