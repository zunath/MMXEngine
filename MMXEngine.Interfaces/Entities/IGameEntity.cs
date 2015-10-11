using Artemis;

namespace MMXEngine.Interfaces.Entities
{
    public interface IGameEntity
    {
        Entity BuildEntity(Entity entity, params object[] args);
    }
}
