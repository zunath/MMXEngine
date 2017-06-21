using Artemis;

namespace MMXEngine.Contracts.Entities
{
    public interface IGameEntity
    {
        void BuildEntity(Entity entity, params object[] args);
    }
}
